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

                if ( _image != null )
                {
                    _render = _image.ToBitmap();
                    _image.DataChanged += new JSPImage.DataChangeHandler( _image_DataChanged );

                }
            }
        }

        void _image_DataChanged( object sender, byte[] oldData )
        {
            if ( _image != null )
            {
                _render.Dispose();
                _render = _image.ToBitmap();
                this.Invalidate();
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

                if ( Centered )
                {
                    e.Graphics.TranslateTransform( this.Width / 2, this.Height / 2 );
                    e.Graphics.TranslateTransform( -Render.Width / 2, -Render.Height / 2 );
                }

                e.Graphics.DrawImage( this.Render, 0, 0, newWidth, newHeight );

                
                if ( DrawOrigin )
                {
                    e.Graphics.TranslateTransform( Render.Width / 2, Render.Height / 2 );
                    e.Graphics.TranslateTransform( Image.OfsX, Image.OfsY );
                    e.Graphics.DrawLine( Pens.Black, -5, 0, +5, 0 );
                    e.Graphics.DrawLine( Pens.Black, 0, -5, 0, +5 );
                    e.Graphics.TranslateTransform( -Image.OfsX, -Image.OfsY );
                }

                e.Graphics.ResetTransform();
            }
        }
    }
}
