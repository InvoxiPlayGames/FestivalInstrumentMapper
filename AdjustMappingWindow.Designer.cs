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
            bindTiltButton = new Button();
            bindWhammyButton = new Button();
            bindSelectButton = new Button();
            bindStartButton = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            label14 = new Label();
            tiltAxisIDNumericUpDown = new NumericUpDown();
            tiltValueLabel = new Label();
            label10 = new Label();
            tiltPressedNumericUpDown = new NumericUpDown();
            tiltUseButtonRadioButton = new RadioButton();
            tiltUseAxisRadioButton = new RadioButton();
            toolStrip = new ToolStrip();
            addProfileToolStripButton = new ToolStripButton();
            removeProfileToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            saveProfileToolStripButton = new ToolStripButton();
            profileToolStripComboBox = new ToolStripComboBox();
            resetAllMappingsToolStripButton = new ToolStripButton();
            refreshProfileToolStripButton = new ToolStripButton();
            groupBox2 = new GroupBox();
            label15 = new Label();
            whammyValueLabel = new Label();
            whammyAxisIDNumericUpDown = new NumericUpDown();
            label11 = new Label();
            whammyPressedNumericUpDown = new NumericUpDown();
            whammyUseButtonRadioButton = new RadioButton();
            whammyUseAxisRadioButton = new RadioButton();
            label16 = new Label();
            label17 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tiltAxisIDNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tiltPressedNumericUpDown).BeginInit();
            toolStrip.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)whammyAxisIDNumericUpDown).BeginInit();
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
            bindGreenFretButton.MouseDown += bindButton_MouseDown;
            // 
            // bindRedFretButton
            // 
            bindRedFretButton.Location = new Point(67, 213);
            bindRedFretButton.Name = "bindRedFretButton";
            bindRedFretButton.Size = new Size(212, 23);
            bindRedFretButton.TabIndex = 8;
            commonToolTip.SetToolTip(bindRedFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindRedFretButton.UseVisualStyleBackColor = true;
            bindRedFretButton.MouseDown += bindButton_MouseDown;
            // 
            // bindYellowFretButton
            // 
            bindYellowFretButton.Location = new Point(67, 242);
            bindYellowFretButton.Name = "bindYellowFretButton";
            bindYellowFretButton.Size = new Size(212, 23);
            bindYellowFretButton.TabIndex = 9;
            commonToolTip.SetToolTip(bindYellowFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindYellowFretButton.UseVisualStyleBackColor = true;
            bindYellowFretButton.MouseDown += bindButton_MouseDown;
            // 
            // bindBlueFretButton
            // 
            bindBlueFretButton.Location = new Point(67, 271);
            bindBlueFretButton.Name = "bindBlueFretButton";
            bindBlueFretButton.Size = new Size(212, 23);
            bindBlueFretButton.TabIndex = 10;
            commonToolTip.SetToolTip(bindBlueFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindBlueFretButton.UseVisualStyleBackColor = true;
            bindBlueFretButton.MouseDown += bindButton_MouseDown;
            // 
            // bindOrangeFretButton
            // 
            bindOrangeFretButton.Location = new Point(67, 300);
            bindOrangeFretButton.Name = "bindOrangeFretButton";
            bindOrangeFretButton.Size = new Size(212, 23);
            bindOrangeFretButton.TabIndex = 11;
            commonToolTip.SetToolTip(bindOrangeFretButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset\r\n");
            bindOrangeFretButton.UseVisualStyleBackColor = true;
            bindOrangeFretButton.MouseDown += bindButton_MouseDown;
            // 
            // bindDPadUpButton
            // 
            bindDPadUpButton.Location = new Point(332, 184);
            bindDPadUpButton.Name = "bindDPadUpButton";
            bindDPadUpButton.Size = new Size(103, 23);
            bindDPadUpButton.TabIndex = 12;
            commonToolTip.SetToolTip(bindDPadUpButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadUpButton.UseVisualStyleBackColor = true;
            bindDPadUpButton.MouseDown += bindButton_MouseDown;
            // 
            // bindDPadDownButton
            // 
            bindDPadDownButton.Location = new Point(332, 213);
            bindDPadDownButton.Name = "bindDPadDownButton";
            bindDPadDownButton.Size = new Size(103, 23);
            bindDPadDownButton.TabIndex = 13;
            commonToolTip.SetToolTip(bindDPadDownButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadDownButton.UseVisualStyleBackColor = true;
            bindDPadDownButton.MouseDown += bindButton_MouseDown;
            // 
            // bindDPadLeftButton
            // 
            bindDPadLeftButton.Location = new Point(332, 242);
            bindDPadLeftButton.Name = "bindDPadLeftButton";
            bindDPadLeftButton.Size = new Size(103, 23);
            bindDPadLeftButton.TabIndex = 14;
            commonToolTip.SetToolTip(bindDPadLeftButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadLeftButton.UseVisualStyleBackColor = true;
            bindDPadLeftButton.MouseDown += bindButton_MouseDown;
            // 
            // bindDPadRightButton
            // 
            bindDPadRightButton.Location = new Point(332, 271);
            bindDPadRightButton.Name = "bindDPadRightButton";
            bindDPadRightButton.Size = new Size(103, 23);
            bindDPadRightButton.TabIndex = 15;
            commonToolTip.SetToolTip(bindDPadRightButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindDPadRightButton.UseVisualStyleBackColor = true;
            bindDPadRightButton.MouseDown += bindButton_MouseDown;
            // 
            // bindTiltButton
            // 
            bindTiltButton.Enabled = false;
            bindTiltButton.Location = new Point(146, 50);
            bindTiltButton.Name = "bindTiltButton";
            bindTiltButton.Size = new Size(164, 23);
            bindTiltButton.TabIndex = 21;
            bindTiltButton.Text = "< disabled >";
            commonToolTip.SetToolTip(bindTiltButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindTiltButton.UseVisualStyleBackColor = true;
            bindTiltButton.MouseDown += bindButton_MouseDown;
            // 
            // bindWhammyButton
            // 
            bindWhammyButton.Enabled = false;
            bindWhammyButton.Location = new Point(146, 50);
            bindWhammyButton.Name = "bindWhammyButton";
            bindWhammyButton.Size = new Size(164, 23);
            bindWhammyButton.TabIndex = 21;
            bindWhammyButton.Text = "< disabled >";
            commonToolTip.SetToolTip(bindWhammyButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindWhammyButton.UseVisualStyleBackColor = true;
            bindWhammyButton.MouseDown += bindButton_MouseDown;
            // 
            // bindSelectButton
            // 
            bindSelectButton.Location = new Point(488, 213);
            bindSelectButton.Name = "bindSelectButton";
            bindSelectButton.Size = new Size(142, 23);
            bindSelectButton.TabIndex = 32;
            commonToolTip.SetToolTip(bindSelectButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindSelectButton.UseVisualStyleBackColor = true;
            bindSelectButton.MouseDown += bindButton_MouseDown;
            // 
            // bindStartButton
            // 
            bindStartButton.Location = new Point(488, 184);
            bindStartButton.Name = "bindStartButton";
            bindStartButton.Size = new Size(142, 23);
            bindStartButton.TabIndex = 31;
            commonToolTip.SetToolTip(bindStartButton, "Left Click - Set Button\r\nRight Click - Add Button\r\nMiddle Click - Reset");
            bindStartButton.UseVisualStyleBackColor = true;
            bindStartButton.MouseDown += bindButton_MouseDown;
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
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(tiltAxisIDNumericUpDown);
            groupBox1.Controls.Add(tiltValueLabel);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(tiltPressedNumericUpDown);
            groupBox1.Controls.Add(bindTiltButton);
            groupBox1.Controls.Add(tiltUseButtonRadioButton);
            groupBox1.Controls.Add(tiltUseAxisRadioButton);
            groupBox1.Location = new Point(10, 329);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(316, 124);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tilt";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(146, 24);
            label14.Name = "label14";
            label14.Size = new Size(46, 15);
            label14.TabIndex = 31;
            label14.Text = "Axis ID:";
            // 
            // tiltAxisIDNumericUpDown
            // 
            tiltAxisIDNumericUpDown.Location = new Point(198, 18);
            tiltAxisIDNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            tiltAxisIDNumericUpDown.Name = "tiltAxisIDNumericUpDown";
            tiltAxisIDNumericUpDown.Size = new Size(112, 23);
            tiltAxisIDNumericUpDown.TabIndex = 31;
            tiltAxisIDNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            tiltAxisIDNumericUpDown.ValueChanged += tiltAxisIDNumericUpDown_ValueChanged;
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
            tiltPressedNumericUpDown.ValueChanged += UpdateAxisButtonValue;
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
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { addProfileToolStripButton, removeProfileToolStripButton, toolStripSeparator1, saveProfileToolStripButton, profileToolStripComboBox, resetAllMappingsToolStripButton, refreshProfileToolStripButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(716, 25);
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
            profileToolStripComboBox.DropDownClosed += profileToolStripComboBox_DropDownClosed;
            profileToolStripComboBox.SelectedIndexChanged += profileToolStripComboBox_SelectedIndexChanged;
            profileToolStripComboBox.KeyDown += profileToolStripComboBox_KeyDown;
            // 
            // resetAllMappingsToolStripButton
            // 
            resetAllMappingsToolStripButton.Alignment = ToolStripItemAlignment.Right;
            resetAllMappingsToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resetAllMappingsToolStripButton.Image = (Image)resources.GetObject("resetAllMappingsToolStripButton.Image");
            resetAllMappingsToolStripButton.ImageTransparentColor = Color.Magenta;
            resetAllMappingsToolStripButton.Name = "resetAllMappingsToolStripButton";
            resetAllMappingsToolStripButton.Size = new Size(112, 22);
            resetAllMappingsToolStripButton.Text = "Reset All Mappings";
            resetAllMappingsToolStripButton.Click += resetAllMappingsToolStripButton_Click;
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
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(whammyValueLabel);
            groupBox2.Controls.Add(whammyAxisIDNumericUpDown);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(whammyPressedNumericUpDown);
            groupBox2.Controls.Add(bindWhammyButton);
            groupBox2.Controls.Add(whammyUseButtonRadioButton);
            groupBox2.Controls.Add(whammyUseAxisRadioButton);
            groupBox2.Location = new Point(332, 329);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 124);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Whammy";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(146, 24);
            label15.Name = "label15";
            label15.Size = new Size(46, 15);
            label15.TabIndex = 32;
            label15.Text = "Axis ID:";
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
            // whammyAxisIDNumericUpDown
            // 
            whammyAxisIDNumericUpDown.Location = new Point(198, 18);
            whammyAxisIDNumericUpDown.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            whammyAxisIDNumericUpDown.Name = "whammyAxisIDNumericUpDown";
            whammyAxisIDNumericUpDown.Size = new Size(112, 23);
            whammyAxisIDNumericUpDown.TabIndex = 33;
            whammyAxisIDNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            whammyAxisIDNumericUpDown.ValueChanged += whammyAxisIDNumericUpDown_ValueChanged;
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
            whammyPressedNumericUpDown.ValueChanged += UpdateAxisButtonValue;
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
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(441, 217);
            label16.Name = "label16";
            label16.Size = new Size(41, 15);
            label16.TabIndex = 34;
            label16.Text = "Select:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(448, 188);
            label17.Name = "label17";
            label17.Size = new Size(34, 15);
            label17.TabIndex = 33;
            label17.Text = "Start:";
            // 
            // AdjustMappingWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(716, 479);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(bindSelectButton);
            Controls.Add(bindStartButton);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdjustMappingWindow";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adjust Input";
            FormClosing += AdjustMappingWindow_FormClosing;
            Load += AdjustMappingWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tiltAxisIDNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)tiltPressedNumericUpDown).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)whammyAxisIDNumericUpDown).EndInit();
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
        private Button bindTiltButton;
        private RadioButton tiltUseButtonRadioButton;
        private RadioButton tiltUseAxisRadioButton;
        private ToolStrip toolStrip;
        private ToolStripButton addProfileToolStripButton;
        private ToolStripButton removeProfileToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton resetAllMappingsToolStripButton;
        private ToolStripButton refreshProfileToolStripButton;
        private ToolStripButton saveProfileToolStripButton;
        private Label label10;
        private NumericUpDown tiltPressedNumericUpDown;
        private GroupBox groupBox2;
        private Label whammyValueLabel;
        private Label label11;
        private NumericUpDown whammyPressedNumericUpDown;
        private Button bindWhammyButton;
        private RadioButton whammyUseButtonRadioButton;
        private RadioButton whammyUseAxisRadioButton;
        private Label tiltValueLabel;
        private ToolStripComboBox profileToolStripComboBox;
        private ToolStripTextBox toolStripTextBox1;
        private Label label14;
        private NumericUpDown tiltAxisIDNumericUpDown;
        private Label label15;
        private NumericUpDown whammyAxisIDNumericUpDown;
        private Label label16;
        private Label label17;
        private Button bindSelectButton;
        private Button bindStartButton;
    }
}