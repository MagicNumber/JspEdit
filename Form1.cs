using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;

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

        string _filepath;
        string FilePath
        {
            get
            {
                return _filepath;
            }
            set
            {
                _filepath = value; 
                this.Text = string.Format( "{0} - JSP Edit", value );
#if DEBUG
                this.Text += " (DEBUG)";
#endif
            }
        }

        JSP WorkingFile;
        bool ShiftMouseDown;
        Point LastMousePosition;

        public MainForm()
        {
            InitializeComponent();
            WorkingFile = new JSP();
            this.DoubleBuffered = true;
            this.MinimumSize = new Size( this.Size.Width, this.Size.Height );
        }


        public override void Refresh()
        {
            base.Refresh();
            UpButton.Enabled = SelectedImage != 0;
            DownButton.Enabled = SelectedImage != ( WorkingFile.Images.Count - 1 );
            ofXBox.Enabled = WorkingFile.Images.Count > 0;
            ofYBox.Enabled = WorkingFile.Images.Count > 0;
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
            ClickOnThumbnail( 0 ); // Load the first thumbnail automatically. 
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

        void ClickOnThumbnail( ImageDisplay nail )
        {
            if (ThumbnailList.Contains(nail))
                ThumbnailClick( nail, EventArgs.Empty );
            else
                Debug.WriteLine( "Tried to access non-existing Thumbnail" );
        }


        void ClickOnThumbnail( int index )
        {
            if ( index < 0 || index > ThumbnailList.Count - 1 )
            {
                Debug.WriteLine( "Tried to access non-existing Thumbnail" );
            }
            else
            {
                ThumbnailClick( ThumbnailList[index], EventArgs.Empty );
            }
        }

        void ThumbnailClick( object sender, EventArgs e )
        {
            if ( sender is ImageDisplay )
            {
                if (SelectedImage >= 0 && SelectedImage <= ThumbnailList.Count-1)
                    ThumbnailList[SelectedImage].BackColor = Color.White; // Because this one might've been deleted.
                SelectedImage = ThumbnailList.IndexOf( (ImageDisplay) sender );
                ThumbnailList[SelectedImage].BackColor = Color.Yellow;
                
                CountLabel.Text = string.Format( "Sprite {0} of {1}", SelectedImage+1, WorkingFile.Images.Count.ToString() );
               
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
            this.Refresh();
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

            ClickOnThumbnail( low );
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

            ClickOnThumbnail( high );
        }

        private void ImportSprites( string[] files, bool weCareAboutExceptions )
        {
            foreach ( string filename in files )
            {
                string[] bits = filename.Split( '.' );
                string ext = bits[bits.Length - 1].ToLower();
                if ( !( ext == "gif" || ext == "jpeg" || ext == "jpg" || ext == "png" || ext == "bmp" || ext == "tiff" ) )
                {
                    break;
                }

                try
                {
                    using ( Bitmap b = (Bitmap) Bitmap.FromFile( filename ) )
                    {
#if DEBUG
                        Stopwatch S = Stopwatch.StartNew();
#endif
                        var JSP = JSPImage.FromBitmap( b );
                        WorkingFile.Images.Add( JSP );
#if DEBUG
                        Debug.WriteLine( string.Format( "Parsing {0} ({2}x{3}) took {1}s", filename, S.Elapsed.TotalSeconds, JSP.Width, JSP.Height ) );
#endif
                    }
                }
#if !DEBUG
                catch ( Exception ex )
                {

                    if ( weCareAboutExceptions )
                    {
                        WriteExceptionToFile( ex );
                        MessageBox.Show( "Import of " + filename + " failed. We've wrote out the details to " + ErrorFilename );
                    }

                }
#endif
                finally
                {
                }
            }
            GenerateThumbnails();
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
                ImportSprites( dialog.FileNames, true );
                panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            }
            this.Refresh();
        }

        private void importFolder_Click( object sender, EventArgs e )
        {
            if ( WorkingFile == null )
                WorkingFile = new JSP();

            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            DialogResult result = dialog.ShowDialog();
            if ( result == System.Windows.Forms.DialogResult.OK )
            {
                ImportSprites( Directory.GetFiles( dialog.SelectedPath ), false );

                ClickOnThumbnail( ThumbnailList.Count - 1);
            }
            this.Refresh();
        }

        private void ExportItem_Click( object sender, EventArgs e )
        {
            var dialog = new SaveFileDialog();
            DialogResult result = dialog.ShowDialog();
            if ( result == DialogResult.OK )
            {
                ExportSprite( WorkingFile.Images[SelectedImage], dialog.FileName );
            }
        }

        private void ExportSprite( JSPImage img, string filename )
        {
            using ( var fh = new StreamWriter( filename, false ) )
            using ( Bitmap B = img.ToBitmap() )
            {
                B.Save( fh.BaseStream, ImageFormat.Bmp );
            }
        }


        private void exportFolder_Click( object sender, EventArgs e )
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            DialogResult result = dialog.ShowDialog();
            if ( result == System.Windows.Forms.DialogResult.OK )
            {
                for ( int i = 0; i < WorkingFile.Images.Count; i++ )
                {
                    ExportSprite( WorkingFile.Images[i], string.Format( "{0}/{1:0000}.bmp", dialog.SelectedPath, i+1 ) );
                }

            }
            ClickOnThumbnail( ThumbnailList.Count - 1 );

        }

        private void newButton_Click( object sender, EventArgs e )
        {
            WorkingFile = new JSP();
            this.Refresh();
            GenerateThumbnails();
        }

        private void mainDisplayArea_MouseDown( object sender, MouseEventArgs e )
        {
            ShiftMouseDown = true;
        }

        private void mainDisplayArea_MouseMove( object sender, MouseEventArgs e )
        {
            if (ShiftMouseDown && WorkingFile.Images.Count > SelectedImage)
            {
                short ofsx = WorkingFile.Images[SelectedImage].OfsX;
                short ofsy = WorkingFile.Images[SelectedImage].OfsY;
                ofsx += (short)(e.Location.X - LastMousePosition.X);
                ofsy += (short)(e.Location.Y - LastMousePosition.Y);
                WorkingFile.Images[SelectedImage].SetOffSet( ofsx, ofsy );

                ofXBox.Text = ofsx.ToString();
                ofYBox.Text = ofsy.ToString();
            }
            LastMousePosition = e.Location;
        }

        private void mainDisplayArea_MouseUp( object sender, MouseEventArgs e )
        {
            ShiftMouseDown = false;
        }

        private void ColourBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            Panel box;
            if ( sender == FromColourBox )
            {
                box = FromBox;
            }
            else
            {
                box = ToBox;
            }

            switch ( ((ComboBox)sender).Text )
            {
                case "Grey":
                    box.BackColor = JSPImage.colors[16 * 1-1];
                    break;
                case "Green":
                    box.BackColor = JSPImage.colors[16 * 3-1];
                    break;
                case "Brown":
                    box.BackColor = JSPImage.colors[16 * 5-1];
                    break;
                case "Blue":
                    box.BackColor = JSPImage.colors[16 * 7-1];
                    break;
                case "Red":
                    box.BackColor = JSPImage.colors[16 * 9-1];
                    break;
                case "Yellow":
                    box.BackColor = JSPImage.colors[16 * 11-1];
                    break;
                case "Purple":
                    box.BackColor = JSPImage.colors[16 * 13-1];
                    break;
                case "Cyan":
                    box.BackColor = JSPImage.colors[16 * 15-1];
                    break;
                default:
                    break;
            }
        }

        private void ColourChangeButton_Click( object sender, EventArgs e )
        {
            if ( SelectedImage >= WorkingFile.Images.Count )
                return;

            if ( FromColourBox.SelectedIndex < Enum.GetValues( typeof( JSPImage.MainColors ) ).Length
                && ToColourBox.SelectedIndex < Enum.GetValues( typeof( JSPImage.MainColors ) ).Length )
            {
                ReColourImage( WorkingFile.Images[SelectedImage], 
                    (JSPImage.MainColors) FromColourBox.SelectedIndex, 
                    (JSPImage.MainColors) ToColourBox.SelectedIndex );

                
            }
        }

        private void ReColourImage(JSPImage img, JSPImage.MainColors From, JSPImage.MainColors To)
        {
            int numColors = Enum.GetValues( typeof( JSPImage.MainColors ) ).Length;
            int currentCol = (int) From;

            int diff = 0;
            while ( currentCol != (int) To )
            {
                currentCol = ( currentCol + 1 ) % numColors;
                diff++;
            }

            // diff is now how many block-shifts we have to do so that the colors wind up in the right place.

            byte[] dataWIP = new byte[img.Data.Length];
            img.Data.CopyTo( dataWIP, 0 );

            for ( int i = 0; i < dataWIP.Length; i++ )
            {
                if ( dataWIP[i] > 32 * (int) From && dataWIP[i] < 32 * (int) From + 31 )
                {
                    dataWIP[i] = (byte) ( ( dataWIP[i] + 32 /* Colors per block */ * diff ) % 256 );
                }
            }

            img.SetData( dataWIP );
        }

        private void AllButton_Click( object sender, EventArgs e )
        {
            for ( int i = 0; i < WorkingFile.Images.Count; i++ )
            {
                if ( FromColourBox.SelectedIndex < Enum.GetValues( typeof( JSPImage.MainColors ) ).Length
                && ToColourBox.SelectedIndex < Enum.GetValues( typeof( JSPImage.MainColors ) ).Length )
                {
                    ReColourImage( WorkingFile.Images[i],
                        (JSPImage.MainColors) FromColourBox.SelectedIndex,
                        (JSPImage.MainColors) ToColourBox.SelectedIndex );


                }
            }
        }



       
    }

}