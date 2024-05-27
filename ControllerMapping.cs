using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    /// <summary>
    /// Object stating how source buttons map to destination buttons
    /// </summary>
    public class ControllerMapping
    {
        public ControllerMapping()
        {
            TiltInfo.DeadZone = 50;
        }

        public class AxisMapping
        {
            public AxisMapping()
            {
                
            }
            public AxisMapping(ControllerAxis axisIndex)
            {
                AxisIndex = axisIndex;
            }

            public bool MapToAxis { get; set; } = true;
            public ControllerAxis AxisIndex { get; set; } = ControllerAxis.Whammy;
            public ControllerButtons[] Buttons { get; set; } = Array.Empty<ControllerButtons>();
            public byte PressedValue { get; set; } = 100;
            public byte DeadZone { get; set; } = 0;
        }

        public static void Save(string name, ControllerMapping mapping) => File.WriteAllText($"Profile\\{name}.json", System.Text.Json.JsonSerializer.Serialize(mapping, new System.Text.Json.JsonSerializerOptions() { WriteIndented = true }));

        public static ControllerMapping? Load(string name) => System.Text.Json.JsonSerializer.Deserialize<ControllerMapping>(File.ReadAllText($"Profile\\{name}.json"));

        public ControllerButtons[] GreenFret { get; set; } = [ ControllerButtons.GreenFret ];
        public ControllerButtons[] RedFret { get; set; } = [ ControllerButtons.RedFret];
        public ControllerButtons[] YellowFret { get; set; } = [ ControllerButtons.YellowFret ];
        public ControllerButtons[] BlueFret { get; set; } = [ ControllerButtons.BlueFret ];
        public ControllerButtons[] OrangeFret { get; set; }  = [ ControllerButtons.OrangeFret ];

        public ControllerButtons[] DPadUp { get; set; } = [ ControllerButtons.DPadUp ];
        public ControllerButtons[] DPadDown { get; set; } = [ ControllerButtons.DPadDown ];
        public ControllerButtons[] DPadLeft { get; set; } = [ ControllerButtons.DPadLeft ];
        public ControllerButtons[] DPadRight { get; set; } = [ ControllerButtons.DPadRight ];

        public ControllerButtons[] Start { get; set; } = [ ControllerButtons.Start ];
        public ControllerButtons[] Select { get; set; } = [ ControllerButtons.Select ];

        public AxisMapping WhammyInfo { get; set; } = new(ControllerAxis.Whammy);
        public AxisMapping TiltInfo { get; set; } = new(ControllerAxis.Tilt);

        
        public void SetButtonMapping(ControllerButtons destinationButton, ControllerButtons[] sourceButtons)
        {
            switch (destinationButton)
            {
                case ControllerButtons.GreenFret:
                    GreenFret = sourceButtons;
                    break;
                case ControllerButtons.RedFret:
                    RedFret = sourceButtons;
                    break;
                case ControllerButtons.YellowFret:
                    YellowFret = sourceButtons;
                    break;
                case ControllerButtons.BlueFret:
                    BlueFret = sourceButtons;
                    break;
                case ControllerButtons.OrangeFret:
                    OrangeFret = sourceButtons;
                    break;
                case ControllerButtons.DPadUp:
                    DPadUp = sourceButtons;
                    break;
                case ControllerButtons.DPadDown:
                    DPadDown = sourceButtons;
                    break;
                case ControllerButtons.DPadLeft:
                    DPadLeft = sourceButtons;
                    break;
                case ControllerButtons.DPadRight:
                    DPadRight = sourceButtons;
                    break;
                case ControllerButtons.Start:
                    Start = sourceButtons;
                    break;
                case ControllerButtons.Select:
                    Select = sourceButtons;
                    break;
            }
        }
        public void SetButtonMapping(ControllerAxis destinationAxis, ControllerButtons[] sourceButtons)
        {
            switch (destinationAxis)
            {
                case ControllerAxis.Whammy:
                    WhammyInfo.Buttons = sourceButtons;
                    break;
                case ControllerAxis.Tilt:
                    TiltInfo.Buttons = sourceButtons;
                    break;
            }
        }

        public ControllerButtons[] GetButtonMapping(ControllerButtons button)
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
                default:
                    return [];
            }
        }

        
        public AxisMapping? GetAxisMapping(ControllerAxis axis)
        {
            switch (axis)
            {
                case ControllerAxis.Whammy:
                    return WhammyInfo;
                case ControllerAxis.Tilt:
                    return TiltInfo;
            }
            return null;
        }

        public void Reset()
        {
            GreenFret = [ ControllerButtons.GreenFret ];
            RedFret = [ ControllerButtons.RedFret ];
            YellowFret = [ ControllerButtons.YellowFret ];
            BlueFret = [ ControllerButtons.BlueFret ];
            OrangeFret = [ ControllerButtons.OrangeFret ];

            DPadUp = [ ControllerButtons.DPadUp ];
            DPadDown = [ ControllerButtons.DPadDown ];
            DPadLeft = [ ControllerButtons.DPadLeft ];
            DPadRight = [ ControllerButtons.DPadRight ];

            Start = [ ControllerButtons.Start ];
            Select  = [ ControllerButtons.Select ];

            WhammyInfo.MapToAxis = true;
            TiltInfo.MapToAxis = true;

            WhammyInfo.Buttons = Array.Empty<ControllerButtons>();
            TiltInfo.Buttons = Array.Empty<ControllerButtons>();

            WhammyInfo.AxisIndex = ControllerAxis.Whammy;
            TiltInfo.AxisIndex = ControllerAxis.Tilt;

            WhammyInfo.DeadZone = 0;
            TiltInfo.DeadZone = 50;
        }

    }
}
