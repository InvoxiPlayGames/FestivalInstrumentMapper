using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    public enum ControllerButtons
    {
        GreenFret,
        RedFret,
        YellowFret,
        BlueFret,
        OrangeFret,

        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight,

        Start,
        Select,

        COUNT // KEEP LAST
    }

    public enum ControllerAxis
    {
        Whammy,
        Tilt,

        COUNT // KEEP LAST
    }

    /// <summary>
    /// Object representing the state of the guitar at any given time
    /// </summary>
    public class GuitarState
    {
        public bool GreenFret = false;
        public bool RedFret = false;
        public bool YellowFret = false;
        public bool BlueFret = false;
        public bool OrangeFret = false;

        public bool DPadUp = false;
        public bool DPadDown = false;
        public bool DPadLeft = false;
        public bool DPadRight = false;

        public bool Start = false;
        public bool Select = false;

        public float Whammy = 0;
        public float Tilt = 0;

        public void Reset()
        {
            GreenFret = false;
            RedFret = false;
            YellowFret = false;
            BlueFret = false;
            OrangeFret = false;

            DPadUp = false;
            DPadDown = false;
            DPadLeft = false;
            DPadRight = false;

            Start = false;
            Select = false;

            Whammy = 0;
            Tilt = 0;
        }

        public void Translate(ControllerMapping mapping)
        {
            // stackalloc for perf
            Span<bool> buttonStates = stackalloc bool[11];

            Span<float> axis = [ Whammy, Tilt ];

            buttonStates[0] = GreenFret;
            buttonStates[1] = RedFret;
            buttonStates[2] = YellowFret;
            buttonStates[3] = BlueFret;
            buttonStates[4] = OrangeFret;
            buttonStates[5] = DPadUp;
            buttonStates[6] = DPadDown;
            buttonStates[7] = DPadLeft;
            buttonStates[8] = DPadRight;

            buttonStates[9] = Start;
            buttonStates[10] = Select;

            Reset();


            // Translate Buttons
            for (var i  = 0; i < buttonStates.Length; i++)
            {
                ControllerButtons dstButton = (ControllerButtons)i;

                ControllerButtons[] dstMappedButtons = mapping.GetButtonMapping(dstButton);

                foreach (var dstMappedButton in dstMappedButtons)
                {
                    if (buttonStates[(int)dstMappedButton])
                        SetButton(dstButton);
                }
            }

            // Translate Axis
            for (int i = 0; i < (int)ControllerAxis.COUNT; i++) // Iterate through each Axis
            {
                var dstAxis = mapping.GetAxisMapping((ControllerAxis)(i));

                if (dstAxis is null)
                    continue;

                if (dstAxis.MapToAxis)
                    SetAxisValue((ControllerAxis)i, axis[(int)dstAxis.AxisIndex]);
                else
                {
                    ControllerButtons[] dstMappedButtons = mapping.GetAxisMapping((ControllerAxis)i)!.Buttons!;

                    foreach (var dstMappedButton in dstMappedButtons)
                    {
                        if (buttonStates[(int)dstMappedButton])
                            SetAxisValue((ControllerAxis)i, (float)dstAxis.PressedValue / 100.0f);
                    }
                }
            }


        }

        public void SetAxisValue(ControllerAxis axis, float value)
        {
            switch (axis)
            {
                case ControllerAxis.Whammy:
                    Whammy = value;
                    break;
                case ControllerAxis.Tilt:
                    Tilt = value;
                    break;
            }
            
        }
        public float GetAxisValue(ControllerAxis axis)
        {
            switch (axis)
            {
                case ControllerAxis.Whammy:
                    return Whammy;
                case ControllerAxis.Tilt:
                    return Tilt;
            }
            return 0;
        }

        public void Deserialize(ReadOnlySpan<byte> data)
        {
            GreenFret = (data[0] & 0b00010000) != 0;
            RedFret = (data[0] & 0b00100000) != 0;
            YellowFret = (data[0] & 0b10000000) != 0;
            BlueFret = (data[0] & 0b01000000) != 0;
            OrangeFret = (data[1] & 0b00010000) != 0;

            Start = (data[0] & 0b00000100) != 0;
            Select = (data[0] & 0b00001000) != 0;

            DPadUp = (data[1] & 0b00000001) != 0;
            DPadDown = (data[1] & 0b00000010) != 0;
            DPadLeft = (data[1] & 0b00000100) != 0;
            DPadRight = (data[1] & 0b00001000) != 0;

            Whammy = (float)data[2] / (float)0xFF;
            Tilt = (float)data[3] / (float)0xFF;
        }
        public void Serialize(ref Span<byte> data)
        {
            if (data.Length != 0xE)
                throw new Exception($"Unable to serialize controller data! Expected size of 0xE but got size of {data.Length.ToString("X")}");

            if (GreenFret)
                data[0] |= 0b00010000;
            if (RedFret)
                data[0] |= 0b00100000;
            if (YellowFret)
                data[0] |= 0b10000000;
            if (BlueFret)
                data[0] |= 0b01000000;
            if (OrangeFret)
                data[1] |= 0b00010000;

            if (Start)
                data[0] |= 0b00000100;
            if (Select)
                data[0] |= 0b00001000;

            if (DPadUp)
                data[1] |= 0b00000001;
            if (DPadDown)
                data[1] |= 0b00000010;
            if (DPadLeft)
                data[1] |= 0b00000100;
            if (DPadRight)
                data[1] |= 0b00001000;

            data[2] = (byte)(Whammy * (float)0xFF);
            data[3] = (byte)(Tilt * (float)0xFF);
        }

        public void SetButton(ControllerButtons button)
        {
            switch (button)
            {
                case ControllerButtons.GreenFret:
                    GreenFret = true;
                    break;
                case ControllerButtons.RedFret:
                    RedFret = true;
                    break;
                case ControllerButtons.YellowFret:
                    YellowFret = true;
                    break;
                case ControllerButtons.BlueFret:
                    BlueFret = true;
                    break;
                case ControllerButtons.OrangeFret:
                    OrangeFret = true;
                    break;
                case ControllerButtons.DPadUp:
                    DPadUp = true;
                    break;
                case ControllerButtons.DPadDown:
                    DPadDown = true;
                    break;
                case ControllerButtons.DPadLeft:
                    DPadLeft = true;
                    break;
                case ControllerButtons.DPadRight:
                    DPadRight = true;
                    break;
                case ControllerButtons.Start:
                    Start = true;
                    break;
                case ControllerButtons.Select:
                    Select = true;
                    break;
            }
        }
        public bool GetButtonState(ControllerButtons button)
        {
            switch (button)
            {
                case ControllerButtons.GreenFret:
                    return GreenFret;
                case ControllerButtons.RedFret:
                    return RedFret;
                case ControllerButtons.YellowFret:
                    return YellowFret;
                case ControllerButtons.BlueFret:
                    return BlueFret;
                case ControllerButtons.OrangeFret:
                    return OrangeFret;
                case ControllerButtons.DPadUp:
                    return DPadUp;
                case ControllerButtons.DPadDown:
                    return DPadDown;
                case ControllerButtons.DPadLeft:
                    return DPadLeft;
                case ControllerButtons.DPadRight:
                    return DPadRight;
                case ControllerButtons.Start:
                    return Start;
                case ControllerButtons.Select:
                    return Select;
            }
            return false;
        }
        public void SetButtons(ControllerButtons[] buttons)
        {
            // Reset Button states
            GreenFret = false;
            RedFret = false;
            YellowFret = false;
            BlueFret = false;
            OrangeFret = false;

            DPadUp = false;
            DPadDown = false;
            DPadLeft = false;
            DPadRight = false;

            Start = false;
            Select = false;

            foreach (var button in buttons)
                SetButton(button);
        }
        public ControllerButtons[] GetButtons()
        {
            List<ControllerButtons> buttons = [];

            if (GreenFret)
                buttons.Add(ControllerButtons.GreenFret);
            if (RedFret)
                buttons.Add(ControllerButtons.RedFret);
            if (YellowFret)
                buttons.Add(ControllerButtons.YellowFret);
            if (BlueFret)
                buttons.Add(ControllerButtons.BlueFret);
            if (OrangeFret)
                buttons.Add(ControllerButtons.OrangeFret);

            if (DPadUp)
                buttons.Add(ControllerButtons.DPadUp);
            if (DPadDown)
                buttons.Add(ControllerButtons.DPadDown);
            if (DPadLeft)
                buttons.Add(ControllerButtons.DPadLeft);
            if (DPadRight)
                buttons.Add(ControllerButtons.DPadRight);

            if (Start)
                buttons.Add(ControllerButtons.Start);
            if (Select)
                buttons.Add(ControllerButtons.Select);

            return buttons.ToArray();
        }

        public override string ToString()
        {
            return 
                $"Green: {GreenFret} Red: {RedFret} Yellow: {YellowFret} Blue: {BlueFret} Orange: {OrangeFret} " +
                $"Up: {DPadUp} Down: {DPadDown} Left: {DPadLeft} Right: {DPadRight} " +
                $"Start: {Start} Select: {Select} " +
                $"Whammy: {Whammy} Tilt: {Tilt}";
        }
    }
}
