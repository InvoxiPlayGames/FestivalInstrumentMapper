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
    public partial class StrumbarPreview : UserControl
    {
        public StrumbarPreview()
        {
            InitializeComponent();
        }

        private bool strumUp = false;
        private bool strumDown = false;

        public bool StrumUp
        {
            get => strumUp;
            set
            {
                if (value != strumUp)
                    Invalidate();
                strumUp = value;
            }
        }
        public bool StrumDown
        {
            get => strumDown;
            set
            {
                if (value != strumDown)
                    Invalidate();
                strumDown = value;
            }
        }

        private void StrumbarPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            Bitmap img = (Convert.ToSByte(StrumUp) - Convert.ToSByte(StrumDown)) switch
            {
                1 => Properties.Resources.strumbarU,
                0 => Properties.Resources.strumbarN,
                -1 => Properties.Resources.strumbarD,
                _ => throw new NotImplementedException()
            };

            e.Graphics.DrawImage(img, 0, 0, Width, Height);

            img?.Dispose();
        }
    }
}
