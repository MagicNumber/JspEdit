using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JspEdit
{
    public partial class MainForm : Form
    {
        readonly int ThumbnailPadding = 10; // Padding between items in the list of thumbnails.
        readonly string ErrorFilename = string.Format( "error_{0}{1}{2}.txt", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day );
        /// <summary>
        /// The number of the image we're looking at ATM. 
        /// </summary>
        int SelectedImage = 0;

        List<ImageDisplay> ThumbnailList = new List<ImageDisplay>();

        string _FilePath;
        string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value; this.Text = string.Format( "{0} - JSP Edit", value );
            }
        }

        JSP WorkingFile;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }

        


        private void OpenButton_Click( object sender, EventArgs e )
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSP files (*.jsp)|*.jsp|All files (*.*)|*.*";
            dialog.Multiselect = false;
            DialogResult result = dialog.ShowDialog();
            if ( result == System.Windows.Forms.DialogResult.OK )
            {
                LoadJSP( dialog.FileName );
                FilePath = dialog.FileName;
            }
            
            this.Refresh();
        }

        private void WriteExceptionToFile(Exception e)
        {
            string filename = string.Format( "error_{0}{1}{2}.txt", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day );

            string path = Environment.CommandLine.Substring( 1, Environment.CommandLine.LastIndexOf( '\\' ) );
            // Because the FileSelect dialog changes the cwd, we need to grab it from arg[0]
            // Start from index 1 to get rid of a leading quote mark

            using ( StreamWriter f = new StreamWriter( path + "\\" + filename, true ) )
            {
                f.WriteLine( e.Message );
                f.Write( e.StackTrace );
            }
        }


        private void LoadJSP( string name )
        {
            try
            {
                using ( FileStream fs = new FileStream( name, FileMode.Open ) )
                using ( BinaryReader br = new BinaryReader( fs ) )
                {
                    WorkingFile = JSPFactory.Load( br );
                }
            }
#if !DEBUG
            catch ( Exception e )
            {

                if ( e is InvalidDataException || e is IOException )
                {
                    try
                    {
                        WriteExceptionToFile(e);
                        MessageBox.Show( "That wasn't a valid JSP file. (Or there's a bug in the reading code) We wrote out the error to " + ErrorFilename );
                    }
                    catch ( IOException veryBadE )
                    {
                        MessageBox.Show( "That wasn't a valid JSP, and something broke when we tried to write out an error." );
                        return;
                    }
                    return;
                }
                else

                    throw;
            }
#endif // We want an error to go up to the debugger if it's there, but if it's not there handle it.
            finally
            {
            }

            HeightBox.Text = WorkingFile.Images[0].Width.ToString();
            WidthBox.Text = WorkingFile.Images[0].Height.ToString();

            GenerateThumbnails();

            SelectedImage = 0;
            ThumbnailClick( ThumbnailList[0], EventArgs.Empty ); // Load the first thumbnail automatically. 
        }

        void GenerateThumbnails()
        {
            ThumbnailList.ForEach( I => I.Dispose() );
            ThumbnailList.Clear();
            panel1.Controls.Clear();

            int heightSoFar = 0;
            for ( int i = 0; i < WorkingFile.Images.Count; i++ )
            {
                ImageDisplay img = new ImageDisplay();
                img.Image = WorkingFile.Images[i];
                img.Centered = false;
                img.DrawOrigin = false;
                img.Width = panel1.ClientSize.Width;
                img.Height = img.Width;
                img.Top = heightSoFar;
                heightSoFar += img.Height + ThumbnailPadding;
                ThumbnailList.Add( img );
                panel1.Controls.Add( img );
                img.Click += new EventHandler( ThumbnailClick );
            }
            panel1.Refresh();
        }



        void ThumbnailClick( object sender, EventArgs e )
        {
            if ( sender is ImageDisplay )
            {
                
                ThumbnailList[SelectedImage].BackColor = Color.White;
                SelectedImage = ThumbnailList.IndexOf( (ImageDisplay) sender );
                ThumbnailList[SelectedImage].BackColor = Color.Yellow;
                
                CountLabel.Text = string.Format( "Sprite {0} of {1}", SelectedImage+1, WorkingFile.Images.Count.ToString() );
                UpButton.Enabled = SelectedImage != 0;
                DownButton.Enabled = SelectedImage != (WorkingFile.Images.Count-1);

                WidthBox.Text = WorkingFile.Images[SelectedImage].Width.ToString();
                HeightBox.Text = WorkingFile.Images[SelectedImage].Height.ToString();
                ofXBox.Text = WorkingFile.Images[SelectedImage].OfsX.ToString();
                ofYBox.Text = WorkingFile.Images[SelectedImage].OfsY.ToString();

                mainDisplayArea.Image = WorkingFile.Images[SelectedImage];
                this.Refresh();
            }
        }

        private void panel1_MouseWheel( object sender, MouseEventArgs e )
        {
            var val = ( e.Delta / 120 ) * SystemInformation.MouseWheelScrollLines;
            if ( val > 0 && val < panel1.VerticalScroll.Maximum )
                panel1.VerticalScroll.Value += val;
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

            short test = 0;

            if ( !short.TryParse( tbox.Text, out test ) )
            {
                return;
            }


            short offX, offY;

            if ( !string.IsNullOrEmpty( ofXBox.Text ) && !string.IsNullOrEmpty( ofYBox.Text ) 
                &&  short.TryParse( ofXBox.Text, out offX ) && short.TryParse( ofYBox.Text, out offY ) )
            {
                WorkingFile.Images[SelectedImage].SetOffSet( offX, offY );
            }
            else
            {
                if (!string.IsNullOrEmpty( ofXBox.Text ) && !string.IsNullOrEmpty( ofYBox.Text ))
                MessageBox.Show( "Something's gone wrong; a non-number slipped into the offset value boxes." );
            }
            this.Refresh();
        }

        private void SaveButton_Click( object sender, EventArgs e )
        {
            SaveFile( FilePath );
        }


        private void SaveFile( string name )
        {
            if ( name == null ) return;

            try
            {
                using ( FileStream fs = new FileStream( name, FileMode.OpenOrCreate ) )
                using ( BinaryWriter bw = new BinaryWriter( fs ) )
                {
                    JSPFactory.Save( WorkingFile, bw );
                }
            }
#if !DEBUG
            catch ( IOException ex )
            {
                try
                {
                    WriteExceptionToFile( ex );
                    MessageBox.Show( "Save failed. We've wrote out the details to " + ErrorFilename );
                }
                catch ( IOException vbex )
                {
                    MessageBox.Show( "Save failed. We tried to write out the details, but that failed too." );
                }

            
            }
#endif
            finally
            {
            }
        }

        private void SaveAsButton_Click( object sender, EventArgs e )
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "JSP files (*.jsp)|*.jsp|All files (*.*)|*.*";
            DialogResult result = dialog.ShowDialog();
            if ( result == DialogResult.OK )
            {
                SaveFile( dialog.FileName );
                FilePath = dialog.FileName;
            }

            this.Refresh();
        }

        private void DelButton_Click( object sender, EventArgs e )
        {
            if ( SelectedImage < ThumbnailList.Count && SelectedImage < WorkingFile.Images.Count )
            {
                var delThumbnail = ThumbnailList[SelectedImage];
                WorkingFile.Images.RemoveAt( SelectedImage );
                ThumbnailList.RemoveAt( SelectedImage );
                foreach ( var t in ThumbnailList )
                {
                    if ( t.Top >= delThumbnail.Top )
                        t.Top -= delThumbnail.Height + ThumbnailPadding;
                }
                delThumbnail.Dispose();
            }
        }

        private void UpButton_Click( object sender, EventArgs e )
        {
            var im = WorkingFile.Images[SelectedImage - 1];
            WorkingFile.Images.RemoveAt( SelectedImage - 1 );
            WorkingFile.Images.Insert( SelectedImage, im );
            
            var high = ThumbnailList[SelectedImage - 1];
            var low = ThumbnailList[SelectedImage];
            ThumbnailList.RemoveAt( SelectedImage - 1 );
            ThumbnailList.Insert( SelectedImage, high );

            var temp = high.Top;
            high.Top = low.Top;
            low.Top = temp;
            
            panel1.ScrollControlIntoView( low );

            ThumbnailClick( low, EventArgs.Empty );
        }

        private void DownButton_Click( object sender, EventArgs e )
        {
            var im = WorkingFile.Images[SelectedImage];
            WorkingFile.Images.RemoveAt( SelectedImage );
            WorkingFile.Images.Insert( SelectedImage+1, im );

            var high = ThumbnailList[SelectedImage];
            var low = ThumbnailList[SelectedImage+1];
            ThumbnailList.RemoveAt( SelectedImage );
            ThumbnailList.Insert( SelectedImage+1, high );

            var temp = high.Top;
            high.Top = low.Top;
            low.Top = temp;
            panel1.ScrollControlIntoView( high );

            ThumbnailClick( high, EventArgs.Empty );
        }


        private void ImportButton_Click( object sender, EventArgs e )
        {
            if ( WorkingFile == null )
                WorkingFile = new JSP();

            var dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            DialogResult result = dialog.ShowDialog();
            if ( result == System.Windows.Forms.DialogResult.OK )
            {
                foreach ( string filename in dialog.FileNames )
                {
                    try
                    {
                        using ( Bitmap b = (Bitmap) Bitmap.FromFile( filename ) )
                        {
                            var JSP = JSPImage.FromBitmap( b );
                            WorkingFile.Images.Add( JSP );
                        }
                    }
                    catch ( Exception ex )
                    {
                        WriteExceptionToFile( ex );
                        MessageBox.Show( "Import of " + filename + " failed. We've wrote out the details to " + ErrorFilename );
                    }
                }
                GenerateThumbnails();
            }
            ThumbnailClick( ThumbnailList[ThumbnailList.Count - 1], EventArgs.Empty );

            this.Refresh();
        }
    }

}