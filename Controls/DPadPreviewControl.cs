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

            using Bitmap up = DPadUp ? Properties.Resources.upPressed_1x : Properties.Resources.upUnpressed_1x;
            using Bitmap down = DPadDown ? Properties.Resources.downPressed_1x : Properties.Resources.downUnpressed_1x;
            using Bitmap left = DPadLeft ? Properties.Resources.leftPressed_1x : Properties.Resources.leftUnpressed_1x;
            using Bitmap right = DPadRight ? Properties.Resources.rightPressed_1x : Properties.Resources.rightUnpressed_1x;

            float halfWidth = Width / 2.0f;
            float halfHeight = Height / 2.0f;

            e.Graphics.DrawImage(up, new RectangleF(halfWidth - (up.Width  * 0.5f), 0, up.Width , up.Height ));
            e.Graphics.DrawImage(down, new RectangleF(halfWidth - (down.Width * 0.5f), Height - (down.Height ), down.Width , down.Height ));

            e.Graphics.DrawImage(left, new RectangleF(0,                              halfHeight - (left.Height  * 0.5f), left.Width , left.Height ));
            e.Graphics.DrawImage(right, new RectangleF(Width - (right.Width ), halfHeight - (right.Height * 0.5f), right.Width , right.Height ));
        }
    }
}
