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
        readonly Size thumbnailSize = new Size( 1000, 48 );


        public MainForm()
        {
            InitializeComponent();
        }

        JSP output;

        private void MainForm_Paint( object sender, PaintEventArgs e )
        {
            if ( output != null )
            {
                var G = pictureBox1.CreateGraphics();
                //int w = 0;
                /*for ( int i = 0; i < output.Images.Count; i++ )
                {*/
                int i = 0;
                    G.DrawImage( output.Images[i].ToBitmap(), 0, 0 );
                   // w += output.Images[i].Width;
                //}
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
            this.Invalidate();
        }

        


        private void LoadJSP( string name )
        {
            output = JSPFactory.Load(
                new System.IO.BinaryReader(
                    new System.IO.FileStream( name, System.IO.FileMode.Open )
                    )
                );
            HeightBox.Text = output.Images[0].Width.ToString();
            WidthBox.Text = output.Images[0].Height.ToString();


            imageList1.Images.Clear();
            int i = 0;

            

            foreach ( JSPImage item in output.Images )
            {
                Bitmap orig = item.ToBitmap();
                Bitmap thumbnail = new Bitmap( thumbnailSize.Width, thumbnailSize.Height );
                Graphics gx = Graphics.FromImage( thumbnail );
                gx.DrawImage( orig, x: 0, y: 0, width: thumbnail.Width, height: thumbnail.Height );

                imageList1.Images.Add( thumbnail );
                listView1.Items.Add( "", i++ );
            }

            label1.Text = output.Images.Count.ToString();

            listView1.LargeImageList = imageList1;
            listView1.View = View.LargeIcon;
            listView1.Invalidate();
        }


    }
}
