using FestivalInstrumentMapper.Devices;
using System.Diagnostics;

namespace FestivalInstrumentMapper
{
    public partial class MainWindow : Form
    {
        private MapperThread? mapperThread = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RefreshDevicesList()
        {
            deviceSelectBox.Items.Clear();

            List<(ushort vendorId, ushort productId)> filterIds =
            [
                // PS3 Guitars
                (0x12BA, 0x0100),
                (0x12BA, 0x0200),
                // Wii Guitars
                (0x1BAD, 0x0004),
                (0x1BAD, 0x3010),
                // Santroller
                (0x1209, 0x2882),
                // PS4 Guitars
                (0x0E6F, 0x0173),
                (0x0E6F, 0x024A),
                (0x0738, 0x8261),
                // Raphnet
                (0x289B, 0x0028),
                (0x289B, 0x0029),
                (0x289B, 0x002B),
                (0x289B, 0x002C),
                (0x289B, 0x0080),
                (0x289B, 0x0081)
            ];

            var enumeratedHidDevices = HidDeviceStream.Enumerate(filterIds);

            foreach (var enumeratedDevice in enumeratedHidDevices)
            {
                HidApiDevice hidApiDevice = new(enumeratedDevice);
                deviceSelectBox.Items.Add(hidApiDevice);
            }

            for (int i = 0; i < 4; i++)
            {
                XInputDevice xinputDevice = new(i);
                if (xinputDevice.Exists())
                    deviceSelectBox.Items.Add(xinputDevice);
            }

            if (deviceSelectBox.Items.Count <= 0)
            {
                deviceSelectBox.Items.Add("No devices found!");
                deviceSelectBox.SelectedIndex = 0;
                deviceSelectBox.Enabled = false;
                startMappingButton.Enabled = false;
                return;
            }

            deviceSelectBox.SelectedIndex = 0;
            deviceSelectBox.Enabled = true;
            startMappingButton.Enabled = true;
        }

        private void startMappingButton_Click(object sender, EventArgs e)
        {
            if (deviceSelectBox.SelectedIndex >= 0)
            {
                var selectedDevice = (InstrumentMapperDevice?)deviceSelectBox.SelectedItem;
                if (selectedDevice == null)
                {
                    MessageBox.Show("Couldn't open the device!");
                    return;
                }

                try
                {
                    var synthController = new SyntheticController();
                    synthController.SetData(PDPJaguarValues.Arrival, PDPJaguarValues.Metadata);
                    mapperThread = new(selectedDevice, synthController);
                    mapperThread.Start();
                }
                catch (Exception ex)
                {
                    mapperThread?.Dispose();
                    mapperThread = null;

                    statusLabel.Text = $"Failed to initialise emulated controller.\nException: {ex.Message}";
                    // detect STATUS_ACCESS_DENIED and give a helpful hint
                    if (ex.Message.Contains("80070005"))
                        statusLabel.Text += "\nHave you enabled Windows Developer Mode?";
                    startMappingButton.Enabled = false;
                    refreshListButton.Enabled = false;
                    deviceSelectBox.Enabled = false;
                    startMappingButton.Text = "Error :(";
                    return;
                }

                startMappingButton.Enabled = false;
                refreshListButton.Enabled = false;
                deviceSelectBox.Enabled = false;
                hidHideLinkLabel.Enabled = false;
                startMappingButton.Text = "Mapped!";
                statusLabel.Text = $"Guitar is now mapped!\nPress the PS/Instrument/Guide button, or both select and start, on your guitar to disconnect.";
                disconnectMonitorTimer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please select a device first!");
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

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

            RefreshDevicesList();
            statusLabel.Text = "Select your device from the list.";
        }

        private void OpenURL(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/InvoxiPlayGames/FestivalInstrumentMapper");
        }

        private void faqAboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/InvoxiPlayGames/FestivalInstrumentMapper/wiki/FAQ-and-About");
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            RefreshDevicesList();
        }

        private void disconnectMonitorTimer_Tick(object sender, EventArgs e)
        {
            if (mapperThread != null && !mapperThread.IsRunning)
            {
                mapperThread.Dispose();
                mapperThread = null;

                startMappingButton.Enabled = true;
                refreshListButton.Enabled = true;
                deviceSelectBox.Enabled = true;
                hidHideLinkLabel.Enabled = true;
                startMappingButton.Text = "Start Mapping";
                statusLabel.Text = "Select your device from the list.";
                disconnectMonitorTimer.Enabled = false;
            }
        }

        private void hidHideLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HidHideConfigWindow configWindow = new();
            configWindow.ShowDialog(this);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var exception = (Exception)args.ExceptionObject;

            string errorFile = Program.WriteErrorFile(exception);
            MessageBox.Show(
                $"An unhandled error has occurred:\n\n{exception.GetFirstLine()}\n\nPlease send the error log '{errorFile}' to the devs. The program will now exit.",
                "Fatal Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
