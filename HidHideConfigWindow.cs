using Nefarius.Drivers.HidHide;
using Nefarius.Utilities.DeviceManagement.PnP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestivalInstrumentMapper
{
    public partial class HidHideConfigWindow : Form
    {
        HidHideControlService hidHide = new HidHideControlService();
        string? fortniteExePath = null;

        public HidHideConfigWindow()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void installHidHideLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/nefarius/HidHide/releases/latest") { UseShellExecute = true });
        }

        private bool IsHidHideSetUpForUs()
        {
            bool listHasFortniteGame = false;
            IReadOnlyList<string> blacklistedApps = hidHide.ApplicationPaths;
            foreach (string app in blacklistedApps)
                if (app.ToLower().EndsWith("fortniteclient-win64-shipping.exe"))
                    listHasFortniteGame = true;
            return listHasFortniteGame && hidHide.IsActive && hidHide.IsAppListInverted;
        }

        public static IEnumerable<string> EnumerateXUSBDevices()
        {
            for (int i = 0;
                Devcon.FindByInterfaceGuid(DeviceInterfaceIds.XUsbDevice, out string _, out string instanceId, i);
                i++)
            {
                yield return instanceId;
            }
        }

        private void RefreshBlacklistedInstanceIDs()
        {
            hidHide.ClearBlockedInstancesList();
            foreach (string device in EnumerateXUSBDevices())
                hidHide.AddBlockedInstanceId(device);
        }

        private void SetUpHidHideForUs()
        {
            // I'm really sorry, this is just "the most convinient" way.
            // Removes all HidHide settings. I hope I give enough advance warning... :(
            hidHide.ClearApplicationsList();
            // Sets up the app list to be inverted and add exclusively the FortniteGame exe.
            hidHide.IsAppListInverted = true;
            hidHide.AddApplicationPath(fortniteExePath!);
            // Reloads our list of blacklisted instance IDs
            RefreshBlacklistedInstanceIDs();
            // Enables HidHide
            hidHide.IsActive = true;
        }

        private void DisableHidHideForUs()
        {
            hidHide.RemoveApplicationPath(fortniteExePath!);
            foreach (string device in EnumerateXUSBDevices())
                hidHide.RemoveBlockedInstanceId(device);
        }

        private void HidHideConfigWindow_Load(object sender, EventArgs e)
        {
            if (!hidHide.IsInstalled)
            {
                hidHideConfigBox.Enabled = false;
                hidHideConfigLabel.Text = "This option can't be enabled as you don't have HidHide installed. Click the link below to download and install HidHide.";
                installHidHideLink.Visible = true;
                return;
            }

            string? fortniteInstallDir = EpicLauncherDetection.GetInstallDirectory("Fortnite");
            if (fortniteInstallDir == null)
            {
                hidHideConfigBox.Enabled = false;
                hidHideConfigLabel.Text = "This option can't be enabled because we can't find a Fortnite installation.";
                return;
            }
            fortniteExePath = Path.GetFullPath(Path.Combine(fortniteInstallDir, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"));

            hidHideConfigBox.Checked = IsHidHideSetUpForUs();
            refreshBlacklistButton.Visible = hidHideConfigBox.Checked;
        }

        private void hidHideConfigBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hidHideConfigBox.Checked)
                SetUpHidHideForUs();
            else
                DisableHidHideForUs();
            refreshBlacklistButton.Visible = hidHideConfigBox.Checked;
        }

        private void refreshBlacklistButton_Click(object sender, EventArgs e)
        {
            RefreshBlacklistedInstanceIDs();
        }
    }
}
