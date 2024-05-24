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
        public const byte DefaultWhammyAxisIndex = 1;
        public const byte DefaultTiltAxisIndex = 2;

        public class AxisMapping(byte axisIndex)
        {
            public bool MapToAxis { get; set; } = true;
            public byte AxisIndex { get; set; } = axisIndex;
            public ControllerButtons[] Buttons { get; set; } = Array.Empty<ControllerButtons>();
        }

        public void Write()
        {

        }

        public void Read()
        {

        }

        public ControllerButtons[] GreenFret = [ ControllerButtons.GreenFret ];
        public ControllerButtons[] RedFret = [ ControllerButtons.RedFret];
        public ControllerButtons[] YellowFret = [ ControllerButtons.YellowFret ];
        public ControllerButtons[] BlueFret = [ ControllerButtons.BlueFret ];
        public ControllerButtons[] OrangeFret = [ ControllerButtons.OrangeFret ];

        public ControllerButtons[] DPadUp { get; set; } = [ ControllerButtons.DPadUp ];
        public ControllerButtons[] DPadDown { get; set; } = [ ControllerButtons.DPadDown ];
        public ControllerButtons[] DPadLeft { get; set; } = [ ControllerButtons.DPadLeft ];
        public ControllerButtons[] DPadRight { get; set; } = [ ControllerButtons.DPadRight ];

        public ControllerButtons[] StrumUp { get; set; } = [ControllerButtons.StrumUp];
        public ControllerButtons[] StrumDown { get; set; } = [ControllerButtons.StrumDown];

        public ControllerButtons[] Start { get; set; } = [ ControllerButtons.Start ];
        public ControllerButtons[] Select { get; set; } = [ ControllerButtons.Select ];

        public AxisMapping WhammyInfo { get; private set; } = new(DefaultWhammyAxisIndex);
        public AxisMapping TiltInfo { get; private set; } = new(DefaultTiltAxisIndex);

        
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
                case ControllerButtons.StrumUp:
                    StrumUp = sourceButtons;
                    break;
                case ControllerButtons.StrumDown:
                    StrumDown = sourceButtons;
                    break;
                case ControllerButtons.Start:
                    Start = sourceButtons;
                    break;
                case ControllerButtons.Select:
                    Select = sourceButtons;
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
                default:
                    return [];
            }
        }

        
        public AxisMapping GetAxisMapping(int index)
        {
            switch (index)
            {
                case 0:
                    return null;
                    break;
                case DefaultWhammyAxisIndex:
                    return WhammyInfo;
                case DefaultTiltAxisIndex:
                    return TiltInfo;
                default:
                    throw new ArgumentException(nameof(index));

            }
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

            StrumUp = [ ControllerButtons.StrumUp ];
            StrumDown = [ ControllerButtons.StrumDown ];

            Start = [ ControllerButtons.Start ];
            Select  = [ ControllerButtons.Select ];

            WhammyInfo.AxisIndex = DefaultWhammyAxisIndex;
            TiltInfo.AxisIndex = DefaultTiltAxisIndex;
        }

    }
}
