using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JspEdit
{
    public partial class MainForm : Form
    {
        readonly Size thumbnailSize = new Size( 1000, 48 );
        readonly Size OriginalFormSize;
        readonly int ThumbnailPadding = 5; // Padding between items in the list of thumbnails.

        /// <summary>
        /// The number of the image we're looking at ATM. 
        /// </summary>
        int SelectedImage = 0;

        List<ImageDisplay> ThumbnailList = new List<ImageDisplay>();


        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MinimumSize = OriginalFormSize = new Size( this.Size.Width, this.Size.Height );
        }

        JSP output;

        private void MainForm_Paint( object sender, PaintEventArgs e )
        {
            if ( output != null )
            {
                var G = pictureBox1.CreateGraphics();
                G.DrawImage( output.Images[SelectedImage].ToBitmap(), 0, 0 );
            }

        }

        private void OpenButton_Click( object sender, EventArgs e )
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = "*.jsp";
            dialog.Multiselect = false;
            DialogResult result = dialog.ShowDialog();
            if ( result == System.Windows.Forms.DialogResult.OK )
            {
                LoadJSP( dialog.FileName );
            }
            this.Refresh();
        }

        private void LoadJSP( string name )
        {
            try
            {
                using ( var fh = new BinaryReader(
                            new FileStream( name, FileMode.Open )
                        )
                      )
                {
                    output = JSPFactory.Load( fh );
                }
            }
            catch ( Exception e )
            {
#if !DEBUG
                if ( e is InvalidDataException || e is IOException )
                {
                    MessageBox.Show( "This wasn't a valid JSP file." );
                    return;
                }
                else
#endif
                    throw;
            }

            HeightBox.Text = output.Images[0].Width.ToString();
            WidthBox.Text = output.Images[0].Height.ToString();

            panel1.Controls.Clear();

            int heightSoFar = 0;

            ThumbnailList.ForEach( I => I.Dispose() );
            ThumbnailList.Clear();
            
            for ( int i = 0; i < output.Images.Count; i++ )
            {
                Bitmap orig = output.Images[i].ToBitmap();

                ImageDisplay img = new ImageDisplay();
                img.Image = orig;
                img.Width = panel1.ClientSize.Width;
                img.Height = img.Width;
                img.Top = heightSoFar;
                heightSoFar += img.Height + ThumbnailPadding;
                ThumbnailList.Add( img );
                panel1.Controls.Add( img );
                img.Click += new EventHandler( ThumbnailClick );
            }
            panel1.Refresh();
            SelectedImage = 0;
            label1.Text = string.Format( "Sprite {0} of {1}", SelectedImage+1, output.Images.Count.ToString() );
        }

        void ThumbnailClick( object sender, EventArgs e )
        {
            if ( sender is ImageDisplay )
            {
                ThumbnailList[SelectedImage].BackColor = this.BackColor;
                SelectedImage = ThumbnailList.IndexOf( (ImageDisplay) sender );
                ThumbnailList[SelectedImage].BackColor = Color.Yellow;
                this.Refresh();
                label1.Text = string.Format( "Sprite {0} of {1}", SelectedImage+1, output.Images.Count.ToString() );
            }
        }
    }

}