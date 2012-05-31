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

        JSP output;

        private void MainForm_Paint( object sender, PaintEventArgs e )
        {
            if ( output != null )
            {
                var G = pictureBox1.CreateGraphics();
                int w = 0;
                for ( int i = 0; i < output.Images.Count; i++ )
                {
                    G.DrawImage( output.Images[i].ToBitmap(), w + output.Images[i].OfsX, output.Images[i].OfsY );
                    w += output.Images[i].Width;
                }
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
        }

        private void LoadJSP( string name )
        {
            output = JSPFactory.Load(
                new System.IO.BinaryReader(
                    new System.IO.FileStream( name, System.IO.FileMode.Open )
                    )
                );
        }


    }
}
