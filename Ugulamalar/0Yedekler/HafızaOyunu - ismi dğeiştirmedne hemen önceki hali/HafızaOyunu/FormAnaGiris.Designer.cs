namespace HafızaOyunu
{
    partial class FormAnaGiris
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnDifficult = new System.Windows.Forms.Button();
            this.gbPicSource = new System.Windows.Forms.GroupBox();
            this.cbKategoriler = new System.Windows.Forms.ComboBox();
            this.rbPicFromPC = new System.Windows.Forms.RadioButton();
            this.rbPicFromProgram = new System.Windows.Forms.RadioButton();
            this.picBoxSound = new System.Windows.Forms.PictureBox();
            this.gbPicSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSound)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEasy
            // 
            this.btnEasy.Location = new System.Drawing.Point(24, 128);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(125, 38);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Kolay (4*3)";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.Location = new System.Drawing.Point(165, 128);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(125, 38);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Orta (5*4)";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnDifficult
            // 
            this.btnDifficult.Location = new System.Drawing.Point(305, 128);
            this.btnDifficult.Name = "btnDifficult";
            this.btnDifficult.Size = new System.Drawing.Size(125, 38);
            this.btnDifficult.TabIndex = 2;
            this.btnDifficult.Text = "Zor (6*5)";
            this.btnDifficult.UseVisualStyleBackColor = true;
            this.btnDifficult.Click += new System.EventHandler(this.btnDifficult_Click);
            // 
            // gbPicSource
            // 
            this.gbPicSource.Controls.Add(this.cbKategoriler);
            this.gbPicSource.Controls.Add(this.rbPicFromPC);
            this.gbPicSource.Controls.Add(this.rbPicFromProgram);
            this.gbPicSource.Location = new System.Drawing.Point(24, 34);
            this.gbPicSource.Name = "gbPicSource";
            this.gbPicSource.Size = new System.Drawing.Size(406, 75);
            this.gbPicSource.TabIndex = 3;
            this.gbPicSource.TabStop = false;
            this.gbPicSource.Text = "Resim Kaynağı";
            // 
            // cbKategoriler
            // 
            this.cbKategoriler.FormattingEnabled = true;
            this.cbKategoriler.Items.AddRange(new object[] {
            "Hayvanlar",
            "Sebze Meyveler",
            "Süper kahraman",
            "ÇizgiFilm Kahramanı",
            "Uzay"});
            this.cbKategoriler.Location = new System.Drawing.Point(263, 19);
            this.cbKategoriler.Name = "cbKategoriler";
            this.cbKategoriler.Size = new System.Drawing.Size(121, 21);
            this.cbKategoriler.TabIndex = 2;
            this.cbKategoriler.Text = "Hayvanlar";
            // 
            // rbPicFromPC
            // 
            this.rbPicFromPC.AutoSize = true;
            this.rbPicFromPC.Location = new System.Drawing.Point(24, 42);
            this.rbPicFromPC.Name = "rbPicFromPC";
            this.rbPicFromPC.Size = new System.Drawing.Size(242, 17);
            this.rbPicFromPC.TabIndex = 1;
            this.rbPicFromPC.Text = "Resimleri bilgisayarımdan almak için klasör seç";
            this.rbPicFromPC.UseVisualStyleBackColor = true;
            this.rbPicFromPC.CheckedChanged += new System.EventHandler(this.rbPicFromPC_CheckedChanged);
            // 
            // rbPicFromProgram
            // 
            this.rbPicFromProgram.AutoSize = true;
            this.rbPicFromProgram.Checked = true;
            this.rbPicFromProgram.Location = new System.Drawing.Point(24, 19);
            this.rbPicFromProgram.Name = "rbPicFromProgram";
            this.rbPicFromProgram.Size = new System.Drawing.Size(181, 17);
            this.rbPicFromProgram.TabIndex = 0;
            this.rbPicFromProgram.TabStop = true;
            this.rbPicFromProgram.Text = "Resimler programın içinden gelsin";
            this.rbPicFromProgram.UseVisualStyleBackColor = true;
            // 
            // picBoxSound
            // 
            this.picBoxSound.Image = global::HafızaOyunu.Properties.Resources.sound;
            this.picBoxSound.Location = new System.Drawing.Point(399, 4);
            this.picBoxSound.Name = "picBoxSound";
            this.picBoxSound.Size = new System.Drawing.Size(31, 30);
            this.picBoxSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSound.TabIndex = 4;
            this.picBoxSound.TabStop = false;
            this.picBoxSound.Click += new System.EventHandler(this.picBoxSound_Click);
            // 
            // FormAnaGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(450, 182);
            this.Controls.Add(this.picBoxSound);
            this.Controls.Add(this.gbPicSource);
            this.Controls.Add(this.btnDifficult);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Name = "FormAnaGiris";
            this.Text = "Self Memory";
            this.gbPicSource.ResumeLayout(false);
            this.gbPicSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnDifficult;
        private System.Windows.Forms.GroupBox gbPicSource;
        private System.Windows.Forms.RadioButton rbPicFromPC;
        private System.Windows.Forms.RadioButton rbPicFromProgram;
        private System.Windows.Forms.ComboBox cbKategoriler;
        private System.Windows.Forms.PictureBox picBoxSound;
    }
}

