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

        private StrumbarPosition strumbarPosition = StrumbarPosition.Neutral;

        public StrumbarPosition StrumbarPosition
        {
            get => strumbarPosition;
            set
            {
                if (strumbarPosition != value)
                    Invalidate();

                strumbarPosition = value;
            }
        }

        private void StrumbarPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            Bitmap img = StrumbarPosition switch
            {
                StrumbarPosition.Up => Properties.Resources.strumbarU,
                StrumbarPosition.Neutral => Properties.Resources.strumbarN,
                StrumbarPosition.Down => Properties.Resources.strumbarD,
                _ => throw new NotImplementedException()
            };

            e.Graphics.DrawImage(img, 0, 0, Width, Height);

            img?.Dispose();
        }
    }
}
