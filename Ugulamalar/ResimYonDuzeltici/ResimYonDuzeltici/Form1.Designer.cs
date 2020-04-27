namespace WindowsFormsApplication1
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
            this.btnBul = new System.Windows.Forms.Button();
            this.btnKlasor = new System.Windows.Forms.Button();
            this.chklstSonuc = new System.Windows.Forms.CheckedListBox();
            this.lstKlasorler = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDur = new System.Windows.Forms.Button();
            this.btnDuzelt = new System.Windows.Forms.Button();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.chkTumu = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBul
            // 
            this.btnBul.Location = new System.Drawing.Point(19, 113);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(111, 25);
            this.btnBul.TabIndex = 5;
            this.btnBul.Text = "Ters resimleri bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // btnKlasor
            // 
            this.btnKlasor.Location = new System.Drawing.Point(6, 19);
            this.btnKlasor.Name = "btnKlasor";
            this.btnKlasor.Size = new System.Drawing.Size(75, 23);
            this.btnKlasor.TabIndex = 6;
            this.btnKlasor.Text = "Klasör seç";
            this.btnKlasor.UseVisualStyleBackColor = true;
            this.btnKlasor.Click += new System.EventHandler(this.btnKlasor_Click);
            // 
            // chklstSonuc
            // 
            this.chklstSonuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstSonuc.CheckOnClick = true;
            this.chklstSonuc.FormattingEnabled = true;
            this.chklstSonuc.Location = new System.Drawing.Point(281, 40);
            this.chklstSonuc.Name = "chklstSonuc";
            this.chklstSonuc.Size = new System.Drawing.Size(422, 139);
            this.chklstSonuc.TabIndex = 7;
            this.chklstSonuc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstSonuc_ItemCheck);
            // 
            // lstKlasorler
            // 
            this.lstKlasorler.FormattingEnabled = true;
            this.lstKlasorler.Location = new System.Drawing.Point(6, 48);
            this.lstKlasorler.Name = "lstKlasorler";
            this.lstKlasorler.Size = new System.Drawing.Size(245, 43);
            this.lstKlasorler.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Temizle";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnKlasor);
            this.groupBox1.Controls.Add(this.lstKlasorler);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Kaldır";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(19, 237);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(684, 261);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(127, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // btnDur
            // 
            this.btnDur.Location = new System.Drawing.Point(137, 114);
            this.btnDur.Name = "btnDur";
            this.btnDur.Size = new System.Drawing.Size(100, 23);
            this.btnDur.TabIndex = 12;
            this.btnDur.Text = "Dur";
            this.btnDur.UseVisualStyleBackColor = true;
            this.btnDur.Click += new System.EventHandler(this.btnDur_Click);
            // 
            // btnDuzelt
            // 
            this.btnDuzelt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuzelt.Location = new System.Drawing.Point(19, 208);
            this.btnDuzelt.Name = "btnDuzelt";
            this.btnDuzelt.Size = new System.Drawing.Size(684, 23);
            this.btnDuzelt.TabIndex = 13;
            this.btnDuzelt.Text = "Düzelt";
            this.btnDuzelt.UseVisualStyleBackColor = true;
            this.btnDuzelt.Click += new System.EventHandler(this.btnDuzelt_Click);
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Location = new System.Drawing.Point(20, 180);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(166, 13);
            this.lblSonuc.TabIndex = 14;
            this.lblSonuc.Text = "Klasör seçimi yapmanız bekleniyor";
            // 
            // chkTumu
            // 
            this.chkTumu.AutoSize = true;
            this.chkTumu.Location = new System.Drawing.Point(281, 17);
            this.chkTumu.Name = "chkTumu";
            this.chkTumu.Size = new System.Drawing.Size(101, 17);
            this.chkTumu.TabIndex = 15;
            this.chkTumu.Text = "Tümünü işaretle";
            this.chkTumu.UseVisualStyleBackColor = true;
            this.chkTumu.CheckedChanged += new System.EventHandler(this.chkTumu_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(628, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 544);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkTumu);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.btnDuzelt);
            this.Controls.Add(this.btnDur);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chklstSonuc);
            this.Controls.Add(this.btnBul);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.Button btnKlasor;
        private System.Windows.Forms.CheckedListBox chklstSonuc;
        private System.Windows.Forms.ListBox lstKlasorler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDur;
        private System.Windows.Forms.Button btnDuzelt;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.CheckBox chkTumu;
        private System.Windows.Forms.Button button3;
    }
}

