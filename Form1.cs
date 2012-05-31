using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void MainForm_Load( object sender, EventArgs e )
        {
           
           var output = JSPFactory.Load( new System.IO.BinaryReader( new System.IO.FileStream("walls.jsp", System.IO.FileMode.Open)));
            
            Bitmap B = new Bitmap( 8*16, // 8 pixels wide per tile, of 16
                                   6*16, // 6 pixels high 
                System.Drawing.Imaging.PixelFormat.Format8bppIndexed );
            
            // ARCANE WIZARDRY INCOMING!
            var pallete = B.Palette;
            Color[] entries = pallete.Entries;
            for ( int i = 0; i < JSPImage.colors.Length; i++ )
            {
                entries[i] = JSPImage.colors[i];    
            }
            
            B.Palette = pallete;
            // Don't ask me why that worked. See http://charlespetzold.com/pwcs/PaletteChange.html
            // But that palette because it's the one Jamul uses.
            // See here. http://images.wikia.com/hamumu/images/e/eb/Tiles_Template.png            

            var data = B.LockBits(new Rectangle(0,0, B.Width, B.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            byte[] bitmap = new byte[B.Width * B.Height];
            int a = 0;
            for ( int y = 0; y < B.Height; y+=6 )
            {
                for ( int x = 0; x < B.Width; x+=8 )
                {
                    for ( int i = 0; i < 8; i++ )
                    {
                        for ( int j = 0; j < 6; j++ )
                        {
                            bitmap[(y+j) * B.Width + x + i] = (byte) a;    
                        }
                        
                    }
                    a = ( a + 1 ) % 256;

                }
            }
            System.Runtime.InteropServices.Marshal.Copy( bitmap, 0, data.Scan0, bitmap.Length );

            B.UnlockBits( data );

            pictureBox1.Image = B;

        }




    }
}
