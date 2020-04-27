namespace C_Sharp_Form_Listing_File_Folder_Directory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.grouper1.SuspendLayout();
            this.grouper2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.BackColor = System.Drawing.Color.Bisque;
            this.treeViewFolders.HideSelection = false;
            this.treeViewFolders.Location = new System.Drawing.Point(13, 35);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(315, 329);
            this.treeViewFolders.TabIndex = 5;
            this.treeViewFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterExpand);
            this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.IndianRed;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.Pink;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper1.BorderColor = System.Drawing.Color.Black;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.treeViewFolders);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "FOLDERS";
            this.grouper1.Location = new System.Drawing.Point(12, 22);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(343, 378);
            this.grouper1.TabIndex = 7;
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.Color.IndianRed;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.Pink;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Black;
            this.grouper2.BorderThickness = 1F;
            this.grouper2.Controls.Add(this.lstFiles);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "FILES";
            this.grouper2.Location = new System.Drawing.Point(361, 22);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(20);
            this.grouper2.PaintGroupBox = false;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper2.ShadowControl = false;
            this.grouper2.ShadowThickness = 3;
            this.grouper2.Size = new System.Drawing.Size(246, 378);
            this.grouper2.TabIndex = 8;
            // 
            // lstFiles
            // 
            this.lstFiles.BackColor = System.Drawing.Color.Bisque;
            this.lstFiles.Location = new System.Drawing.Point(10, 35);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(225, 329);
            this.lstFiles.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(623, 413);
            this.Controls.Add(this.grouper2);
            this.Controls.Add(this.grouper1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LIST FILES & FOLDERS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grouper1.ResumeLayout(false);
            this.grouper2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView treeViewFolders;
        private CodeVendor.Controls.Grouper grouper1;
        private CodeVendor.Controls.Grouper grouper2;
        internal System.Windows.Forms.ListBox lstFiles;
    }
}

