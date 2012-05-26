using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JspEdit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click( object sender, EventArgs e )
        {

        }

        private void label1_Click( object sender, EventArgs e )
        {

        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            List<Color> colors = new List<Color>();
            for ( int r = 0; r < 255; r+=8 )
            {
                for ( int g = 0; g < 255; g+=8 )
                {
                    for ( int b = 0; b < 255; b+=8 )
                    {
                        colors.Add( Color.FromArgb( r, g, b ) );
                    }
                }
            }
            Bitmap B = new Bitmap( 16 * 16, 16 * 16, System.Drawing.Imaging.PixelFormat.Format8bppIndexed );
            int i = 0;
            var Bits = B.LockBits( new Rectangle(0,0,B.Width, B.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed );
            Bits.Scan0
            pictureBox1.Image = B;
        }




    }
}
