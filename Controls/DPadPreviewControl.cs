using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestivalInstrumentMapper.Controls
{
    public partial class DPadPreviewControl : UserControl
    {
        public DPadPreviewControl()
        {
            InitializeComponent();
        }

        private bool dpadUp = false;
        private bool dpadDown = false;
        private bool dpadLeft = false;
        private bool dpadRight = false;


        public bool DPadUp
        {
            get => dpadUp;
            set
            {
                if (dpadUp != value)
                    Invalidate();
                dpadUp = value;
            }
        }
        public bool DPadDown
        {
            get => dpadDown;
            set
            {
                if (dpadDown != value)
                    Invalidate();
                dpadDown = value;
            }
        }
        public bool DPadLeft
        {
            get => dpadLeft;
            set
            {
                if (dpadLeft != value)
                    Invalidate();
                dpadLeft = value;
            }
        }
        public bool DPadRight
        {
            get => dpadRight;
            set
            {
                if (dpadRight != value)
                    Invalidate();
                dpadRight = value;
            }
        }
        private void DPadPreviewControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            float dpadWidth = (float)Width / 4.0f;
            float triangleSize = dpadWidth / 2.0f;

            RectangleF[] bgRects =
            {
                new((Width / 2.0f) - (dpadWidth / 2.0f), 0.0f, dpadWidth, Height),
                new(0, (Height / 2.0f) - (dpadWidth / 2.0f), Width, dpadWidth)
            };

            PointF[][] trianglePoints = [
                [ 
                    new PointF(bgRects[0].Left + triangleSize, bgRects[0].Top + triangleSize / 2.0f), 
                    new PointF(bgRects[0].Left + triangleSize / 2.0f, bgRects[0].Top + triangleSize), 
                    new PointF(bgRects[0].Left + triangleSize * 1.5f, bgRects[0].Top + triangleSize) 
                ], // Up
                [
                    new PointF(bgRects[0].Left + triangleSize, bgRects[0].Bottom - triangleSize / 2.0f),
                    new PointF(bgRects[0].Left + triangleSize / 2.0f, bgRects[0].Bottom - triangleSize),
                    new PointF(bgRects[0].Left + triangleSize * 1.5f, bgRects[0].Bottom - triangleSize)
                ], // Down
                [
                    new PointF(bgRects[1].Left + triangleSize / 2.0f, bgRects[1].Top + triangleSize),
                    new PointF(bgRects[1].Left + triangleSize, bgRects[1].Top + triangleSize / 2.0f),
                    new PointF(bgRects[1].Left + triangleSize, bgRects[1].Top + triangleSize * 1.5f),
                ], // Left
                [
                    new PointF(bgRects[1].Right - triangleSize / 2.0f, bgRects[1].Top + triangleSize),
                    new PointF(bgRects[1].Right - triangleSize, bgRects[1].Top + triangleSize / 2.0f),
                    new PointF(bgRects[1].Right - triangleSize, bgRects[1].Top + triangleSize * 1.5f),
                ], // Right
            ];

            e.Graphics.FillRectangles(Brushes.Black, bgRects);

            foreach (var tri in trianglePoints)
                e.Graphics.FillPolygon(Brushes.White, tri);

            List<RectangleF> activeRects = [];
            List<PointF[]> activeTriangles = [];

            if (DPadUp)
            {
                activeRects.Add(new(bgRects[0].X + 4.0f, bgRects[0].Y + 4.0f, bgRects[0].Width - 8.0f, bgRects[1].Y - 4.0f));
                activeTriangles.Add(trianglePoints[0]);
            }
            if (DPadDown)
            {
                activeRects.Add(new(bgRects[0].X + 4.0f, bgRects[1].Bottom, bgRects[0].Width - 8.0f, bgRects[0].X - 4.0f));
                activeTriangles.Add(trianglePoints[1]);
            }
            if (activeRects.Count > 0)
            {
                e.Graphics.FillRectangles(Brushes.White, activeRects.ToArray());

                foreach (var tri in activeTriangles)
                    e.Graphics.FillPolygon(Brushes.Black, tri);
            }
        }
    }
}
