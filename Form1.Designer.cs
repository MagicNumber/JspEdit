namespace JspEdit
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MainForm ) );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfigButton = new System.Windows.Forms.ToolStripSplitButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size( 24, 24 );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.SaveAsButton,
            this.toolStripSeparator2,
            this.ImportButton,
            this.ExportButton,
            this.toolStripSeparator1,
            this.ConfigButton} );
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 717, 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "OpenButton.Image" ) ) );
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size( 28, 28 );
            this.OpenButton.Text = "Open";
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "SaveButton.Image" ) ) );
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size( 28, 28 );
            this.SaveButton.Text = "Save";
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "SaveAsButton.Image" ) ) );
            this.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size( 28, 28 );
            this.SaveAsButton.Text = "SaveAs";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size( 6, 31 );
            // 
            // ImportButton
            // 
            this.ImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ImportButton.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importFolderToolStripMenuItem} );
            this.ImportButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "ImportButton.Image" ) ) );
            this.ImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size( 37, 28 );
            this.ImportButton.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
            this.exportToolStripMenuItem.Text = "Import Sprite";
            // 
            // importFolderToolStripMenuItem
            // 
            this.importFolderToolStripMenuItem.Name = "importFolderToolStripMenuItem";
            this.importFolderToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
            this.importFolderToolStripMenuItem.Text = "Import Folder";
            // 
            // ExportButton
            // 
            this.ExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportButton.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem1,
            this.exportFolderToolStripMenuItem} );
            this.ExportButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "ExportButton.Image" ) ) );
            this.ExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size( 37, 28 );
            this.ExportButton.Text = "Export";
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size( 152, 22 );
            this.exportToolStripMenuItem1.Text = "Export Sprite";
            // 
            // exportFolderToolStripMenuItem
            // 
            this.exportFolderToolStripMenuItem.Name = "exportFolderToolStripMenuItem";
            this.exportFolderToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
            this.exportFolderToolStripMenuItem.Text = "Export JSP";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 31 );
            // 
            // ConfigButton
            // 
            this.ConfigButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ConfigButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ConfigButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "ConfigButton.Image" ) ) );
            this.ConfigButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size( 40, 28 );
            this.ConfigButton.Text = "Configuration";
            this.ConfigButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point( 50, 34 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 154, 447 );
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label1.Location = new System.Drawing.Point( 66, 484 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 98, 17 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Sprite X of Y";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "button1.BackgroundImage" ) ) );
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point( 12, 36 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 32, 32 );
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "button2.BackgroundImage" ) ) );
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point( 12, 74 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 32, 32 );
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::JspEdit.Properties.Resources.edit_remove;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point( 12, 449 );
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size( 32, 32 );
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::JspEdit.Properties.Resources.edit_add;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point( 12, 411 );
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size( 32, 32 );
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label2.Location = new System.Drawing.Point( 210, 48 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 17 );
            this.label2.TabIndex = 6;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label3.Location = new System.Drawing.Point( 210, 78 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 50, 17 );
            this.label3.TabIndex = 7;
            this.label3.Text = "Width";
            // 
            // HeightBox
            // 
            this.HeightBox.BackColor = System.Drawing.Color.White;
            this.HeightBox.Location = new System.Drawing.Point( 330, 48 );
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.ReadOnly = true;
            this.HeightBox.Size = new System.Drawing.Size( 100, 20 );
            this.HeightBox.TabIndex = 8;
            // 
            // WidthBox
            // 
            this.WidthBox.BackColor = System.Drawing.Color.White;
            this.WidthBox.Location = new System.Drawing.Point( 330, 79 );
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.ReadOnly = true;
            this.WidthBox.Size = new System.Drawing.Size( 100, 20 );
            this.WidthBox.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point( 556, 79 );
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size( 100, 20 );
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point( 556, 48 );
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size( 100, 20 );
            this.textBox2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label4.Location = new System.Drawing.Point( 436, 78 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 63, 17 );
            this.label4.TabIndex = 11;
            this.label4.Text = "Origin Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label5.Location = new System.Drawing.Point( 436, 48 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 64, 17 );
            this.label5.TabIndex = 10;
            this.label5.Text = "Origin X";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point( 213, 184 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 492, 297 );
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 717, 510 );
            this.Controls.Add( this.pictureBox1 );
            this.Controls.Add( this.textBox1 );
            this.Controls.Add( this.textBox2 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.WidthBox );
            this.Controls.Add( this.HeightBox );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.button4 );
            this.Controls.Add( this.button3 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.toolStrip1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "JSP Edit";
            this.Load += new System.EventHandler( this.MainForm_Load );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize) ( this.pictureBox1 ) ).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton SaveAsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton ConfigButton;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton ImportButton;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton ExportButton;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportFolderToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

