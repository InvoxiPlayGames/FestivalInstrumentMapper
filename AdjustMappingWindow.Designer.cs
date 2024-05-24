namespace FestivalInstrumentMapper
{
    partial class AdjustMappingWindow
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdjustMappingWindow));
            fretPreviewControl = new Controls.FretPreviewControl();
            dPadPreviewControl = new Controls.DPadPreviewControl();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            bindGreenFretButton = new Button();
            commonToolTip = new ToolTip(components);
            bindRedFretButton = new Button();
            bindYellowFretButton = new Button();
            bindBlueFretButton = new Button();
            bindOrangeFretButton = new Button();
            bindDPadUpButton = new Button();
            bindDPadDownButton = new Button();
            bindDPadLeftButton = new Button();
            bindDPadRightButton = new Button();
            tiltBindButton = new Button();
            whammyBindButton = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            tiltValueLabel = new Label();
            label10 = new Label();
            tiltPressedNumericUpDown = new NumericUpDown();
            tiltUseButtonRadioButton = new RadioButton();
            tiltUseAxisRadioButton = new RadioButton();
            axisMapTiltComboBox = new ComboBox();
            toolStrip = new ToolStrip();
            addProfileToolStripButton = new ToolStripButton();
            removeProfileToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            saveProfileToolStripButton = new ToolStripButton();
            profileToolStripComboBox = new ToolStripComboBox();
            toolStripButton2 = new ToolStripButton();
            refreshProfileToolStripButton = new ToolStripButton();
            groupBox2 = new GroupBox();
            whammyValueLabel = new Label();
            label11 = new Label();
            whammyPressedNumericUpDown = new NumericUpDown();
            whammyUseButtonRadioButton = new RadioButton();
            whammyUseAxisRadioButton = new RadioButton();
            axisMapWhammyComboBox = new ComboBox();
            strumbarPreview = new Controls.StrumbarPreview();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tiltPressedNumericUpDown).BeginInit();
            toolStrip.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)whammyPressedNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // fretPreviewControl
            // 
            fretPreviewControl.BlueFretActive = false;
            fretPreviewControl.FretBorderSize = 4;
            fretPreviewControl.FretPadding = 2;
            fretPreviewControl.GreenFretActive = false;
            fretPreviewControl.LeftyFlip = false;
            fretPreviewControl.Location = new Point(12, 28);
            fretPreviewControl.Name = "fretPreviewControl";
            fretPreviewControl.OrangeFretActive = false;
            fretPreviewControl.RedFretActive = false;
            fretPreviewControl.Size = new Size(267, 150);
            fretPreviewControl.TabIndex = 0;
            fretPreviewControl.YellowFretActive = false;
            // 
            // dPadPreviewControl
            // 
            dPadPreviewControl.DPadDown = false;
            dPadPreviewControl.DPadLeft = false;
            dPadPreviewControl.DPadRight = false;
            dPadPreviewControl.DPadUp = false;
            dPadPreviewControl.Location = new Point(285, 28);
            dPadPreviewControl.Name = "dPadPreviewControl";
            dPadPreviewControl.Size = new Size(150, 150);
            dPadPreviewControl.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 188);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 2;
            label1.Text = "Green:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 217);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 3;
            label2.Text = "Red:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 246);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Yellow:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 275);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 5;
            label4.Text = "Blue:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 304);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 6;
            label5.Text = "Orange:";
            // 
            // bindGreenFretButton
            // 
            bindGreenFretButton.Location = new Point(67, 184);
            bindGreenFretButton.Name = "bindGreenFretButton";
            bindGreenFretButton.Size = new Size(212, 23);
            bindGreenFretButton.TabIndex = 7;
            commonToolTip.SetToolTip(bindGreenFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindGreenFretButton.UseVisualStyleBackColor = true;
            bindGreenFretButton.TextChanged += FretButton_TextChanged;
            bindGreenFretButton.MouseClick += bindGreenFretButton_MouseClick;
            // 
            // bindRedFretButton
            // 
            bindRedFretButton.Location = new Point(67, 213);
            bindRedFretButton.Name = "bindRedFretButton";
            bindRedFretButton.Size = new Size(212, 23);
            bindRedFretButton.TabIndex = 8;
            commonToolTip.SetToolTip(bindRedFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindRedFretButton.UseVisualStyleBackColor = true;
            bindRedFretButton.MouseClick += bindRedFretButton_MouseClick;
            // 
            // bindYellowFretButton
            // 
            bindYellowFretButton.Location = new Point(67, 242);
            bindYellowFretButton.Name = "bindYellowFretButton";
            bindYellowFretButton.Size = new Size(212, 23);
            bindYellowFretButton.TabIndex = 9;
            commonToolTip.SetToolTip(bindYellowFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindYellowFretButton.UseVisualStyleBackColor = true;
            bindYellowFretButton.MouseClick += bindYellowFretButton_MouseClick;
            // 
            // bindBlueFretButton
            // 
            bindBlueFretButton.Location = new Point(67, 271);
            bindBlueFretButton.Name = "bindBlueFretButton";
            bindBlueFretButton.Size = new Size(212, 23);
            bindBlueFretButton.TabIndex = 10;
            commonToolTip.SetToolTip(bindBlueFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindBlueFretButton.UseVisualStyleBackColor = true;
            bindBlueFretButton.MouseClick += bindBlueFretButton_MouseClick;
            // 
            // bindOrangeFretButton
            // 
            bindOrangeFretButton.Location = new Point(67, 300);
            bindOrangeFretButton.Name = "bindOrangeFretButton";
            bindOrangeFretButton.Size = new Size(212, 23);
            bindOrangeFretButton.TabIndex = 11;
            commonToolTip.SetToolTip(bindOrangeFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindOrangeFretButton.UseVisualStyleBackColor = true;
            bindOrangeFretButton.MouseClick += bindOrangeFretButton_MouseClick;
            // 
            // bindDPadUpButton
            // 
            bindDPadUpButton.Location = new Point(332, 184);
            bindDPadUpButton.Name = "bindDPadUpButton";
            bindDPadUpButton.Size = new Size(103, 23);
            bindDPadUpButton.TabIndex = 12;
            commonToolTip.SetToolTip(bindDPadUpButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadUpButton.UseVisualStyleBackColor = true;
            bindDPadUpButton.MouseClick += bindDPadUpButton_MouseClick;
            // 
            // bindDPadDownButton
            // 
            bindDPadDownButton.Location = new Point(332, 213);
            bindDPadDownButton.Name = "bindDPadDownButton";
            bindDPadDownButton.Size = new Size(103, 23);
            bindDPadDownButton.TabIndex = 13;
            commonToolTip.SetToolTip(bindDPadDownButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadDownButton.UseVisualStyleBackColor = true;
            bindDPadDownButton.MouseClick += bindDPadDownButton_MouseClick;
            // 
            // bindDPadLeftButton
            // 
            bindDPadLeftButton.Location = new Point(332, 242);
            bindDPadLeftButton.Name = "bindDPadLeftButton";
            bindDPadLeftButton.Size = new Size(103, 23);
            bindDPadLeftButton.TabIndex = 14;
            commonToolTip.SetToolTip(bindDPadLeftButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadLeftButton.UseVisualStyleBackColor = true;
            bindDPadLeftButton.MouseClick += bindDPadLeftButton_MouseClick;
            // 
            // bindDPadRightButton
            // 
            bindDPadRightButton.Location = new Point(332, 271);
            bindDPadRightButton.Name = "bindDPadRightButton";
            bindDPadRightButton.Size = new Size(103, 23);
            bindDPadRightButton.TabIndex = 15;
            commonToolTip.SetToolTip(bindDPadRightButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadRightButton.UseVisualStyleBackColor = true;
            bindDPadRightButton.MouseClick += bindDPadRightButton_MouseClick;
            // 
            // tiltBindButton
            // 
            tiltBindButton.Enabled = false;
            tiltBindButton.Location = new Point(146, 50);
            tiltBindButton.Name = "tiltBindButton";
            tiltBindButton.Size = new Size(164, 23);
            tiltBindButton.TabIndex = 21;
            tiltBindButton.Text = "< disabled >";
            commonToolTip.SetToolTip(tiltBindButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            tiltBindButton.UseVisualStyleBackColor = true;
            tiltBindButton.Click += tiltBindButton_Click;
            // 
            // whammyBindButton
            // 
            whammyBindButton.Enabled = false;
            whammyBindButton.Location = new Point(146, 50);
            whammyBindButton.Name = "whammyBindButton";
            whammyBindButton.Size = new Size(164, 23);
            whammyBindButton.TabIndex = 21;
            whammyBindButton.Text = "< disabled >";
            commonToolTip.SetToolTip(whammyBindButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            whammyBindButton.UseVisualStyleBackColor = true;
            whammyBindButton.Click += whammyBindButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(301, 188);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 16;
            label6.Text = "Up:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(285, 217);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 17;
            label7.Text = "Down:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(296, 246);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 18;
            label8.Text = "Left:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(288, 275);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 19;
            label9.Text = "Right:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tiltValueLabel);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tiltPressedNumericUpDown);
            groupBox1.Controls.Add(tiltBindButton);
            groupBox1.Controls.Add(tiltUseButtonRadioButton);
            groupBox1.Controls.Add(tiltUseAxisRadioButton);
            groupBox1.Controls.Add(axisMapTiltComboBox);
            groupBox1.Location = new Point(10, 329);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 124);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tilt";
            // 
            // tiltValueLabel
            // 
            tiltValueLabel.AutoSize = true;
            tiltValueLabel.Location = new Point(6, 106);
            tiltValueLabel.Name = "tiltValueLabel";
            tiltValueLabel.Size = new Size(13, 15);
            tiltValueLabel.TabIndex = 27;
            tiltValueLabel.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(103, 81);
            label10.Name = "label10";
            label10.Size = new Size(81, 15);
            label10.TabIndex = 25;
            label10.Text = "Pressed Value:";
            // 
            // tiltPressedNumericUpDown
            // 
            tiltPressedNumericUpDown.Enabled = false;
            tiltPressedNumericUpDown.Location = new Point(190, 79);
            tiltPressedNumericUpDown.Name = "tiltPressedNumericUpDown";
            tiltPressedNumericUpDown.Size = new Size(120, 23);
            tiltPressedNumericUpDown.TabIndex = 26;
            tiltPressedNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            tiltPressedNumericUpDown.ValueChanged += tiltPressedNumericUpDown_ValueChanged;
            // 
            // tiltUseButtonRadioButton
            // 
            tiltUseButtonRadioButton.AutoSize = true;
            tiltUseButtonRadioButton.Location = new Point(57, 52);
            tiltUseButtonRadioButton.Name = "tiltUseButtonRadioButton";
            tiltUseButtonRadioButton.Size = new Size(83, 19);
            tiltUseButtonRadioButton.TabIndex = 22;
            tiltUseButtonRadioButton.Text = "Use Button";
            tiltUseButtonRadioButton.UseVisualStyleBackColor = true;
            tiltUseButtonRadioButton.CheckedChanged += tiltUseButtonRadioButton_CheckedChanged;
            // 
            // tiltUseAxisRadioButton
            // 
            tiltUseAxisRadioButton.AutoSize = true;
            tiltUseAxisRadioButton.Checked = true;
            tiltUseAxisRadioButton.Location = new Point(57, 22);
            tiltUseAxisRadioButton.Name = "tiltUseAxisRadioButton";
            tiltUseAxisRadioButton.Size = new Size(69, 19);
            tiltUseAxisRadioButton.TabIndex = 21;
            tiltUseAxisRadioButton.TabStop = true;
            tiltUseAxisRadioButton.Text = "Use Axis";
            tiltUseAxisRadioButton.UseVisualStyleBackColor = true;
            tiltUseAxisRadioButton.CheckedChanged += tiltUseAxisRadioButton_CheckedChanged;
            // 
            // axisMapTiltComboBox
            // 
            axisMapTiltComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            axisMapTiltComboBox.FormattingEnabled = true;
            axisMapTiltComboBox.Items.AddRange(new object[] { "Nothing", "Whammy", "Tilt" });
            axisMapTiltComboBox.Location = new Point(146, 22);
            axisMapTiltComboBox.Name = "axisMapTiltComboBox";
            axisMapTiltComboBox.Size = new Size(164, 23);
            axisMapTiltComboBox.TabIndex = 22;
            axisMapTiltComboBox.SelectedIndexChanged += axisMapTiltComboBox_SelectedIndexChanged;
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { addProfileToolStripButton, removeProfileToolStripButton, toolStripSeparator1, saveProfileToolStripButton, profileToolStripComboBox, toolStripButton2, refreshProfileToolStripButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 24;
            toolStrip.Text = "toolStrip";
            // 
            // addProfileToolStripButton
            // 
            addProfileToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            addProfileToolStripButton.Image = (Image)resources.GetObject("addProfileToolStripButton.Image");
            addProfileToolStripButton.ImageTransparentColor = Color.Magenta;
            addProfileToolStripButton.Name = "addProfileToolStripButton";
            addProfileToolStripButton.Size = new Size(33, 22);
            addProfileToolStripButton.Text = "Add";
            addProfileToolStripButton.Click += addProfileToolStripButton_Click;
            // 
            // removeProfileToolStripButton
            // 
            removeProfileToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            removeProfileToolStripButton.Enabled = false;
            removeProfileToolStripButton.Image = (Image)resources.GetObject("removeProfileToolStripButton.Image");
            removeProfileToolStripButton.ImageTransparentColor = Color.Magenta;
            removeProfileToolStripButton.Name = "removeProfileToolStripButton";
            removeProfileToolStripButton.Size = new Size(54, 22);
            removeProfileToolStripButton.Text = "Remove";
            removeProfileToolStripButton.Click += removeProfileToolStripButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // saveProfileToolStripButton
            // 
            saveProfileToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveProfileToolStripButton.Image = Properties.Resources.Save_16x;
            saveProfileToolStripButton.ImageTransparentColor = Color.Magenta;
            saveProfileToolStripButton.Name = "saveProfileToolStripButton";
            saveProfileToolStripButton.Size = new Size(23, 22);
            saveProfileToolStripButton.Text = "Save Profile";
            saveProfileToolStripButton.Click += saveProfileToolStripButton_Click;
            // 
            // profileToolStripComboBox
            // 
            profileToolStripComboBox.Items.AddRange(new object[] { "< default >" });
            profileToolStripComboBox.Name = "profileToolStripComboBox";
            profileToolStripComboBox.Size = new Size(121, 25);
            profileToolStripComboBox.Text = "< default >";
            profileToolStripComboBox.Click += profileToolStripComboBox_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Alignment = ToolStripItemAlignment.Right;
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(112, 22);
            toolStripButton2.Text = "Reset All Mappings";
            // 
            // refreshProfileToolStripButton
            // 
            refreshProfileToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            refreshProfileToolStripButton.Image = Properties.Resources.Refresh_16x;
            refreshProfileToolStripButton.ImageTransparentColor = Color.Magenta;
            refreshProfileToolStripButton.Name = "refreshProfileToolStripButton";
            refreshProfileToolStripButton.Size = new Size(23, 22);
            refreshProfileToolStripButton.Text = "Refresh Profile List";
            refreshProfileToolStripButton.Click += refreshProfileToolStripButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(whammyValueLabel);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(whammyPressedNumericUpDown);
            groupBox2.Controls.Add(whammyBindButton);
            groupBox2.Controls.Add(whammyUseButtonRadioButton);
            groupBox2.Controls.Add(whammyUseAxisRadioButton);
            groupBox2.Controls.Add(axisMapWhammyComboBox);
            groupBox2.Location = new Point(332, 329);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 124);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Whammy";
            // 
            // whammyValueLabel
            // 
            whammyValueLabel.AutoSize = true;
            whammyValueLabel.Location = new Point(6, 106);
            whammyValueLabel.Name = "whammyValueLabel";
            whammyValueLabel.Size = new Size(13, 15);
            whammyValueLabel.TabIndex = 26;
            whammyValueLabel.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(103, 81);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 25;
            label11.Text = "Pressed Value:";
            // 
            // whammyPressedNumericUpDown
            // 
            whammyPressedNumericUpDown.Enabled = false;
            whammyPressedNumericUpDown.Location = new Point(190, 79);
            whammyPressedNumericUpDown.Name = "whammyPressedNumericUpDown";
            whammyPressedNumericUpDown.Size = new Size(120, 23);
            whammyPressedNumericUpDown.TabIndex = 26;
            whammyPressedNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            whammyPressedNumericUpDown.ValueChanged += whammyPressedNumericUpDown_ValueChanged;
            // 
            // whammyUseButtonRadioButton
            // 
            whammyUseButtonRadioButton.AutoSize = true;
            whammyUseButtonRadioButton.Location = new Point(57, 52);
            whammyUseButtonRadioButton.Name = "whammyUseButtonRadioButton";
            whammyUseButtonRadioButton.Size = new Size(83, 19);
            whammyUseButtonRadioButton.TabIndex = 22;
            whammyUseButtonRadioButton.Text = "Use Button";
            whammyUseButtonRadioButton.UseVisualStyleBackColor = true;
            whammyUseButtonRadioButton.CheckedChanged += whammyUseButtonRadioButton_CheckedChanged;
            // 
            // whammyUseAxisRadioButton
            // 
            whammyUseAxisRadioButton.AutoSize = true;
            whammyUseAxisRadioButton.Checked = true;
            whammyUseAxisRadioButton.Location = new Point(57, 22);
            whammyUseAxisRadioButton.Name = "whammyUseAxisRadioButton";
            whammyUseAxisRadioButton.Size = new Size(69, 19);
            whammyUseAxisRadioButton.TabIndex = 21;
            whammyUseAxisRadioButton.TabStop = true;
            whammyUseAxisRadioButton.Text = "Use Axis";
            whammyUseAxisRadioButton.UseVisualStyleBackColor = true;
            whammyUseAxisRadioButton.CheckedChanged += whammyUseAxisRadioButton_CheckedChanged;
            // 
            // axisMapWhammyComboBox
            // 
            axisMapWhammyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            axisMapWhammyComboBox.FormattingEnabled = true;
            axisMapWhammyComboBox.Items.AddRange(new object[] { "Nothing", "Whammy", "Tilt" });
            axisMapWhammyComboBox.Location = new Point(146, 22);
            axisMapWhammyComboBox.Name = "axisMapWhammyComboBox";
            axisMapWhammyComboBox.Size = new Size(164, 23);
            axisMapWhammyComboBox.TabIndex = 22;
            axisMapWhammyComboBox.SelectedIndexChanged += axisMapWhammyComboBox_SelectedIndexChanged;
            // 
            // strumbarPreview
            // 
            strumbarPreview.Location = new Point(441, 28);
            strumbarPreview.Name = "strumbarPreview";
            strumbarPreview.Size = new Size(290, 96);
            strumbarPreview.StrumbarPosition = StrumbarPosition.Neutral;
            strumbarPreview.TabIndex = 26;
            // 
            // AdjustMappingWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 542);
            Controls.Add(strumbarPreview);
            Controls.Add(groupBox2);
            Controls.Add(toolStrip);
            Controls.Add(groupBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(bindDPadRightButton);
            Controls.Add(bindDPadLeftButton);
            Controls.Add(bindDPadDownButton);
            Controls.Add(bindDPadUpButton);
            Controls.Add(bindOrangeFretButton);
            Controls.Add(bindBlueFretButton);
            Controls.Add(bindYellowFretButton);
            Controls.Add(bindRedFretButton);
            Controls.Add(bindGreenFretButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dPadPreviewControl);
            Controls.Add(fretPreviewControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdjustMappingWindow";
            Text = "Adjust Input";
            FormClosing += AdjustMappingWindow_FormClosing;
            Load += AdjustMappingWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tiltPressedNumericUpDown).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)whammyPressedNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.FretPreviewControl fretPreviewControl;
        private Controls.DPadPreviewControl dPadPreviewControl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button bindGreenFretButton;
        private ToolTip commonToolTip;
        private Button bindRedFretButton;
        private Button bindYellowFretButton;
        private Button bindBlueFretButton;
        private Button bindOrangeFretButton;
        private Button bindDPadUpButton;
        private Button bindDPadDownButton;
        private Button bindDPadLeftButton;
        private Button bindDPadRightButton;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private GroupBox groupBox1;
        private Button tiltBindButton;
        private RadioButton tiltUseButtonRadioButton;
        private RadioButton tiltUseAxisRadioButton;
        private ToolStrip toolStrip;
        private ToolStripButton addProfileToolStripButton;
        private ToolStripButton removeProfileToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton refreshProfileToolStripButton;
        private ToolStripButton saveProfileToolStripButton;
        private Label label10;
        private NumericUpDown tiltPressedNumericUpDown;
        private ComboBox axisMapTiltComboBox;
        private GroupBox groupBox2;
        private Label whammyValueLabel;
        private Label label11;
        private NumericUpDown whammyPressedNumericUpDown;
        private Button whammyBindButton;
        private RadioButton whammyUseButtonRadioButton;
        private RadioButton whammyUseAxisRadioButton;
        private ComboBox axisMapWhammyComboBox;
        private Label tiltValueLabel;
        private ToolStripComboBox profileToolStripComboBox;
        private ToolStripTextBox toolStripTextBox1;
        private Controls.StrumbarPreview strumbarPreview;
    }
}