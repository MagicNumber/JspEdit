using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            e.Graphics.DrawImage( this.Image, 0,0, this.Width, this.Height );
        }
    }
}
