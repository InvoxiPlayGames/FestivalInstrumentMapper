using FestivalInstrumentMapper.Controls;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestivalInstrumentMapper
{
    internal partial class AdjustMappingWindow : Form
    {
        private MapperThread? mapperThread = null;
        private volatile Button? buttonWaitingForInput = null;

        private volatile bool closing = false;
        private volatile bool translateThreadActive = false;

        private volatile bool prev_StartState = false;
        private volatile bool prev_SelectState = false;

        private bool ignoreTextUpdate = false;
        private bool dropDownClosed = false;

        public AdjustMappingWindow(MapperThread mapperThread)
        {
            this.mapperThread = mapperThread;
            InitializeComponent();
        }

        #region Toolstrip

        private void RefreshProfileList()
        {
            ignoreTextUpdate = true;

            string currentProfile = profileToolStripComboBox.Text;

            if (!Directory.Exists("Profile"))
                Directory.CreateDirectory("Profile");

            profileToolStripComboBox.Items.Clear();

            profileToolStripComboBox.Items.Add("< default >");

            foreach (var file in Directory.GetFiles("Profile", "*.json"))
            {
                var name = file.Substring("Profile\\".Length);

                profileToolStripComboBox.Items.Add(name.Substring(0, name.Length - ".json".Length));
            }

            if (profileToolStripComboBox.Items.Contains(currentProfile))
                profileToolStripComboBox.SelectedItem = currentProfile;
            else
                profileToolStripComboBox.SelectedItem = "< default >";

            ignoreTextUpdate = false;
        }

        private string GetNextValidName()
        {
            if (!Directory.Exists("Profile"))
                Directory.CreateDirectory("Profile");

            var files = Directory.GetFiles("Profile", "*.json");

            string name = "New Profile";

            int indexer = 1;

            while (true)
            {
                bool found = true;
                foreach (var file in files)
                {
                    if ($"{name.ToLower().Trim()}.json" == file.Substring("Profile\\".Length).ToLower())
                    {
                        name = $"New Profile {indexer++}";
                        found = false;
                        break;
                    }
                }

                if (found)
                    break;
            }

            return name;
        }

        private void addProfileToolStripButton_Click(object sender, EventArgs e)
        {
            var name = GetNextValidName();
            profileToolStripComboBox.Items.Add(name);
            ControllerMapping.Save(name, new ControllerMapping());
        }

        private void removeProfileToolStripButton_Click(object sender, EventArgs e)
        {
            if (((string)profileToolStripComboBox!.SelectedItem!) == "< default >")
                removeProfileToolStripButton.Enabled = false;

            if (MessageBox.Show(
                $"Are you sure you want to delete {profileToolStripComboBox.SelectedItem}?\n" +
                $"Your profile will be lost forver! (A really long time!)",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                File.Delete($"Profile\\{profileToolStripComboBox.SelectedItem}.json");
                RefreshProfileList();
            }
        }

        private void resetAllMappingsToolStripButton_Click(object sender, EventArgs e)
        {
            ResetMapping();
        }

        private void saveProfileToolStripButton_Click(object sender, EventArgs e)
        {
            if (mapperThread is null || profileToolStripComboBox.SelectedIndex <= 0)
                return;

            ControllerMapping.Save((string)profileToolStripComboBox.Items[profileToolStripComboBox.SelectedIndex]!, mapperThread.ControllerMapping); ;
        }

        private void refreshProfileToolStripButton_Click(object sender, EventArgs e)
        {
            RefreshProfileList();
        }
        private void profileToolStripComboBox_DropDownClosed(object sender, EventArgs e)
        {
            dropDownClosed = true;

        }

        private void profileToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            if (mapperThread is null)
                return;

            if (dropDownClosed)
            {
                dropDownClosed = false;
                if (profileToolStripComboBox.Text == "< default >")
                {
                    if (mapperThread is not null)
                        mapperThread.ControllerMapping = new ControllerMapping();
                    return;
                }

                var files = Directory.GetFiles("Profile", "*.json");

                if (!File.Exists($"Profile\\{profileToolStripComboBox.SelectedItem}.json"))
                {
                    MessageBox.Show($"Unable to find {profileToolStripComboBox.SelectedItem}. It will be removed from the list.");

                    profileToolStripComboBox.SelectedItem = "< default >";
                    RefreshProfileList();
                }

                return;
            }

            if (ignoreTextUpdate)
                return;

        }

        private int lastSelectedIndex = 0;

        private void profileToolStripComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (mapperThread is null)
                return;
            if (lastSelectedIndex == 0)
            {
                profileToolStripComboBox.Text = "< default >";
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                var before = profileToolStripComboBox.Items[lastSelectedIndex];
                var after = profileToolStripComboBox.Text;

                File.Delete($"Profile\\{before}.json");

                ControllerMapping.Save(after, mapperThread!.ControllerMapping);
                RefreshProfileList();
            }
        }
        private void profileToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mapperThread is null)
                return;

            if (profileToolStripComboBox.SelectedIndex != -1)
                lastSelectedIndex = profileToolStripComboBox.SelectedIndex;

            removeProfileToolStripButton.Enabled = profileToolStripComboBox.SelectedIndex >= 1;

            if (profileToolStripComboBox.SelectedIndex == 0)
                mapperThread.ControllerMapping = new();
            else
                mapperThread.ControllerMapping = ControllerMapping.Load(((string)profileToolStripComboBox!.SelectedItem!))!;

            bool enabled = profileToolStripComboBox.SelectedIndex != 0;
            bindGreenFretButton.Enabled = enabled;
            bindRedFretButton.Enabled = enabled;
            bindYellowFretButton.Enabled = enabled;
            bindBlueFretButton.Enabled = enabled;
            bindOrangeFretButton.Enabled = enabled;

            bindDPadUpButton.Enabled = enabled;
            bindDPadDownButton.Enabled = enabled;
            bindDPadLeftButton.Enabled = enabled;
            bindDPadRightButton.Enabled = enabled;

            bindStartButton.Enabled = enabled;
            bindSelectButton.Enabled = enabled;

            ignoreAxisUpdates = true;

            bindWhammyButton.Enabled = enabled;
            whammyAxisIDNumericUpDown.Enabled = enabled;
            whammyPressedNumericUpDown.Enabled = enabled;
            whammyUseAxisRadioButton.Enabled = enabled;
            whammyUseButtonRadioButton.Enabled = enabled;


            bindTiltButton.Enabled = enabled;
            tiltAxisIDNumericUpDown.Enabled = enabled;
            tiltPressedNumericUpDown.Enabled = enabled;
            tiltUseAxisRadioButton.Enabled = enabled;
            tiltUseButtonRadioButton.Enabled = enabled;

            ignoreAxisUpdates = false;

            saveProfileToolStripButton.Enabled = enabled;

            SetButtonTexts();
        }

        #endregion

        #region Mapper Thread Events

        private void MapperThread_BeforeControllerTranslate(object? sender, MapperThread.GuitarEventArgs e)
        {
            if (closing)
                return;

            translateThreadActive = true;

            if (buttonWaitingForInput is not null)
            {
                buttonWaitingForInput?.Invoke(new MethodInvoker(delegate
                {
                    for (int button = 0; button < (int)ControllerButtons.COUNT; button++)
                        if (e.State.GetButtonState((ControllerButtons)button))
                            UpdateInputWaiter((ControllerButtons)button);
                }));
            }

            // Highlight/Shade Pressed Buttons
            BeginInvoke(new MethodInvoker(delegate
            {
                // List<ControllerButtons> activeFrets = [];

                //fretPreviewControl.SetFrets(activeFrets);

                foreach (var control in Controls)
                {
                    if (control.GetType() != typeof(Button))
                        continue;

                    Button buttonControl = (Button)control;
                    if (buttonControl.Tag is null)
                        continue;

                    if (buttonControl!.Tag!.GetType() == typeof(ControllerButtons))
                    {
                        SetButtonShadeIfPressed(bindGreenFretButton);
                        SetButtonShadeIfPressed(bindRedFretButton);
                        SetButtonShadeIfPressed(bindYellowFretButton);
                        SetButtonShadeIfPressed(bindBlueFretButton);
                        SetButtonShadeIfPressed(bindOrangeFretButton);

                        SetButtonShadeIfPressed(bindDPadUpButton);
                        SetButtonShadeIfPressed(bindDPadDownButton);
                        SetButtonShadeIfPressed(bindDPadLeftButton);
                        SetButtonShadeIfPressed(bindDPadRightButton);

                        SetButtonShadeIfPressed(bindStartButton);
                        SetButtonShadeIfPressed(bindSelectButton);

                        SetButtonShadeIfPressed(bindWhammyButton);
                        SetButtonShadeIfPressed(bindTiltButton);
                    }

                    Label[] labels = [whammyValueLabel, tiltValueLabel];

                    for (int i = 0; i < 2; i++)
                        labels[i].Text = e.State.GetAxisValue((ControllerAxis)i).ToString();
                }

            }));
            translateThreadActive = false;

            return;

            void SetButtonShadeIfPressed(Button button)
            {
                if (button is null)
                    return;
                if (button.Tag is null)
                    return;
                if (!button.Enabled)
                    return;

                ControllerButtons[] mapping = Array.Empty<ControllerButtons>();
                if (button.Tag is ControllerButtons)
                    mapping = mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)button.Tag);
                else if (button.Tag is ControllerAxis)
                    mapping = mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)button.Tag)!.Buttons;


                bool shade = false;
                foreach (var controllerButton in mapping)
                {
                    if (shade)
                        break;
                    shade = e.State.GetButtonState(controllerButton);
                }
                if (shade)
                {
                    if (button.BackColor != SystemColors.ControlDark)
                        button.BackColor = SystemColors.ControlDark;
                }
                else
                {
                    if (button.BackColor != SystemColors.ButtonHighlight)
                        button.BackColor = SystemColors.ButtonHighlight;
                }

            }
        }

        private void MapperThread_AfterControllerTranslate(object? sender, MapperThread.GuitarEventArgs e)
        {
            fretPreviewControl.GreenFretActive = e.State.GreenFret;
            fretPreviewControl.RedFretActive = e.State.RedFret;
            fretPreviewControl.YellowFretActive = e.State.YellowFret;
            fretPreviewControl.BlueFretActive = e.State.BlueFret;
            fretPreviewControl.OrangeFretActive = e.State.OrangeFret;

            dPadPreviewControl.DPadUp = e.State.DPadUp;
            dPadPreviewControl.DPadDown = e.State.DPadDown;
            dPadPreviewControl.DPadLeft = e.State.DPadLeft;
            dPadPreviewControl.DPadRight = e.State.DPadRight;

            prev_StartState = e.State.Start;
            prev_SelectState = e.State.Select;
        }

        #endregion

        private void AdjustMappingWindow_Load(object sender, EventArgs e)
        {
            RefreshProfileList();

            mapperThread!.BeforeControllerTranslate += MapperThread_BeforeControllerTranslate;
            mapperThread!.AfterControllerTranslate += MapperThread_AfterControllerTranslate;

            // Vultu: Map for invokes later
            bindGreenFretButton.Tag = ControllerButtons.GreenFret;
            bindRedFretButton.Tag = ControllerButtons.RedFret;
            bindYellowFretButton.Tag = ControllerButtons.YellowFret;
            bindBlueFretButton.Tag = ControllerButtons.BlueFret;
            bindOrangeFretButton.Tag = ControllerButtons.OrangeFret;

            bindDPadUpButton.Tag = ControllerButtons.DPadUp;
            bindDPadDownButton.Tag = ControllerButtons.DPadDown;
            bindDPadLeftButton.Tag = ControllerButtons.DPadLeft;
            bindDPadRightButton.Tag = ControllerButtons.DPadRight;

            bindStartButton.Tag = ControllerButtons.Start;
            bindSelectButton.Tag = ControllerButtons.Select;

            bindWhammyButton.Tag = ControllerAxis.Whammy;
            bindTiltButton.Tag = ControllerAxis.Tilt;

            whammyAxisIDNumericUpDown.Tag = ControllerAxis.Whammy;
            tiltAxisIDNumericUpDown.Tag = ControllerAxis.Tilt;

            whammyPressedNumericUpDown.Tag = ControllerAxis.Whammy;
            tiltPressedNumericUpDown.Tag = ControllerAxis.Tilt;

            whammyAxisIDNumericUpDown.Value = (int)ControllerAxis.Whammy;
            tiltAxisIDNumericUpDown.Value = (int)ControllerAxis.Tilt;

            RefreshProfileList();

            SetButtonTexts();
        }

        private void ResetMapping()
        {
            mapperThread!.ControllerMapping = new();

            // whammyAxisIDNumericUpDown.Value = (int)ControllerAxis.Whammy;
            // tiltAxisIDNumericUpDown.Value = (int)ControllerAxis.Tilt;

            SetButtonTexts();
        }

        private void SetButtonText(Control control, ControllerButtons[] buttonBindings)
        {
            if (!control.Enabled)
            {
                control.Text = "< disabled >";
                return;
            }

            string text = "";
            foreach (var binding in buttonBindings)
                text += $"{binding.ToString()}, ";
           
            if (buttonBindings.Length == 0)
            {
                control.Text = "< not mapped >";
                commonToolTip.SetToolTip(control, text);
            }
            else
            {
                control.Text = text.Substring(0, text.Length - 2);
                commonToolTip.SetToolTip(control, text.Substring(0, text.Length - 2));
            }
        }

        private bool ignoreAxisUpdates = false;

        private void SetButtonTexts()
        {
            ignoreAxisUpdates = true;
            SetButtonText(bindGreenFretButton, mapperThread!.ControllerMapping.GreenFret);
            SetButtonText(bindRedFretButton, mapperThread!.ControllerMapping.RedFret);
            SetButtonText(bindYellowFretButton, mapperThread!.ControllerMapping.YellowFret);
            SetButtonText(bindBlueFretButton, mapperThread!.ControllerMapping.BlueFret);
            SetButtonText(bindOrangeFretButton, mapperThread!.ControllerMapping.OrangeFret);

            SetButtonText(bindDPadUpButton, mapperThread!.ControllerMapping.DPadUp);
            SetButtonText(bindDPadDownButton, mapperThread!.ControllerMapping.DPadDown);
            SetButtonText(bindDPadLeftButton, mapperThread!.ControllerMapping.DPadLeft);
            SetButtonText(bindDPadRightButton, mapperThread!.ControllerMapping.DPadRight);

            SetButtonText(bindStartButton, mapperThread!.ControllerMapping.Start);
            SetButtonText(bindSelectButton, mapperThread!.ControllerMapping.Select);

            var whammyAxisInfo = mapperThread!.ControllerMapping.GetAxisMapping(ControllerAxis.Whammy)!;
            SetButtonText(bindWhammyButton, whammyAxisInfo.Buttons);
            whammyUseAxisRadioButton.Checked = whammyAxisInfo.MapToAxis;
            whammyUseButtonRadioButton.Checked = !whammyAxisInfo.MapToAxis;

            whammyAxisIDNumericUpDown.Value = (int)whammyAxisInfo.AxisIndex;
            whammyPressedNumericUpDown.Value = whammyAxisInfo.PressedValue;

            var tiltAxisInfo = mapperThread!.ControllerMapping.GetAxisMapping(ControllerAxis.Tilt)!;
            SetButtonText(bindTiltButton, tiltAxisInfo.Buttons);
            tiltUseAxisRadioButton.Checked = tiltAxisInfo.MapToAxis;
            tiltUseButtonRadioButton.Checked = !tiltAxisInfo.MapToAxis;

            tiltAxisIDNumericUpDown.Value = (int)tiltAxisInfo.AxisIndex;
            tiltPressedNumericUpDown.Value = tiltAxisInfo.PressedValue;

            UpdateAxisControls(whammyUseButtonRadioButton, bindWhammyButton, whammyPressedNumericUpDown, whammyAxisIDNumericUpDown);
            UpdateAxisControls(tiltUseButtonRadioButton, bindTiltButton, tiltPressedNumericUpDown, tiltAxisIDNumericUpDown);

            ignoreAxisUpdates = false;
        }

        private void AdjustMappingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;

            while (translateThreadActive)
            {

            }

            if (mapperThread is not null)
            {
                mapperThread!.BeforeControllerTranslate += MapperThread_BeforeControllerTranslate;
                mapperThread!.AfterControllerTranslate += MapperThread_AfterControllerTranslate;
            }

            return;
        }

        private void UpdateInputWaiter(ControllerButtons button)
        {
            if (buttonWaitingForInput is null)
                return;

            if (buttonWaitingForInput!.Tag is null)
                return;


            bool clearControl = false;
            List<ControllerButtons> buttonList = new();

            if (buttonWaitingForInput.Tag is ControllerButtons)
                buttonList = mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)buttonWaitingForInput.Tag).ToList();
            else if (buttonWaitingForInput.Tag is ControllerAxis)
                buttonList = mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)buttonWaitingForInput.Tag)!.Buttons.ToList();

            // Vultu: Don't add a button if we already bound it to this mapping
            if (!buttonList.Contains(button))
            {
                buttonList.Add(button);
                if (buttonWaitingForInput.Tag is ControllerButtons)
                    mapperThread!.ControllerMapping.SetButtonMapping((ControllerButtons)buttonWaitingForInput.Tag, buttonList.ToArray());
                else if (buttonWaitingForInput.Tag is ControllerAxis)
                    mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)buttonWaitingForInput.Tag)!.Buttons = buttonList.ToArray();

                clearControl = true;
                SetButtonText(buttonWaitingForInput!, buttonList.ToArray());
            }

            if (clearControl)
                buttonWaitingForInput = null;
        }

        private void bindButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button source = sender as Button;
            if (source is null)
                return;
            if (source.Tag is null)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    source.Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    if (source.Tag is ControllerButtons)
                        mapperThread!.ControllerMapping.SetButtonMapping((ControllerButtons)source.Tag, Array.Empty<ControllerButtons>());
                    else if (source.Tag is ControllerAxis)
                        mapperThread!.ControllerMapping.SetButtonMapping((ControllerAxis)source.Tag, Array.Empty<ControllerButtons>());
                    return;
                case MouseButtons.Right:
                    source.Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Middle:
                    source.Text = "< not mapped >";
                    if (source.Tag is ControllerButtons)
                        mapperThread!.ControllerMapping.SetButtonMapping((ControllerButtons)source.Tag, Array.Empty<ControllerButtons>());
                    else if (source.Tag is ControllerAxis)
                        mapperThread!.ControllerMapping.SetButtonMapping((ControllerAxis)source.Tag, Array.Empty<ControllerButtons>());
                    return;
            }



            if (source.Tag is ControllerButtons)
                SetButtonText(source, mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)source.Tag));
            else if (source.Tag is ControllerAxis)
                SetButtonText(source, mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)source.Tag)!.Buttons);
        }

        #region Axis Shared
        private void UpdateAxisControls(RadioButton radioButton, Button bindButton, NumericUpDown numericUpDown, NumericUpDown axisIDNumericUpDown)
        {
            if (profileToolStripComboBox.SelectedIndex == 0)
                return;

            bindButton.Enabled = radioButton.Checked;

            numericUpDown.Enabled = radioButton.Checked;

            axisIDNumericUpDown.Enabled = !radioButton.Checked;

            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)axisIDNumericUpDown.Value)!.PressedValue = (byte)Math.Clamp(numericUpDown.Value, 0, 100);

            SetButtonText(bindButton, mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)axisIDNumericUpDown.Value)!.Buttons);
        }

        private void UpdateAxisButtonValue(object sender, EventArgs e)
        {
            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)(((NumericUpDown)sender).Tag)!)!.PressedValue = (byte)((NumericUpDown)sender).Value;
        }
        #endregion

        #region Tilt Groupbox

        private void tiltUseAxisRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)tiltAxisIDNumericUpDown.Value)!.MapToAxis = true;

            UpdateAxisControls(tiltUseButtonRadioButton, bindTiltButton, tiltPressedNumericUpDown, tiltAxisIDNumericUpDown);
        }

        private void tiltUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)tiltAxisIDNumericUpDown.Value)!.MapToAxis = false;

            UpdateAxisControls(tiltUseButtonRadioButton, bindTiltButton, tiltPressedNumericUpDown, tiltAxisIDNumericUpDown);
        }

        private void tiltAxisIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.TiltInfo.AxisIndex = (ControllerAxis)((NumericUpDown)sender).Value;
        }

        #endregion

        #region Whammy Groupbox

        private void whammyUseAxisRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)whammyAxisIDNumericUpDown.Value)!.MapToAxis = true;

            UpdateAxisControls(whammyUseButtonRadioButton, bindWhammyButton, whammyPressedNumericUpDown, whammyAxisIDNumericUpDown);
        }

        private void whammyUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.GetAxisMapping((ControllerAxis)whammyAxisIDNumericUpDown.Value)!.MapToAxis = false;

            UpdateAxisControls(whammyUseButtonRadioButton, bindWhammyButton, whammyPressedNumericUpDown, whammyAxisIDNumericUpDown);
        }
        private void whammyAxisIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreAxisUpdates)
                return;

            mapperThread!.ControllerMapping.WhammyInfo.AxisIndex = (ControllerAxis)((NumericUpDown)sender).Value;
        }

        #endregion
    }
}
