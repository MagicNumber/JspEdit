using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace JspEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new MainForm() );
            }
#if !DEBUG
            catch ( Exception e )
            {
                try
                {
                    string filename = string.Format( "crit_error_{0}{1}{2}.txt", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day );

                    string path = Environment.CommandLine.Substring( 1, Environment.CommandLine.LastIndexOf( '\\' ) );
                    // Because the FileSelect dialog changes the cwd, we need to grab it from arg[0]
                    // Start from index 1 to get rid of a leading quote mark

                    using ( StreamWriter f = new StreamWriter( path + "\\" + filename, true ) )
                    {
                        f.WriteLine( e.Message );
                        f.Write( e.StackTrace );
                    }
                    MessageBox.Show( "Something catastrophic happened. Look at " + filename + " for details." );
                }
                catch ( IOException veryBadE )
                {
                    MessageBox.Show( "Something catastrophic happened, and we can't write out files. This is awkard." );
                    return;
                }
            }
#endif // We want an error to go up to the debugger if it's there, but if it's not there handle it.
            finally
            {
            }


        }
    }
}
