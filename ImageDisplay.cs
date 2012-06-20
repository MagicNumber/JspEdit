using System;
using System.Drawing;
using System.Windows.Forms;

namespace JspEdit
{
    public partial class ImageDisplay : UserControl
    {
        private JSPImage _image;
        public JSPImage Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value; 
                if (_image != null)
                    _render = _image.ToBitmap();
            }
        }

        protected Image _render;
        public Image Render
        {
            get
            {
                return _render;
            }
        }

        public bool Centered
        {
            get;
            set;
        }
        public bool DrawOrigin
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

            if ( Image != null )
            {
                int newWidth = 0, newHeight = 0;
                float wR = 1, hR = 1;

                if ( Image.Width > this.ClientSize.Width )
                    wR = Image.Width / (float) this.Width;
                if ( Image.Height > this.ClientSize.Height )
                    hR = Image.Height / (float) this.Height;


                if ( wR > 1 || hR > 1 )
                {
                    newWidth = (int) ( Image.Width / Math.Max( wR, hR ) );
                    newHeight = (int) ( Image.Height / Math.Max( wR, hR ) );
                }
                else
                {
                    newWidth = Image.Width;
                    newHeight = Image.Height;
                }

                int offsetX = 0;
                int offsetY = 0;
                if ( Centered )
                {
                    e.Graphics.TranslateTransform( this.Width / 2, this.Height / 2 );
                }

                if ( DrawOrigin )
                {
                    e.Graphics.DrawLine( Pens.Black, -5, 0, +5, 0 );
                    e.Graphics.DrawLine( Pens.Black, 0, -5, 0, +5 );
                }

                if ( Centered )
                {
                    offsetX += Image.OfsX;
                    offsetY += Image.OfsY;
                }
                
                e.Graphics.DrawImage( this.Render, offsetX, offsetY, newWidth, newHeight );
            }
        }
    }
}
