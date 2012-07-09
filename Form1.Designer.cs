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
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ExportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ConfigButton = new System.Windows.Forms.ToolStripSplitButton();
            this.CountLabel = new System.Windows.Forms.Label();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.ofYBox = new System.Windows.Forms.TextBox();
            this.ofXBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FromColourBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ToColourBox = new System.Windows.Forms.ComboBox();
            this.FromBox = new System.Windows.Forms.Panel();
            this.ToBox = new System.Windows.Forms.Panel();
            this.mainDisplayArea = new JspEdit.ImageDisplay();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size( 24, 24 );
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
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
            this.toolStrip1.Size = new System.Drawing.Size( 792, 31 );
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "newButton.Image" ) ) );
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size( 28, 28 );
            this.newButton.Text = "New ";
            this.newButton.Click += new System.EventHandler( this.newButton_Click );
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "OpenButton.Image" ) ) );
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size( 28, 28 );
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler( this.OpenButton_Click );
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "SaveButton.Image" ) ) );
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size( 28, 28 );
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler( this.SaveButton_Click );
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "SaveAsButton.Image" ) ) );
            this.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size( 28, 28 );
            this.SaveAsButton.Text = "SaveAs";
            this.SaveAsButton.Click += new System.EventHandler( this.SaveAsButton_Click );
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
            this.ImportFolder} );
            this.ImportButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "ImportButton.Image" ) ) );
            this.ImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size( 37, 28 );
            this.ImportButton.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size( 150, 22 );
            this.exportToolStripMenuItem.Text = "Import Sprite";
            this.exportToolStripMenuItem.Click += new System.EventHandler( this.ImportButton_Click );
            // 
            // ImportFolder
            // 
            this.ImportFolder.Name = "ImportFolder";
            this.ImportFolder.Size = new System.Drawing.Size( 150, 22 );
            this.ImportFolder.Text = "Import Folder";
            this.ImportFolder.Click += new System.EventHandler( this.importFolder_Click );
            // 
            // ExportButton
            // 
            this.ExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportButton.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.ExportItem,
            this.exportFolder} );
            this.ExportButton.Image = ( (System.Drawing.Image) ( resources.GetObject( "ExportButton.Image" ) ) );
            this.ExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size( 37, 28 );
            this.ExportButton.Text = "Export";
            // 
            // ExportItem
            // 
            this.ExportItem.Name = "ExportItem";
            this.ExportItem.Size = new System.Drawing.Size( 148, 22 );
            this.ExportItem.Text = "Export Sprite";
            this.ExportItem.Click += new System.EventHandler( this.ExportItem_Click );
            // 
            // exportFolder
            // 
            this.exportFolder.Name = "exportFolder";
            this.exportFolder.Size = new System.Drawing.Size( 148, 22 );
            this.exportFolder.Text = "Export JSP";
            this.exportFolder.Click += new System.EventHandler( this.exportFolder_Click );
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
            this.ConfigButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size( 16, 28 );
            this.ConfigButton.Text = "Configuration";
            this.ConfigButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // CountLabel
            // 
            this.CountLabel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.CountLabel.AutoSize = true;
            this.CountLabel.Font = new System.Drawing.Font( "Verdana", 10F );
            this.CountLabel.Location = new System.Drawing.Point( 78, 540 );
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size( 98, 17 );
            this.CountLabel.TabIndex = 2;
            this.CountLabel.Text = "Sprite X of Y";
            // 
            // UpButton
            // 
            this.UpButton.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "UpButton.BackgroundImage" ) ) );
            this.UpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpButton.Location = new System.Drawing.Point( 12, 36 );
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size( 32, 32 );
            this.UpButton.TabIndex = 3;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler( this.UpButton_Click );
            // 
            // DownButton
            // 
            this.DownButton.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "DownButton.BackgroundImage" ) ) );
            this.DownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DownButton.Location = new System.Drawing.Point( 12, 74 );
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size( 32, 32 );
            this.DownButton.TabIndex = 4;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler( this.DownButton_Click );
            // 
            // DelButton
            // 
            this.DelButton.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.DelButton.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "DelButton.BackgroundImage" ) ) );
            this.DelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DelButton.Location = new System.Drawing.Point( 12, 505 );
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size( 32, 32 );
            this.DelButton.TabIndex = 5;
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler( this.DelButton_Click );
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label2.Location = new System.Drawing.Point( 209, 48 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 17 );
            this.label2.TabIndex = 6;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label3.Location = new System.Drawing.Point( 209, 78 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 50, 17 );
            this.label3.TabIndex = 7;
            this.label3.Text = "Width";
            // 
            // HeightBox
            // 
            this.HeightBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HeightBox.BackColor = System.Drawing.Color.White;
            this.HeightBox.Location = new System.Drawing.Point( 329, 48 );
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.ReadOnly = true;
            this.HeightBox.Size = new System.Drawing.Size( 100, 20 );
            this.HeightBox.TabIndex = 8;
            // 
            // WidthBox
            // 
            this.WidthBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WidthBox.BackColor = System.Drawing.Color.White;
            this.WidthBox.Location = new System.Drawing.Point( 329, 79 );
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.ReadOnly = true;
            this.WidthBox.Size = new System.Drawing.Size( 100, 20 );
            this.WidthBox.TabIndex = 9;
            // 
            // ofYBox
            // 
            this.ofYBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ofYBox.BackColor = System.Drawing.Color.White;
            this.ofYBox.Location = new System.Drawing.Point( 555, 79 );
            this.ofYBox.Name = "ofYBox";
            this.ofYBox.Size = new System.Drawing.Size( 100, 20 );
            this.ofYBox.TabIndex = 13;
            this.ofYBox.TextChanged += new System.EventHandler( this.ofXBox_TextChanged );
            // 
            // ofXBox
            // 
            this.ofXBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ofXBox.BackColor = System.Drawing.Color.White;
            this.ofXBox.Location = new System.Drawing.Point( 555, 48 );
            this.ofXBox.Name = "ofXBox";
            this.ofXBox.Size = new System.Drawing.Size( 100, 20 );
            this.ofXBox.TabIndex = 12;
            this.ofXBox.TextChanged += new System.EventHandler( this.ofXBox_TextChanged );
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label4.Location = new System.Drawing.Point( 435, 78 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 63, 17 );
            this.label4.TabIndex = 11;
            this.label4.Text = "Origin Y";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label5.Location = new System.Drawing.Point( 435, 48 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 64, 17 );
            this.label5.TabIndex = 10;
            this.label5.Text = "Origin X";
            // 
            // panel1
            // 
            this.panel1.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left ) ) );
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point( 51, 36 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 153, 501 );
            this.panel1.TabIndex = 15;
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler( this.panel1_MouseWheel );
            // 
            // FromColourBox
            // 
            this.FromColourBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FromColourBox.FormattingEnabled = true;
            this.FromColourBox.Items.AddRange( new object[] {
            "Grey",
            "Green",
            "Brown",
            "Blue",
            "Red",
            "Yellow",
            "Purple",
            "Cyan"} );
            this.FromColourBox.Location = new System.Drawing.Point( 329, 123 );
            this.FromColourBox.Name = "FromColourBox";
            this.FromColourBox.Size = new System.Drawing.Size( 100, 21 );
            this.FromColourBox.TabIndex = 17;
            this.FromColourBox.SelectedIndexChanged += new System.EventHandler( this.ColourBox_SelectedIndexChanged );
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label1.Location = new System.Drawing.Point( 262, 125 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 61, 17 );
            this.label1.TabIndex = 18;
            this.label1.Text = "Replace";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font( "Verdana", 10F );
            this.label6.Location = new System.Drawing.Point( 465, 125 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 37, 17 );
            this.label6.TabIndex = 19;
            this.label6.Text = "with";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point( 643, 122 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 21;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ToColourBox
            // 
            this.ToColourBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ToColourBox.FormattingEnabled = true;
            this.ToColourBox.Items.AddRange( new object[] {
            "Grey",
            "Green",
            "Brown",
            "Blue",
            "Red",
            "Yellow",
            "Purple",
            "Cyan"} );
            this.ToColourBox.Location = new System.Drawing.Point( 537, 123 );
            this.ToColourBox.Name = "ToColourBox";
            this.ToColourBox.Size = new System.Drawing.Size( 100, 21 );
            this.ToColourBox.TabIndex = 22;
            this.ToColourBox.SelectedIndexChanged += new System.EventHandler( this.ColourBox_SelectedIndexChanged );
            // 
            // FromBox
            // 
            this.FromBox.BackColor = System.Drawing.Color.White;
            this.FromBox.Location = new System.Drawing.Point( 436, 122 );
            this.FromBox.Name = "FromBox";
            this.FromBox.Size = new System.Drawing.Size( 23, 23 );
            this.FromBox.TabIndex = 23;
            // 
            // ToBox
            // 
            this.ToBox.BackColor = System.Drawing.Color.White;
            this.ToBox.Location = new System.Drawing.Point( 508, 122 );
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size( 23, 23 );
            this.ToBox.TabIndex = 24;
            // 
            // mainDisplayArea
            // 
            this.mainDisplayArea.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.mainDisplayArea.BackColor = System.Drawing.Color.White;
            this.mainDisplayArea.BackgroundImage = ( (System.Drawing.Image) ( resources.GetObject( "mainDisplayArea.BackgroundImage" ) ) );
            this.mainDisplayArea.Centered = true;
            this.mainDisplayArea.DrawOrigin = true;
            this.mainDisplayArea.Image = null;
            this.mainDisplayArea.Location = new System.Drawing.Point( 210, 174 );
            this.mainDisplayArea.Name = "mainDisplayArea";
            this.mainDisplayArea.Size = new System.Drawing.Size( 570, 363 );
            this.mainDisplayArea.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 792, 566 );
            this.Controls.Add( this.ToBox );
            this.Controls.Add( this.FromBox );
            this.Controls.Add( this.ToColourBox );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.FromColourBox );
            this.Controls.Add( this.mainDisplayArea );
            this.Controls.Add( this.panel1 );
            this.Controls.Add( this.ofYBox );
            this.Controls.Add( this.ofXBox );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.WidthBox );
            this.Controls.Add( this.HeightBox );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.DelButton );
            this.Controls.Add( this.DownButton );
            this.Controls.Add( this.UpButton );
            this.Controls.Add( this.CountLabel );
            this.Controls.Add( this.toolStrip1 );
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "JSP Edit";
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem ImportFolder;
        private System.Windows.Forms.ToolStripDropDownButton ExportButton;
        private System.Windows.Forms.ToolStripMenuItem ExportItem;
        private System.Windows.Forms.ToolStripMenuItem exportFolder;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.TextBox ofYBox;
        private System.Windows.Forms.TextBox ofXBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private ImageDisplay mainDisplayArea;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ComboBox FromColourBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ToColourBox;
        private System.Windows.Forms.Panel FromBox;
        private System.Windows.Forms.Panel ToBox;

    }
}

