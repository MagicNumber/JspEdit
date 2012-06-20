using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
                var G = mainDisplayArea.CreateGraphics();
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
                using ( FileStream fs = new FileStream( name, FileMode.Open ))
                using ( BinaryReader br = new BinaryReader( fs ) )
                {
                    output = JSPFactory.Load( br );
                }
            }
            catch ( Exception e )
            {
#if !DEBUG
                if ( e is InvalidDataException || e is IOException )
                {
                    try
                    {
                        
                        string filename = string.Format( "error_{0}{1}{2}.txt", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                        string path = Environment.CommandLine.Substring( 1, Environment.CommandLine.LastIndexOf( '\\' ) );
                        // Because the FileSelect dialog changes the cwd, we need to grab it from arg[0]
                        // Start from index 1 to get rid of a leading quote mark

                        using ( StreamWriter f = new StreamWriter( path + "\\" + filename, true) )
                        {
                            f.WriteLine( "On filename " + name );
                            f.WriteLine( e.Message );
                            f.Write( e.StackTrace );
                        }
                        MessageBox.Show( "That wasn't a valid JSP file. (Or there's a bug in the reading code) We wrote out the error to " + filename );
                    }
                    catch ( IOException veryBadE )
                    {
                        MessageBox.Show( "That wasn't a valid JSP, and something broke when we tried to write out an error." );
                        return;
                    }
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
            ThumbnailClick( ThumbnailList[0], EventArgs.Empty ); // Load the first thumbnail automatically. 
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

                WidthBox.Text = output.Images[SelectedImage].Width.ToString();
                HeightBox.Text = output.Images[SelectedImage].Height.ToString();
                ofXBox.Text = output.Images[SelectedImage].OfsX.ToString();
                ofYBox.Text = output.Images[SelectedImage].OfsY.ToString();
            }
        }

        private void ofXBox_TextChanged( object sender, EventArgs e )
        {
            if ( !( sender is TextBox ) ) return;
            TextBox tbox = (TextBox) sender;

            int firstNonNumber = 0;
            for (firstNonNumber = 0; firstNonNumber < tbox.Text.Length; firstNonNumber++ )
            {
                if ( !"01234567890-".Contains( tbox.Text[firstNonNumber].ToString() ) )
                    break;
            }
            tbox.Text = tbox.Text.Substring( 0, firstNonNumber );

            short offX, offY;

            if ( !string.IsNullOrEmpty( ofXBox.Text ) && !string.IsNullOrEmpty( ofYBox.Text ) 
                &&  short.TryParse( ofXBox.Text, out offX ) && short.TryParse( ofYBox.Text, out offY ) )
            {
                output.Images[SelectedImage].SetOffSet( offX, offY );
            }
            else
            {
                if (!string.IsNullOrEmpty( ofXBox.Text ) && !string.IsNullOrEmpty( ofYBox.Text ))
                MessageBox.Show( "Something's gone wrong; a non-number slipped into the offset value boxes." );
            }
            
        }
    }

}