namespace FestivalInstrumentMapper
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            deviceSelectPreLabel = new Label();
            deviceSelectBox = new ComboBox();
            statusGroupBox = new GroupBox();
            statusLabel = new Label();
            windowsVersionLabel = new Label();
            startMappingButton = new Button();
            faqAboutLinkLabel = new LinkLabel();
            githubLinkLabel = new LinkLabel();
            faqAboutNagLabel = new Label();
            gayLabel = new Label();
            refreshListButton = new Button();
            disconnectMonitorTimer = new System.Windows.Forms.Timer(components);
            statusGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // deviceSelectPreLabel
            // 
            deviceSelectPreLabel.AutoSize = true;
            deviceSelectPreLabel.Location = new Point(12, 15);
            deviceSelectPreLabel.Name = "deviceSelectPreLabel";
            deviceSelectPreLabel.Size = new Size(79, 15);
            deviceSelectPreLabel.TabIndex = 0;
            deviceSelectPreLabel.Text = "Select Device:";
            // 
            // deviceSelectBox
            // 
            deviceSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceSelectBox.FormattingEnabled = true;
            deviceSelectBox.Location = new Point(97, 12);
            deviceSelectBox.Name = "deviceSelectBox";
            deviceSelectBox.Size = new Size(196, 23);
            deviceSelectBox.TabIndex = 1;
            // 
            // statusGroupBox
            // 
            statusGroupBox.Controls.Add(statusLabel);
            statusGroupBox.Controls.Add(windowsVersionLabel);
            statusGroupBox.Location = new Point(12, 137);
            statusGroupBox.Name = "statusGroupBox";
            statusGroupBox.Size = new Size(350, 100);
            statusGroupBox.TabIndex = 3;
            statusGroupBox.TabStop = false;
            statusGroupBox.Text = "Status and Stats";
            // 
            // statusLabel
            // 
            statusLabel.Location = new Point(6, 19);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(338, 60);
            statusLabel.TabIndex = 1;
            statusLabel.Text = "Some status goes here!";
            // 
            // windowsVersionLabel
            // 
            windowsVersionLabel.AutoSize = true;
            windowsVersionLabel.Location = new Point(6, 79);
            windowsVersionLabel.Name = "windowsVersionLabel";
            windowsVersionLabel.Size = new Size(149, 15);
            windowsVersionLabel.TabIndex = 0;
            windowsVersionLabel.Text = "Windows: 99.99.99999.9999";
            // 
            // startMappingButton
            // 
            startMappingButton.Location = new Point(255, 38);
            startMappingButton.Name = "startMappingButton";
            startMappingButton.Size = new Size(107, 23);
            startMappingButton.TabIndex = 4;
            startMappingButton.Text = "Start Mapping";
            startMappingButton.UseVisualStyleBackColor = true;
            startMappingButton.Click += startMappingButton_Click;
            // 
            // faqAboutLinkLabel
            // 
            faqAboutLinkLabel.AutoSize = true;
            faqAboutLinkLabel.Location = new Point(12, 72);
            faqAboutLinkLabel.Name = "faqAboutLinkLabel";
            faqAboutLinkLabel.Size = new Size(88, 15);
            faqAboutLinkLabel.TabIndex = 5;
            faqAboutLinkLabel.TabStop = true;
            faqAboutLinkLabel.Text = "FAQ and About";
            faqAboutLinkLabel.LinkClicked += faqAboutLinkLabel_LinkClicked;
            // 
            // githubLinkLabel
            // 
            githubLinkLabel.AutoSize = true;
            githubLinkLabel.Location = new Point(12, 113);
            githubLinkLabel.Name = "githubLinkLabel";
            githubLinkLabel.Size = new Size(347, 15);
            githubLinkLabel.TabIndex = 6;
            githubLinkLabel.TabStop = true;
            githubLinkLabel.Text = "https://github.com/InvoxiPlayGames/FestivalInstrumentMapper";
            githubLinkLabel.LinkClicked += githubLinkLabel_LinkClicked;
            // 
            // faqAboutNagLabel
            // 
            faqAboutNagLabel.AutoSize = true;
            faqAboutNagLabel.Location = new Point(97, 72);
            faqAboutNagLabel.Name = "faqAboutNagLabel";
            faqAboutNagLabel.Size = new Size(160, 15);
            faqAboutNagLabel.TabIndex = 7;
            faqAboutNagLabel.Text = "<- click this if you need help!";
            // 
            // gayLabel
            // 
            gayLabel.AutoSize = true;
            gayLabel.Location = new Point(12, 98);
            gayLabel.Name = "gayLabel";
            gayLabel.Size = new Size(248, 15);
            gayLabel.TabIndex = 8;
            gayLabel.Text = "This is Free Software, made with <3 by Emma.";
            // 
            // refreshListButton
            // 
            refreshListButton.Location = new Point(299, 12);
            refreshListButton.Name = "refreshListButton";
            refreshListButton.Size = new Size(63, 23);
            refreshListButton.TabIndex = 9;
            refreshListButton.Text = "Refresh...";
            refreshListButton.UseVisualStyleBackColor = true;
            refreshListButton.Click += refreshListButton_Click;
            // 
            // disconnectMonitorTimer
            // 
            disconnectMonitorTimer.Interval = 1000;
            disconnectMonitorTimer.Tick += disconnectMonitorTimer_Tick;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 249);
            Controls.Add(refreshListButton);
            Controls.Add(gayLabel);
            Controls.Add(faqAboutNagLabel);
            Controls.Add(githubLinkLabel);
            Controls.Add(faqAboutLinkLabel);
            Controls.Add(startMappingButton);
            Controls.Add(statusGroupBox);
            Controls.Add(deviceSelectBox);
            Controls.Add(deviceSelectPreLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FestivalInstrumentMapper";
            Load += MainWindow_Load;
            statusGroupBox.ResumeLayout(false);
            statusGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label deviceSelectPreLabel;
        private ComboBox deviceSelectBox;
        private GroupBox statusGroupBox;
        private Label windowsVersionLabel;
        private Button startMappingButton;
        private Label statusLabel;
        private LinkLabel faqAboutLinkLabel;
        private LinkLabel githubLinkLabel;
        private Label faqAboutNagLabel;
        private Label gayLabel;
        private Button refreshListButton;
        private System.Windows.Forms.Timer disconnectMonitorTimer;
    }
}
