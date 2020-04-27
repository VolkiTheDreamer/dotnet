namespace HTMLElementiciGetirici
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTagOrClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbPage = new System.Windows.Forms.RadioButton();
            this.rbSitemap = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(139, 45);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(403, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "https://www.excelinefendisi.com/Sitemap.xml";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(6, 48);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(90, 13);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "Tek Sayfa URL\'si";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tagler veya class/idler";
            // 
            // txtTagOrClass
            // 
            this.txtTagOrClass.Location = new System.Drawing.Point(139, 76);
            this.txtTagOrClass.Name = "txtTagOrClass";
            this.txtTagOrClass.Size = new System.Drawing.Size(403, 20);
            this.txtTagOrClass.TabIndex = 3;
            this.txtTagOrClass.Text = "Aralarında ; olacak şekilde girin(şimdilik saece tek class";
            this.txtTagOrClass.Enter += new System.EventHandler(this.txtTagOrClass_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 91);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // rbPage
            // 
            this.rbPage.AutoSize = true;
            this.rbPage.Checked = true;
            this.rbPage.Location = new System.Drawing.Point(6, 19);
            this.rbPage.Name = "rbPage";
            this.rbPage.Size = new System.Drawing.Size(106, 17);
            this.rbPage.TabIndex = 5;
            this.rbPage.TabStop = true;
            this.rbPage.Text = "Tek sayfa URL\'si";
            this.rbPage.UseVisualStyleBackColor = true;
            this.rbPage.CheckedChanged += new System.EventHandler(this.rbPage_CheckedChanged);
            // 
            // rbSitemap
            // 
            this.rbSitemap.AutoSize = true;
            this.rbSitemap.Location = new System.Drawing.Point(136, 19);
            this.rbSitemap.Name = "rbSitemap";
            this.rbSitemap.Size = new System.Drawing.Size(115, 17);
            this.rbSitemap.TabIndex = 6;
            this.rbSitemap.Text = "Sitemap.xml URL\'si";
            this.rbSitemap.UseVisualStyleBackColor = true;
            this.rbSitemap.CheckedChanged += new System.EventHandler(this.rbPage_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(33, 137);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(166, 30);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Çalıştır";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 213);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(162, 22);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSitemap);
            this.groupBox1.Controls.Add(this.rbPage);
            this.groupBox1.Controls.Add(this.lblUrl);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTagOrClass);
            this.groupBox1.Location = new System.Drawing.Point(33, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 107);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "HTML Element İçi Getirici";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTagOrClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbPage;
        private System.Windows.Forms.RadioButton rbSitemap;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}

