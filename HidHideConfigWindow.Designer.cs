namespace FestivalInstrumentMapper
{
    partial class HidHideConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            infoLabel = new Label();
            hidHideConfigBox = new CheckBox();
            hidHideConfigLabel = new Label();
            doneButton = new Button();
            installHidHideLink = new LinkLabel();
            refreshBlacklistButton = new Button();
            SuspendLayout();
            // 
            // infoLabel
            // 
            infoLabel.Location = new Point(12, 9);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(344, 71);
            infoLabel.TabIndex = 2;
            infoLabel.Text = "If you're running into Fortnite detecting 2 controllers when using FestivalInstrumentMapper with Xbox 360 instruments, you can configure HidHide to always hide Xbox 360 controllers from Fortnite.";
            // 
            // hidHideConfigBox
            // 
            hidHideConfigBox.AutoSize = true;
            hidHideConfigBox.Location = new Point(12, 83);
            hidHideConfigBox.Name = "hidHideConfigBox";
            hidHideConfigBox.Size = new Size(313, 19);
            hidHideConfigBox.TabIndex = 3;
            hidHideConfigBox.Text = "Tell HidHide to hide Xbox 360 controllers from Fortnite";
            hidHideConfigBox.UseVisualStyleBackColor = true;
            hidHideConfigBox.CheckedChanged += hidHideConfigBox_CheckedChanged;
            // 
            // hidHideConfigLabel
            // 
            hidHideConfigLabel.Location = new Point(29, 103);
            hidHideConfigLabel.Name = "hidHideConfigLabel";
            hidHideConfigLabel.Size = new Size(326, 63);
            hidHideConfigLabel.TabIndex = 4;
            hidHideConfigLabel.Text = "Enabling or disabling this setting will override all existing HidHide settings. You may need to reconnect your controller for changes to take effect.";
            // 
            // doneButton
            // 
            doneButton.Location = new Point(280, 169);
            doneButton.Name = "doneButton";
            doneButton.Size = new Size(75, 23);
            doneButton.TabIndex = 5;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += doneButton_Click;
            // 
            // installHidHideLink
            // 
            installHidHideLink.AutoSize = true;
            installHidHideLink.Location = new Point(12, 173);
            installHidHideLink.Name = "installHidHideLink";
            installHidHideLink.Size = new Size(85, 15);
            installHidHideLink.TabIndex = 6;
            installHidHideLink.TabStop = true;
            installHidHideLink.Text = "Install HidHide";
            installHidHideLink.Visible = false;
            installHidHideLink.LinkClicked += installHidHideLink_LinkClicked;
            // 
            // refreshBlacklistButton
            // 
            refreshBlacklistButton.Location = new Point(145, 169);
            refreshBlacklistButton.Name = "refreshBlacklistButton";
            refreshBlacklistButton.Size = new Size(129, 23);
            refreshBlacklistButton.TabIndex = 7;
            refreshBlacklistButton.Text = "Refresh Blacklist...";
            refreshBlacklistButton.UseVisualStyleBackColor = true;
            refreshBlacklistButton.Visible = false;
            refreshBlacklistButton.Click += refreshBlacklistButton_Click;
            // 
            // HidHideConfigWindow
            // 
            AcceptButton = doneButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 201);
            Controls.Add(refreshBlacklistButton);
            Controls.Add(installHidHideLink);
            Controls.Add(doneButton);
            Controls.Add(hidHideConfigLabel);
            Controls.Add(hidHideConfigBox);
            Controls.Add(infoLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HidHideConfigWindow";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configure HidHide for Fortnite Festival";
            Load += HidHideConfigWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label infoLabel;
        private CheckBox hidHideConfigBox;
        private Label hidHideConfigLabel;
        private Button doneButton;
        private LinkLabel installHidHideLink;
        private Button refreshBlacklistButton;
    }
}