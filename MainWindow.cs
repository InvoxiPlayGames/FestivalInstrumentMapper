using System.Diagnostics;
using HidApi;

namespace FestivalInstrumentMapper
{
    public partial class MainWindow : Form
    {
        HidApiDevice? selectedDevice = null;
        SyntheticController? activeController = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RefreshDevicesList()
        {
            deviceSelectBox.Items.Clear();

            List<DeviceInfo> enumeratedDevices = new();
            // PS3 Guitars
            enumeratedDevices.AddRange(Hid.Enumerate(0x12BA, 0x0100));
            enumeratedDevices.AddRange(Hid.Enumerate(0x12BA, 0x0200));
            // Wii Guitars
            enumeratedDevices.AddRange(Hid.Enumerate(0x1BAD, 0x0004));
            enumeratedDevices.AddRange(Hid.Enumerate(0x1BAD, 0x3010));
            // Santroller
            enumeratedDevices.AddRange(Hid.Enumerate(0x1209, 0x2882));
            // PS4 Guitars
            enumeratedDevices.AddRange(Hid.Enumerate(0x0E6F, 0x0173));
            enumeratedDevices.AddRange(Hid.Enumerate(0x0E6F, 0x024A));
            enumeratedDevices.AddRange(Hid.Enumerate(0x0738, 0x8261));

            if (enumeratedDevices.Count <= 0)
            {
                deviceSelectBox.Items.Add("No devices found!");
                deviceSelectBox.SelectedIndex = 0;
                deviceSelectBox.Enabled = false;
                startMappingButton.Enabled = false;
                return;
            }

            foreach (DeviceInfo enumeratedDevice in enumeratedDevices)
            {
                HidApiDevice hidApiDevice = new(enumeratedDevice);
                deviceSelectBox.Items.Add(hidApiDevice);
            }

            deviceSelectBox.SelectedIndex = 0;
            deviceSelectBox.Enabled = true;
            startMappingButton.Enabled = true;
        }

        private void startMappingButton_Click(object sender, EventArgs e)
        {
            if (deviceSelectBox.SelectedIndex >= 0)
            {
                selectedDevice = (HidApiDevice?)deviceSelectBox.SelectedItem;
                if (selectedDevice == null)
                {
                    MessageBox.Show("Couldn't open the device!");
                    return;
                }
                if (selectedDevice.GetDeviceType() == HidApiDeviceType.Unknown)
                {
                    MessageBox.Show($"That device is unknown?!");
                    return;
                }
                selectedDevice.OpenDevice();
                selectedDevice.AssignController(activeController);
                activeController.Connect();
                Task.Run(selectedDevice.RunThread);
                startMappingButton.Enabled = false;
                refreshListButton.Enabled = false;
                deviceSelectBox.Enabled = false;
                startMappingButton.Text = "Mapping...";
                statusLabel.Text = $"Guitar is being mapped!\nPress the PS/Instrument/Guide button on your guitar to disconnect.";
                disconnectMonitorTimer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please select a device first!");
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            windowsVersionLabel.Text = $"Windows: {Environment.OSVersion.Version}";
            try
            {
                int synthstartup_result = GipSyntheticEx.Startup();
                if (synthstartup_result != 0)
                {
                    statusLabel.Text = $"Failed to initialise GipSyntheticEx. ({synthstartup_result:X8})\nEither your Windows version is unsupported, or an error has occurred.";
                    startMappingButton.Enabled = false;
                    refreshListButton.Enabled = false;
                    deviceSelectBox.Enabled = false;
                    startMappingButton.Text = "Error :(";
                    return;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Failed to initialise GipSyntheticEx.\nException: {ex.Message}";
                startMappingButton.Enabled = false;
                refreshListButton.Enabled = false;
                deviceSelectBox.Enabled = false;
                startMappingButton.Text = "Error :(";
                return;
            }

            try
            {
                activeController = new();
                activeController.SetData(PDPJaguarValues.Arrival, PDPJaguarValues.Metadata);
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Failed to initialise emulated controller.\nException: {ex.Message}";
                startMappingButton.Enabled = false;
                refreshListButton.Enabled = false;
                deviceSelectBox.Enabled = false;
                startMappingButton.Text = "Error :(";
                return;
            }

            RefreshDevicesList();
            statusLabel.Text = "Select your device from the list.";
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("open https://github.com/InvoxiPlayGames/FestivalInstrumentMapper");
        }

        private void faqAboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("open https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/wiki/FAQ-and-About");
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            RefreshDevicesList();
        }

        private void disconnectMonitorTimer_Tick(object sender, EventArgs e)
        {
            if (selectedDevice != null)
            {
                if (!selectedDevice.IsRunning())
                {
                    activeController!.Disconnect();
                    selectedDevice = null;
                    startMappingButton.Enabled = true;
                    refreshListButton.Enabled = true;
                    deviceSelectBox.Enabled = true;
                    startMappingButton.Text = "Start Mapping";
                    statusLabel.Text = "Select your device from the list.";
                    disconnectMonitorTimer.Enabled = false;
                }
            }
        }
    }
}
