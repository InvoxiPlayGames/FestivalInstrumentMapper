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

                    UpdateInputWaiter(e.State.DPadUp, dPadPreviewControl.DPadUp, ControllerButtons.DPadUp);
                    UpdateInputWaiter(e.State.DPadDown, dPadPreviewControl.DPadDown, ControllerButtons.DPadDown);
                    UpdateInputWaiter(e.State.DPadLeft, dPadPreviewControl.DPadLeft, ControllerButtons.DPadLeft);
                    UpdateInputWaiter(e.State.DPadRight, dPadPreviewControl.DPadRight, ControllerButtons.DPadRight);

                    UpdateInputWaiter(e.State.Start, prev_StartState, ControllerButtons.Start);
                    UpdateInputWaiter(e.State.Start, prev_SelectState, ControllerButtons.Select);
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
                    }

                    Label[] labels = [whammyValueLabel, tiltValueLabel];

                    for (int i = 1; i < 3; i++)
                        labels[i - 1].Text = e.State.GetAxisValue(i).ToString();
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

            prev_StartState = e.State.Start;
            prev_SelectState = e.State.Select;
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

            bindDPadUpButton.Tag = ControllerButtons.DPadUp;
            bindDPadDownButton.Tag = ControllerButtons.DPadDown;
            bindDPadLeftButton.Tag = ControllerButtons.DPadLeft;
            bindDPadRightButton.Tag = ControllerButtons.DPadRight;

            bindStartButton.Tag = ControllerButtons.Start;
            bindSelectButton.Tag = ControllerButtons.Select;


            whammyAxisIDNumericUpDown.Value = ControllerMapping.DefaultWhammyAxisIndex;
            tiltAxisIDNumericUpDown.Value = ControllerMapping.DefaultTiltAxisIndex;

            SetButtonTexts();
        }


        private void ResetMapping()
        {
            mapperThread!.ControllerMapping.Reset();

            whammyAxisIDNumericUpDown.Value = ControllerMapping.DefaultWhammyAxisIndex;
            tiltAxisIDNumericUpDown.Value = ControllerMapping.DefaultTiltAxisIndex;
            SetButtonTexts();
        }
        private void SetButtonText(Button button, ControllerButtons[] buttonBindings)
        {
            string text = "";
            foreach (var binding in buttonBindings)
                text += $"{binding.ToString()}, ";

            button.Text = text.Substring(0, text.Length - 2);

        }

        private void SetButtonTexts()
        {
            tiltAxisIDNumericUpDown.Value = ControllerMapping.DefaultTiltAxisIndex;

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

        private void bindButton_MouseClick(object sender, MouseEventArgs e)
        {
            Button source = sender as Button;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    source.Text = "Press any Button...";
                    buttonWaitingForInput = (Button)sender;
                    return;
                case MouseButtons.Right:
                    break;
                case MouseButtons.Middle:
                    break;
            }


            if (source.Tag is null)
                return;
            if (source.Tag is ControllerButtons)
                SetButtonText(source, mapperThread!.ControllerMapping.GetButtonMapping((ControllerButtons)source.Tag));
        }


        #region Axis Shared
        private void UpdateAxisControls(RadioButton radioButton, Button bindButton, NumericUpDown numericUpDown, NumericUpDown axisIDNumericUpDown)
        {
            bindButton.Enabled = radioButton.Checked;

            numericUpDown.Enabled = radioButton.Checked;

            axisIDNumericUpDown.Enabled = !radioButton.Checked;

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
            UpdateAxisControls(tiltUseButtonRadioButton, tiltBindButton, tiltPressedNumericUpDown, tiltAxisIDNumericUpDown);
        }

        private void tiltUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(tiltUseButtonRadioButton, tiltBindButton, tiltPressedNumericUpDown, tiltAxisIDNumericUpDown);
        }

        private void tiltAxisIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mapperThread!.ControllerMapping.TiltInfo.AxisIndex = (byte)((NumericUpDown)sender).Value;
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
            UpdateAxisControls(whammyUseButtonRadioButton, whammyBindButton, whammyPressedNumericUpDown, whammyAxisIDNumericUpDown);
        }

        private void whammyUseButtonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisControls(whammyUseButtonRadioButton, whammyBindButton, whammyPressedNumericUpDown, whammyAxisIDNumericUpDown);
        }
        private void whammyAxisIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            mapperThread!.ControllerMapping.WhammyInfo.AxisIndex = (byte)((NumericUpDown)sender).Value;
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
