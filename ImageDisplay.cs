using System;
using System.Drawing;
using System.Windows.Forms;

namespace JspEdit
{
    public partial class ImageDisplay : UserControl
    {
        public Image Image
        {
            get;
            set;
        }


        public ImageDisplay()
        {
            InitializeComponent();
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );

            int newWidth = 0, newHeight = 0;
            float wR = 1, hR = 1;

            if ( Image.Width > this.ClientSize.Width )
                wR = Image.Width / this.Width;
            if ( Image.Height > this.ClientSize.Height )
                hR = Image.Height / this.Height;


            if ( wR > 1 || hR > 1 )
            {
                newWidth = Image.Width / (int) Math.Max( wR, hR );
                newHeight = Image.Height / (int) Math.Max( wR, hR );
            }
            else
            {
                newWidth = Image.Width;
                newHeight = Image.Height;
            }

            e.Graphics.DrawImage( this.Image, 0, 0, newWidth, newHeight );
        }
    }
}
