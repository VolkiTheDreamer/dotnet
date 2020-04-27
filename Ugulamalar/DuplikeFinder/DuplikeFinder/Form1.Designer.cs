namespace DuplikeFinder2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grpKriter = new System.Windows.Forms.GroupBox();
            this.chkHash = new System.Windows.Forms.CheckBox();
            this.chkAd = new System.Windows.Forms.CheckBox();
            this.chkBoyut = new System.Windows.Forms.CheckBox();
            this.chkTarih = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlFileSize = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkMaxSize = new System.Windows.Forms.CheckBox();
            this.chkMinSize = new System.Windows.Forms.CheckBox();
            this.chklstSonuc = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKlasor = new System.Windows.Forms.Button();
            this.btnTara = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lstKlasorler = new System.Windows.Forms.ListBox();
            this.btnKlasorAllCleam = new System.Windows.Forms.Button();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.chkTumu = new System.Windows.Forms.CheckBox();
            this.btnKlasorSecilenClean = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkUzantiekle = new System.Windows.Forms.CheckBox();
            this.txtUzantekle = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.chklstUzanti = new System.Windows.Forms.CheckedListBox();
            this.lblOrjinalKonum = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnDur = new System.Windows.Forms.Button();
            this.lblOrjResim = new System.Windows.Forms.Label();
            this.lblSeçilenResim = new System.Windows.Forms.Label();
            this.pnlCheckSonuc = new System.Windows.Forms.Panel();
            this.pnlResim = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.picOrjinal = new System.Windows.Forms.PictureBox();
            this.picSecilen = new System.Windows.Forms.PictureBox();
            this.grpKriter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlFileSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCheckSonuc.SuspendLayout();
            this.pnlResim.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrjinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSecilen)).BeginInit();
            this.SuspendLayout();
            // 
            // grpKriter
            // 
            this.grpKriter.BackColor = System.Drawing.Color.Transparent;
            this.grpKriter.Controls.Add(this.chkHash);
            this.grpKriter.Controls.Add(this.chkAd);
            this.grpKriter.Controls.Add(this.chkBoyut);
            this.grpKriter.Controls.Add(this.chkTarih);
            this.grpKriter.Location = new System.Drawing.Point(11, 32);
            this.grpKriter.Name = "grpKriter";
            this.grpKriter.Size = new System.Drawing.Size(112, 120);
            this.grpKriter.TabIndex = 0;
            this.grpKriter.TabStop = false;
            this.grpKriter.Text = "Arama Kriteri";
            // 
            // chkHash
            // 
            this.chkHash.AutoSize = true;
            this.chkHash.Location = new System.Drawing.Point(7, 92);
            this.chkHash.Name = "chkHash";
            this.chkHash.Size = new System.Drawing.Size(93, 17);
            this.chkHash.TabIndex = 3;
            this.chkHash.Text = "Süper Tarama";
            this.toolTip1.SetToolTip(this.chkHash, resources.GetString("chkHash.ToolTip"));
            this.chkHash.UseVisualStyleBackColor = true;
            this.chkHash.CheckedChanged += new System.EventHandler(this.chkHash_CheckedChanged);
            // 
            // chkAd
            // 
            this.chkAd.AutoSize = true;
            this.chkAd.Location = new System.Drawing.Point(7, 68);
            this.chkAd.Name = "chkAd";
            this.chkAd.Size = new System.Drawing.Size(73, 17);
            this.chkAd.TabIndex = 2;
            this.chkAd.Text = "Dosya adı";
            this.chkAd.UseVisualStyleBackColor = true;
            // 
            // chkBoyut
            // 
            this.chkBoyut.AutoSize = true;
            this.chkBoyut.Checked = true;
            this.chkBoyut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoyut.Location = new System.Drawing.Point(7, 44);
            this.chkBoyut.Name = "chkBoyut";
            this.chkBoyut.Size = new System.Drawing.Size(53, 17);
            this.chkBoyut.TabIndex = 1;
            this.chkBoyut.Text = "Boyut";
            this.chkBoyut.UseVisualStyleBackColor = true;
            // 
            // chkTarih
            // 
            this.chkTarih.AutoSize = true;
            this.chkTarih.Checked = true;
            this.chkTarih.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTarih.Location = new System.Drawing.Point(7, 20);
            this.chkTarih.Name = "chkTarih";
            this.chkTarih.Size = new System.Drawing.Size(90, 17);
            this.chkTarih.TabIndex = 0;
            this.chkTarih.Text = "Değişm Tarihi";
            this.toolTip1.SetToolTip(this.chkTarih, resources.GetString("chkTarih.ToolTip"));
            this.chkTarih.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pnlFileSize);
            this.groupBox2.Controls.Add(this.chkMaxSize);
            this.groupBox2.Controls.Add(this.chkMinSize);
            this.groupBox2.Location = new System.Drawing.Point(134, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dosya boyutu";
            this.toolTip1.SetToolTip(this.groupBox2, "Tüm dosyaları değil de boyutu belli limitler arasında olan dosyaları taramak isti" +
        "yorsanız buradan seçim yapabilirsiniz");
            // 
            // pnlFileSize
            // 
            this.pnlFileSize.Controls.Add(this.numericUpDown2);
            this.pnlFileSize.Controls.Add(this.numericUpDown1);
            this.pnlFileSize.Controls.Add(this.comboBox2);
            this.pnlFileSize.Controls.Add(this.comboBox1);
            this.pnlFileSize.Enabled = false;
            this.pnlFileSize.Location = new System.Drawing.Point(56, 19);
            this.pnlFileSize.Name = "pnlFileSize";
            this.pnlFileSize.Size = new System.Drawing.Size(106, 74);
            this.pnlFileSize.TabIndex = 15;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(3, 39);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(3, 13);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownWidth = 42;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB",
            "GB"});
            this.comboBox2.Location = new System.Drawing.Point(55, 39);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(43, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Text = "MB";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB",
            "GB"});
            this.comboBox1.Location = new System.Drawing.Point(55, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(42, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "MB";
            // 
            // chkMaxSize
            // 
            this.chkMaxSize.AutoSize = true;
            this.chkMaxSize.Location = new System.Drawing.Point(7, 59);
            this.chkMaxSize.Name = "chkMaxSize";
            this.chkMaxSize.Size = new System.Drawing.Size(46, 17);
            this.chkMaxSize.TabIndex = 12;
            this.chkMaxSize.Text = "Max";
            this.chkMaxSize.UseVisualStyleBackColor = true;
            this.chkMaxSize.Click += new System.EventHandler(this.chkMinSize_CheckedChanged);
            // 
            // chkMinSize
            // 
            this.chkMinSize.AutoSize = true;
            this.chkMinSize.Location = new System.Drawing.Point(7, 33);
            this.chkMinSize.Name = "chkMinSize";
            this.chkMinSize.Size = new System.Drawing.Size(43, 17);
            this.chkMinSize.TabIndex = 11;
            this.chkMinSize.Text = "Min";
            this.chkMinSize.UseVisualStyleBackColor = true;
            this.chkMinSize.CheckedChanged += new System.EventHandler(this.chkMinSize_CheckedChanged);
            // 
            // chklstSonuc
            // 
            this.chklstSonuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstSonuc.CheckOnClick = true;
            this.chklstSonuc.FormattingEnabled = true;
            this.chklstSonuc.Location = new System.Drawing.Point(4, 21);
            this.chklstSonuc.Name = "chklstSonuc";
            this.chklstSonuc.Size = new System.Drawing.Size(956, 94);
            this.chklstSonuc.TabIndex = 16;
            this.toolTip1.SetToolTip(this.chklstSonuc, "Orjinalini görmek için bir dosyayı işaretleyiniz");
            this.chklstSonuc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstSonuc_ItemCheck);
            this.chklstSonuc.SelectedIndexChanged += new System.EventHandler(this.chklstSonuc_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.yardımToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.BackColor = System.Drawing.Color.Ivory;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // yardımToolStripMenuItem1
            // 
            this.yardımToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.yardımToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hakkındaToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.yardımToolStripMenuItem1.Name = "yardımToolStripMenuItem1";
            this.yardımToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem1.Text = "Yardım";
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.yardımToolStripMenuItem.Text = "Yardım";
            this.yardımToolStripMenuItem.Click += new System.EventHandler(this.yardımToolStripMenuItem_Click);
            // 
            // btnKlasor
            // 
            this.btnKlasor.Location = new System.Drawing.Point(7, 7);
            this.btnKlasor.Name = "btnKlasor";
            this.btnKlasor.Size = new System.Drawing.Size(75, 23);
            this.btnKlasor.TabIndex = 3;
            this.btnKlasor.Text = "Klasör Seç...";
            this.btnKlasor.UseVisualStyleBackColor = true;
            this.btnKlasor.Click += new System.EventHandler(this.btnKlasor_Click);
            // 
            // btnTara
            // 
            this.btnTara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTara.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTara.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnTara.FlatAppearance.BorderSize = 5;
            this.btnTara.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnTara.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTara.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTara.Location = new System.Drawing.Point(11, 191);
            this.btnTara.Name = "btnTara";
            this.btnTara.Size = new System.Drawing.Size(977, 43);
            this.btnTara.TabIndex = 12;
            this.btnTara.Text = "TARAMAYA BAŞLA";
            this.btnTara.UseVisualStyleBackColor = false;
            this.btnTara.Click += new System.EventHandler(this.btnTara_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(11, 416);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(977, 39);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "SEÇİLENLERİ SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Visible = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lstKlasorler
            // 
            this.lstKlasorler.FormattingEnabled = true;
            this.lstKlasorler.Location = new System.Drawing.Point(7, 35);
            this.lstKlasorler.Name = "lstKlasorler";
            this.lstKlasorler.Size = new System.Drawing.Size(280, 56);
            this.lstKlasorler.TabIndex = 17;
            // 
            // btnKlasorAllCleam
            // 
            this.btnKlasorAllCleam.Location = new System.Drawing.Point(88, 7);
            this.btnKlasorAllCleam.Name = "btnKlasorAllCleam";
            this.btnKlasorAllCleam.Size = new System.Drawing.Size(101, 23);
            this.btnKlasorAllCleam.TabIndex = 18;
            this.btnKlasorAllCleam.Text = "Tümünü Temizle";
            this.btnKlasorAllCleam.UseVisualStyleBackColor = true;
            this.btnKlasorAllCleam.Click += new System.EventHandler(this.btnKlsSecimClean_Click);
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.BackColor = System.Drawing.Color.Transparent;
            this.lblSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonuc.ForeColor = System.Drawing.Color.Red;
            this.lblSonuc.Location = new System.Drawing.Point(10, 154);
            this.lblSonuc.MaximumSize = new System.Drawing.Size(600, 35);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(439, 17);
            this.lblSonuc.TabIndex = 19;
            this.lblSonuc.Text = "Tarama için kriter, klasör ve dosya uzantı seçimi bekleniyor";
            // 
            // chkTumu
            // 
            this.chkTumu.AutoSize = true;
            this.chkTumu.Location = new System.Drawing.Point(7, 4);
            this.chkTumu.Name = "chkTumu";
            this.chkTumu.Size = new System.Drawing.Size(85, 17);
            this.chkTumu.TabIndex = 20;
            this.chkTumu.Text = "Tümünü seç";
            this.chkTumu.UseVisualStyleBackColor = true;
            this.chkTumu.CheckedChanged += new System.EventHandler(this.chkTumu_CheckedChanged);
            // 
            // btnKlasorSecilenClean
            // 
            this.btnKlasorSecilenClean.Location = new System.Drawing.Point(195, 7);
            this.btnKlasorSecilenClean.Name = "btnKlasorSecilenClean";
            this.btnKlasorSecilenClean.Size = new System.Drawing.Size(92, 23);
            this.btnKlasorSecilenClean.TabIndex = 21;
            this.btnKlasorSecilenClean.Text = "Seçileni kaldır";
            this.btnKlasorSecilenClean.UseVisualStyleBackColor = true;
            this.btnKlasorSecilenClean.Click += new System.EventHandler(this.btnKlasorSecilenClean_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnKlasorSecilenClean);
            this.panel1.Controls.Add(this.btnKlasorAllCleam);
            this.panel1.Controls.Add(this.btnKlasor);
            this.panel1.Controls.Add(this.lstKlasorler);
            this.panel1.Location = new System.Drawing.Point(314, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 99);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.chkUzantiekle);
            this.panel2.Controls.Add(this.txtUzantekle);
            this.panel2.Controls.Add(this.lblExtension);
            this.panel2.Controls.Add(this.chklstUzanti);
            this.panel2.Location = new System.Drawing.Point(629, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 146);
            this.panel2.TabIndex = 23;
            // 
            // chkUzantiekle
            // 
            this.chkUzantiekle.AutoSize = true;
            this.chkUzantiekle.Location = new System.Drawing.Point(102, 7);
            this.chkUzantiekle.Name = "chkUzantiekle";
            this.chkUzantiekle.Size = new System.Drawing.Size(194, 17);
            this.chkUzantiekle.TabIndex = 3;
            this.chkUzantiekle.Text = "Başka dosya türü eklemek istiyorum";
            this.chkUzantiekle.UseVisualStyleBackColor = true;
            this.chkUzantiekle.CheckedChanged += new System.EventHandler(this.chkUzantiekle_CheckedChanged);
            // 
            // txtUzantekle
            // 
            this.txtUzantekle.Location = new System.Drawing.Point(296, 5);
            this.txtUzantekle.Name = "txtUzantekle";
            this.txtUzantekle.Size = new System.Drawing.Size(53, 20);
            this.txtUzantekle.TabIndex = 2;
            this.txtUzantekle.Visible = false;
            this.txtUzantekle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUzantekle_KeyDown);
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Location = new System.Drawing.Point(7, 7);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(93, 13);
            this.lblExtension.TabIndex = 1;
            this.lblExtension.Text = "Dosya türü seçiniz";
            // 
            // chklstUzanti
            // 
            this.chklstUzanti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstUzanti.CheckOnClick = true;
            this.chklstUzanti.FormattingEnabled = true;
            this.chklstUzanti.Location = new System.Drawing.Point(7, 29);
            this.chklstUzanti.Name = "chklstUzanti";
            this.chklstUzanti.Size = new System.Drawing.Size(342, 109);
            this.chklstUzanti.TabIndex = 0;
            // 
            // lblOrjinalKonum
            // 
            this.lblOrjinalKonum.AutoSize = true;
            this.lblOrjinalKonum.ForeColor = System.Drawing.Color.Red;
            this.lblOrjinalKonum.Location = new System.Drawing.Point(3, 119);
            this.lblOrjinalKonum.Name = "lblOrjinalKonum";
            this.lblOrjinalKonum.Size = new System.Drawing.Size(278, 13);
            this.lblOrjinalKonum.TabIndex = 26;
            this.lblOrjinalKonum.Text = "Not:Orjinalini görmek için yukardan bir dosyayı işaretleyiniz";
            this.lblOrjinalKonum.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnDur
            // 
            this.btnDur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDur.BackColor = System.Drawing.Color.IndianRed;
            this.btnDur.Enabled = false;
            this.btnDur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDur.ForeColor = System.Drawing.Color.White;
            this.btnDur.Location = new System.Drawing.Point(202, 234);
            this.btnDur.Name = "btnDur";
            this.btnDur.Size = new System.Drawing.Size(786, 36);
            this.btnDur.TabIndex = 29;
            this.btnDur.Text = "İPTAL";
            this.btnDur.UseVisualStyleBackColor = false;
            this.btnDur.Visible = false;
            this.btnDur.Click += new System.EventHandler(this.btnDur_Click);
            // 
            // lblOrjResim
            // 
            this.lblOrjResim.AutoSize = true;
            this.lblOrjResim.Location = new System.Drawing.Point(1, 9);
            this.lblOrjResim.Name = "lblOrjResim";
            this.lblOrjResim.Size = new System.Drawing.Size(68, 13);
            this.lblOrjResim.TabIndex = 33;
            this.lblOrjResim.Text = "Orjinal Resim";
            // 
            // lblSeçilenResim
            // 
            this.lblSeçilenResim.AutoSize = true;
            this.lblSeçilenResim.Location = new System.Drawing.Point(354, 8);
            this.lblSeçilenResim.Name = "lblSeçilenResim";
            this.lblSeçilenResim.Size = new System.Drawing.Size(69, 13);
            this.lblSeçilenResim.TabIndex = 34;
            this.lblSeçilenResim.Text = "İşaretli Resim";
            // 
            // pnlCheckSonuc
            // 
            this.pnlCheckSonuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckSonuc.BackColor = System.Drawing.Color.Transparent;
            this.pnlCheckSonuc.Controls.Add(this.chkTumu);
            this.pnlCheckSonuc.Controls.Add(this.chklstSonuc);
            this.pnlCheckSonuc.Controls.Add(this.lblOrjinalKonum);
            this.pnlCheckSonuc.Location = new System.Drawing.Point(12, 274);
            this.pnlCheckSonuc.Name = "pnlCheckSonuc";
            this.pnlCheckSonuc.Size = new System.Drawing.Size(976, 136);
            this.pnlCheckSonuc.TabIndex = 35;
            this.pnlCheckSonuc.Visible = false;
            // 
            // pnlResim
            // 
            this.pnlResim.Controls.Add(this.lblSeçilenResim);
            this.pnlResim.Controls.Add(this.lblOrjResim);
            this.pnlResim.Controls.Add(this.picOrjinal);
            this.pnlResim.Controls.Add(this.picSecilen);
            this.pnlResim.Location = new System.Drawing.Point(141, 461);
            this.pnlResim.Name = "pnlResim";
            this.pnlResim.Size = new System.Drawing.Size(631, 219);
            this.pnlResim.TabIndex = 36;
            this.pnlResim.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(84, 11);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 28;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(175, 29);
            this.progressBar1.TabIndex = 32;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.progressBar1);
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Location = new System.Drawing.Point(11, 234);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(185, 36);
            this.pnlProgress.TabIndex = 37;
            this.pnlProgress.Visible = false;
            // 
            // picOrjinal
            // 
            this.picOrjinal.Location = new System.Drawing.Point(4, 25);
            this.picOrjinal.Name = "picOrjinal";
            this.picOrjinal.Size = new System.Drawing.Size(267, 183);
            this.picOrjinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOrjinal.TabIndex = 31;
            this.picOrjinal.TabStop = false;
            // 
            // picSecilen
            // 
            this.picSecilen.Location = new System.Drawing.Point(354, 25);
            this.picSecilen.Name = "picSecilen";
            this.picSecilen.Size = new System.Drawing.Size(267, 183);
            this.picSecilen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSecilen.TabIndex = 30;
            this.picSecilen.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1000, 688);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlResim);
            this.Controls.Add(this.pnlCheckSonuc);
            this.Controls.Add(this.btnDur);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnTara);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpKriter);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volkan\'s Duplike Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpKriter.ResumeLayout(false);
            this.grpKriter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlFileSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCheckSonuc.ResumeLayout(false);
            this.pnlCheckSonuc.PerformLayout();
            this.pnlResim.ResumeLayout(false);
            this.pnlResim.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrjinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSecilen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox grpKriter;
        private System.Windows.Forms.CheckBox chkAd;
        private System.Windows.Forms.CheckBox chkBoyut;
        private System.Windows.Forms.CheckBox chkTarih;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.Button btnKlasor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkMaxSize;
        private System.Windows.Forms.CheckBox chkMinSize;
        private System.Windows.Forms.Button btnTara;
        private System.Windows.Forms.CheckBox chkHash;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox chklstSonuc;
        private System.Windows.Forms.ListBox lstKlasorler;
        private System.Windows.Forms.Button btnKlasorAllCleam;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.CheckBox chkTumu;
        private System.Windows.Forms.Button btnKlasorSecilenClean;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox chklstUzanti;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.CheckBox chkUzantiekle;
        private System.Windows.Forms.TextBox txtUzantekle;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.Label lblOrjinalKonum;
        private System.Windows.Forms.Panel pnlFileSize;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDur;
        private System.Windows.Forms.PictureBox picSecilen;
        private System.Windows.Forms.PictureBox picOrjinal;
        private System.Windows.Forms.Label lblOrjResim;
        private System.Windows.Forms.Label lblSeçilenResim;
        private System.Windows.Forms.Panel pnlCheckSonuc;
        private System.Windows.Forms.Panel pnlResim;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlProgress;
    }
}

