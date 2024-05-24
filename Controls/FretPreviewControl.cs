using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace FestivalInstrumentMapper.Controls
{
    // Code written by Vultumast so blame them if it breaks - Vultumast
    public partial class FretPreviewControl : UserControl
    {
        public FretPreviewControl()
        {
            InitializeComponent();
        }
        private int fretBorderSize = 4;
        private int fretPadding = 2;

        private bool leftyFlip = false;
        private Color[] fretColours = [
            Color.Green,
            Color.Red,
            Color.Yellow,
            Color.Blue,
            Color.Orange
        ];

        private bool[] activeFrets =
        {
            false,
            false, 
            false,
            false,
            false,
        };
        public bool LeftyFlip
        {
            get => leftyFlip;
            set
            {
                leftyFlip = value;
                Invalidate();
            }
        }

        public int FretBorderSize
        {
            get => fretBorderSize;
            set
            {
                fretBorderSize = value;
                Invalidate();
            }
        }
        public int FretPadding
        {
            get => fretPadding;
            set
            {
                fretPadding = value;
                Invalidate();
            }
        }


        public bool GreenFretActive
        {
            get => activeFrets[0];
            set
            {
                if (activeFrets[0] != value)
                    Invalidate();
                activeFrets[0] = value;
            }
        }
        public bool RedFretActive
        {
            get => activeFrets[1];
            set
            {
                if (activeFrets[1] != value)
                    Invalidate();
                activeFrets[1] = value;
            }
        }
        public bool YellowFretActive
        {
            get => activeFrets[2];
            set
            {
                if (activeFrets[2] != value)
                    Invalidate();
                activeFrets[2] = value;
            }
        }
        public bool BlueFretActive
        {
            get => activeFrets[3];
            set
            {
                if (activeFrets[3] != value)
                    Invalidate();
                activeFrets[3] = value;
            }
        }
        public bool OrangeFretActive
        {
            get => activeFrets[4];
            set
            {
                if (activeFrets[4] != value)
                    Invalidate();
                activeFrets[4] = value;
            }
        }
        public void SetFrets(IEnumerable<ControllerButtons> frets)
        {
            for (var i = 0; i < activeFrets.Length; i++)
                activeFrets[i] = false;
            foreach (var fret in frets)
            {
                switch (fret)
                {
                    case ControllerButtons.GreenFret:
                        GreenFretActive = true;
                        break;
                    case ControllerButtons.RedFret:
                        RedFretActive = true;
                        break;
                    case ControllerButtons.YellowFret:
                        YellowFretActive = true;
                        break;
                    case ControllerButtons.BlueFret:
                        BlueFretActive = true;
                        break;
                    case ControllerButtons.OrangeFret:
                        OrangeFretActive = true;
                        break;
                }
            }
            Invalidate();
        }

        private void FretPreviewControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            Bitmap[] pressedBitmaps =
                [
                    Properties.Resources.greenFretPressed_2x,
                    Properties.Resources.redFretPressed_2x,
                    Properties.Resources.yellowFretPressed_2x,
                    Properties.Resources.blueFretPressed_2x,
                    Properties.Resources.orangeFretPressed_2x
                ];
            Bitmap[] unpressedBitmaps =
                [
                    Properties.Resources.greenFretUnpressed_2x,
                    Properties.Resources.redFretUnpressed_2x,
                    Properties.Resources.yellowFretUnpressed_2x,
                    Properties.Resources.blueFretUnpressed_2x,
                    Properties.Resources.orangeFretUnpressed_2x
                ];

            float doubleFretBorderSize = (float)fretBorderSize * 2.0f;
            float doubleFretPadding = (float)fretPadding * 2.0f;

            float fretWidth = Width / 5.0f;

            for (var i = 0; i < 5; i++)
            {
                drawFretIcon(i, activeFrets[i]);
            }

            for (var i = 0; i < 5; i++)
            {
                pressedBitmaps[i]?.Dispose();
                unpressedBitmaps[i]?.Dispose();
            }
            return;

            void drawFretIcon(int index, bool pressed)
            {
                RectangleF fretBounds = new(((float)index * fretWidth) + (float)fretPadding, (float)fretPadding, fretWidth - doubleFretPadding, Height - doubleFretPadding);

                if (pressed)
                    e.Graphics.DrawImage(pressedBitmaps[index], fretBounds);
                else
                    e.Graphics.DrawImage(unpressedBitmaps[index], fretBounds);

                /* e.Graphics.FillRectangle(Brushes.Black, fretBounds);

                using Brush fretBrush = new SolidBrush(Color.FromArgb(activeFrets[index] ? 255 : 128, fretColours[index]));

                e.Graphics.FillRectangle(fretBrush, fretBounds.X + (float)fretBorderSize, fretBounds.Y + (float)fretBorderSize, fretBounds.Width - doubleFretBorderSize, fretBounds.Height - doubleFretBorderSize); */
            }

        }

        private void FretPreviewControl_Load(object sender, EventArgs e)
        {

        }
    }
}
