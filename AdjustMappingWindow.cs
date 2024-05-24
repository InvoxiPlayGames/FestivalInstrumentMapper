using FestivalInstrumentMapper.Controls;
using System;
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

        public AdjustMappingWindow(MapperThread mapperThread)
        {
            this.mapperThread = mapperThread;
            InitializeComponent();
        }

        #region Toolstrip

        private void addProfileToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void removeProfileToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void saveProfileToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void refreshProfileToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripComboBox_Click(object sender, EventArgs e)
        {

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
                    UpdateInputWaiter(e.State.GreenFret, fretPreviewControl.GreenFretActive, ControllerButtons.GreenFret);
                    UpdateInputWaiter(e.State.RedFret, fretPreviewControl.RedFretActive, ControllerButtons.RedFret);
                    UpdateInputWaiter(e.State.YellowFret, fretPreviewControl.YellowFretActive, ControllerButtons.YellowFret);
                    UpdateInputWaiter(e.State.BlueFret, fretPreviewControl.BlueFretActive, ControllerButtons.BlueFret);
                    UpdateInputWaiter(e.State.OrangeFret, fretPreviewControl.OrangeFretActive, ControllerButtons.OrangeFret);
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
                    }

                }

                strumbarPreview.StrumbarPosition = e.State.StrumbarPosition;

                Label[] labels = [ whammyValueLabel, tiltValueLabel ];

                for (int i = 1; i < 3; i++)
                    labels[i - 1].Text = e.State.GetAxisValue(i).ToString();
                
            }));
            translateThreadActive = false;

            return;

            void SetButtonShadeIfPressed(Button button)
            {
                if (button is null)
                    return;
                if (button.Tag is null)
                    return;

                ControllerButtons[] mapping = mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)button.Tag);

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
                    if (button.BackColor != SystemColors.Control)
                        button.BackColor = SystemColors.Control;
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
        }

        #endregion

        private void AdjustMappingWindow_Load(object sender, EventArgs e)
        {
            mapperThread!.BeforeControllerTranslate += MapperThread_BeforeControllerTranslate;
            mapperThread!.AfterControllerTranslate += MapperThread_AfterControllerTranslate;
            // Vultu: Map for invokes later
            bindGreenFretButton.Tag = ControllerButtons.GreenFret;
            bindRedFretButton.Tag = ControllerButtons.RedFret;
            bindYellowFretButton.Tag = ControllerButtons.YellowFret;
            bindBlueFretButton.Tag = ControllerButtons.BlueFret;
            bindOrangeFretButton.Tag = ControllerButtons.OrangeFret;

            axisMapWhammyComboBox.SelectedIndex = 1;
            axisMapTiltComboBox.SelectedIndex = 2;

            SetButtonText(bindGreenFretButton, mapperThread!.ControllerMapping.GreenFret);
            SetButtonText(bindRedFretButton, mapperThread!.ControllerMapping.RedFret);
            SetButtonText(bindYellowFretButton, mapperThread!.ControllerMapping.YellowFret);
            SetButtonText(bindBlueFretButton, mapperThread!.ControllerMapping.BlueFret);
            SetButtonText(bindOrangeFretButton, mapperThread!.ControllerMapping.OrangeFret);

            SetButtonText(bindDPadUpButton, mapperThread!.ControllerMapping.DPadUp);
            SetButtonText(bindDPadDownButton, mapperThread!.ControllerMapping.DPadDown);
            SetButtonText(bindDPadLeftButton, mapperThread!.ControllerMapping.DPadLeft);
            SetButtonText(bindDPadRightButton, mapperThread!.ControllerMapping.DPadRight);


        }


        private void ResetMapping()
        {
            mapperThread!.ControllerMapping.Reset();

            axisMapWhammyComboBox.SelectedIndex = 1;
            axisMapTiltComboBox.SelectedIndex = 2;
            SetButtonText(bindGreenFretButton, mapperThread!.ControllerMapping.GreenFret);
            SetButtonText(bindRedFretButton, mapperThread!.ControllerMapping.RedFret);
            SetButtonText(bindYellowFretButton, mapperThread!.ControllerMapping.YellowFret);
            SetButtonText(bindBlueFretButton, mapperThread!.ControllerMapping.BlueFret);
            SetButtonText(bindOrangeFretButton, mapperThread!.ControllerMapping.OrangeFret);

            SetButtonText(bindDPadUpButton, mapperThread!.ControllerMapping.DPadUp);
            SetButtonText(bindDPadDownButton, mapperThread!.ControllerMapping.DPadDown);
            SetButtonText(bindDPadLeftButton, mapperThread!.ControllerMapping.DPadLeft);
            SetButtonText(bindDPadRightButton, mapperThread!.ControllerMapping.DPadRight);
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

        private void UpdateInputWaiter(bool dst, bool src, ControllerButtons button)
        {
            if (dst == src || buttonWaitingForInput is null)
                return;

            if (buttonWaitingForInput!.Tag is null)
                return;


            bool clearControl = false;

            List<ControllerButtons> temp = mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)buttonWaitingForInput.Tag).ToList();
            // Vultu: Don't add a button if we already bound it to this mapping
            if (!temp.Contains(button))
            {
                temp.Add(button);
                mapperThread!.ControllerMapping.SetButtonMapping((ControllerButtons)buttonWaitingForInput.Tag, temp.ToArray());
                clearControl = true;
                SetButtonText(buttonWaitingForInput!, temp.ToArray());
            }


            if (clearControl)
                buttonWaitingForInput = null;
        }

        private void SetButtonText(Button button, ControllerButtons[] buttonBindings)
        {
            string text = "";
            foreach (var binding in buttonBindings)
                text += $"{binding.ToString()}, ";

            button.Text = text.Substring(0, text.Length - 2);

        }

        #region Fret Buttons
        private void bindGreenFretButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((Button)sender).Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }

            SetButtonText((Button)sender, mapperThread!.ControllerMapping.GreenFret);
        }

        private void bindRedFretButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((Button)sender).Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.RedFret);
        }

        private void bindYellowFretButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((Button)sender).Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.YellowFret);
        }

        private void bindBlueFretButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((Button)sender).Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.BlueFret);
        }

        private void bindOrangeFretButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ((Button)sender).Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.OrangeFret);
        }
        #endregion

        #region DPad Buttons
        private void bindDPadUpButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.DPadUp);
        }

        private void bindDPadDownButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.DPadDown);
        }

        private void bindDPadLeftButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.DPadLeft);
        }

        private void bindDPadRightButton_MouseClick(object sender, MouseEventArgs e)
        {
            SetButtonText((Button)sender, mapperThread!.ControllerMapping.DPadRight);
        }

        #endregion

        private void FretButton_TextChanged(object sender, EventArgs e)
        {

        }


        #region Axis Shared
        private void UpdateAxisControls(RadioButton radioButton, Button bindButton, NumericUpDown numericUpDown, ComboBox comboBox)
        {
            bindButton.Enabled = radioButton.Checked;

            numericUpDown.Enabled = radioButton.Checked;

            comboBox.Enabled = !radioButton.Checked;

            if (bindButton.Enabled)
            {
                bindButton.Text = string.Empty;
            }
            else
                bindButton.Text = "< disabled >";
        }

        #endregion

        #region Tilt Groupbox


        private void tiltUseAxisRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(tiltUseButtonRadioButton, tiltBindButton, tiltPressedNumericUpDown, axisMapTiltComboBox);
        }

        private void tiltUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(tiltUseButtonRadioButton, tiltBindButton, tiltPressedNumericUpDown, axisMapTiltComboBox);
        }

        private void axisMapTiltComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapperThread!.ControllerMapping.TiltInfo.AxisIndex = (byte)((ComboBox)sender).SelectedIndex;
        }

        private void tiltBindButton_Click(object sender, EventArgs e)
        {

        }

        private void tiltPressedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Whammy Groupbox

        private void whammyUseAxisRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(whammyUseButtonRadioButton, whammyBindButton, whammyPressedNumericUpDown, axisMapWhammyComboBox);
        }

        private void whammyUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(whammyUseButtonRadioButton, whammyBindButton, whammyPressedNumericUpDown, axisMapWhammyComboBox);
        }

        private void axisMapWhammyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapperThread!.ControllerMapping.WhammyInfo.AxisIndex = (byte)((ComboBox)sender).SelectedIndex;
        }

        private void whammyBindButton_Click(object sender, EventArgs e)
        {

        }

        private void whammyPressedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
