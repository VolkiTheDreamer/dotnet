namespace Listbox_ve_CheckedListbox
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
            this.btnRasgeleNumber = new System.Windows.Forms.Button();
            this.btnChkRemoveChekliler = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnMoveSelected = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chkChkListTumunuIsaretle = new System.Windows.Forms.CheckBox();
            this.btnChkClearAll = new System.Windows.Forms.Button();
            this.btnRasgeleHarf = new System.Windows.Forms.Button();
            this.chkListBxtumunusec = new System.Windows.Forms.CheckBox();
            this.btnListRemoveSecili = new System.Windows.Forms.Button();
            this.btnListClearAll = new System.Windows.Forms.Button();
            this.btnListRemoveMultiselect = new System.Windows.Forms.Button();
            this.btnListSecimCancel = new System.Windows.Forms.Button();
            this.btnChkIsaretCancel = new System.Windows.Forms.Button();
            this.chkItemCheckKontrol = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.rdList = new System.Windows.Forms.RadioButton();
            this.rdChkList = new System.Windows.Forms.RadioButton();
            this.btnIndexliIsaretdurumu = new System.Windows.Forms.Button();
            this.btnIndexliSecimdurumu = new System.Windows.Forms.Button();
            this.btnIndexliIsaretClear = new System.Windows.Forms.Button();
            this.btnIndexliIsaretle = new System.Windows.Forms.Button();
            this.btnIndexliSecimiclear = new System.Windows.Forms.Button();
            this.btnIndexliSec = new System.Windows.Forms.Button();
            this.txtIndexforChkList = new System.Windows.Forms.TextBox();
            this.btnChkRemoveChekli = new System.Windows.Forms.Button();
            this.btnListIndex = new System.Windows.Forms.Button();
            this.txtListVarmi = new System.Windows.Forms.TextBox();
            this.btnListVarmi = new System.Windows.Forms.Button();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRasgeleNumber
            // 
            this.btnRasgeleNumber.Location = new System.Drawing.Point(22, 10);
            this.btnRasgeleNumber.Name = "btnRasgeleNumber";
            this.btnRasgeleNumber.Size = new System.Drawing.Size(138, 27);
            this.btnRasgeleNumber.TabIndex = 0;
            this.btnRasgeleNumber.Text = "Rasgele sayı ekle";
            this.btnRasgeleNumber.UseVisualStyleBackColor = true;
            this.btnRasgeleNumber.Click += new System.EventHandler(this.btnRasgeleNumber_Click);
            // 
            // btnChkRemoveChekliler
            // 
            this.btnChkRemoveChekliler.Location = new System.Drawing.Point(127, 285);
            this.btnChkRemoveChekliler.Name = "btnChkRemoveChekliler";
            this.btnChkRemoveChekliler.Size = new System.Drawing.Size(125, 25);
            this.btnChkRemoveChekliler.TabIndex = 1;
            this.btnChkRemoveChekliler.Text = "İşaretlileri uçur(çoklu)";
            this.btnChkRemoveChekliler.UseVisualStyleBackColor = true;
            this.btnChkRemoveChekliler.Click += new System.EventHandler(this.btnChkRemoveChekliler_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(22, 85);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(248, 199);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // btnMoveSelected
            // 
            this.btnMoveSelected.Location = new System.Drawing.Point(276, 149);
            this.btnMoveSelected.Name = "btnMoveSelected";
            this.btnMoveSelected.Size = new System.Drawing.Size(76, 41);
            this.btnMoveSelected.TabIndex = 3;
            this.btnMoveSelected.Text = "seçilenleri yana taşı >>";
            this.btnMoveSelected.UseVisualStyleBackColor = true;
            this.btnMoveSelected.Click += new System.EventHandler(this.btnMoveSelected_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(358, 85);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(156, 186);
            this.listBox1.TabIndex = 4;
            // 
            // chkChkListTumunuIsaretle
            // 
            this.chkChkListTumunuIsaretle.AutoSize = true;
            this.chkChkListTumunuIsaretle.Location = new System.Drawing.Point(22, 62);
            this.chkChkListTumunuIsaretle.Name = "chkChkListTumunuIsaretle";
            this.chkChkListTumunuIsaretle.Size = new System.Drawing.Size(101, 17);
            this.chkChkListTumunuIsaretle.TabIndex = 5;
            this.chkChkListTumunuIsaretle.Text = "Tümünü işaretle";
            this.chkChkListTumunuIsaretle.UseVisualStyleBackColor = true;
            this.chkChkListTumunuIsaretle.CheckedChanged += new System.EventHandler(this.chkChkListTumunuIsaretle_CheckedChanged);
            // 
            // btnChkClearAll
            // 
            this.btnChkClearAll.Location = new System.Drawing.Point(23, 316);
            this.btnChkClearAll.Name = "btnChkClearAll";
            this.btnChkClearAll.Size = new System.Drawing.Size(96, 23);
            this.btnChkClearAll.TabIndex = 6;
            this.btnChkClearAll.Text = "Listeyi boşalt";
            this.btnChkClearAll.UseVisualStyleBackColor = true;
            this.btnChkClearAll.Click += new System.EventHandler(this.btnChkClearAll_Click);
            // 
            // btnRasgeleHarf
            // 
            this.btnRasgeleHarf.Location = new System.Drawing.Point(358, 10);
            this.btnRasgeleHarf.Name = "btnRasgeleHarf";
            this.btnRasgeleHarf.Size = new System.Drawing.Size(139, 23);
            this.btnRasgeleHarf.TabIndex = 8;
            this.btnRasgeleHarf.Text = "rasgele harf ekle";
            this.btnRasgeleHarf.UseVisualStyleBackColor = true;
            this.btnRasgeleHarf.Click += new System.EventHandler(this.btnRasgeleHarf_Click);
            // 
            // chkListBxtumunusec
            // 
            this.chkListBxtumunusec.AutoSize = true;
            this.chkListBxtumunusec.Location = new System.Drawing.Point(358, 62);
            this.chkListBxtumunusec.Name = "chkListBxtumunusec";
            this.chkListBxtumunusec.Size = new System.Drawing.Size(81, 17);
            this.chkListBxtumunusec.TabIndex = 9;
            this.chkListBxtumunusec.Text = "tümünü seç";
            this.chkListBxtumunusec.UseVisualStyleBackColor = true;
            this.chkListBxtumunusec.CheckedChanged += new System.EventHandler(this.chkListBxtumunusec_CheckedChanged);
            // 
            // btnListRemoveSecili
            // 
            this.btnListRemoveSecili.Location = new System.Drawing.Point(354, 290);
            this.btnListRemoveSecili.Name = "btnListRemoveSecili";
            this.btnListRemoveSecili.Size = new System.Drawing.Size(104, 23);
            this.btnListRemoveSecili.TabIndex = 10;
            this.btnListRemoveSecili.Text = "Seçileni uçur(tek)";
            this.btnListRemoveSecili.UseVisualStyleBackColor = true;
            this.btnListRemoveSecili.Click += new System.EventHandler(this.btnListRemoveSecili_Click);
            // 
            // btnListClearAll
            // 
            this.btnListClearAll.Location = new System.Drawing.Point(354, 316);
            this.btnListClearAll.Name = "btnListClearAll";
            this.btnListClearAll.Size = new System.Drawing.Size(104, 23);
            this.btnListClearAll.TabIndex = 11;
            this.btnListClearAll.Text = "Listeyi boşalt";
            this.btnListClearAll.UseVisualStyleBackColor = true;
            this.btnListClearAll.Click += new System.EventHandler(this.btnListClearAll_Click);
            // 
            // btnListRemoveMultiselect
            // 
            this.btnListRemoveMultiselect.Location = new System.Drawing.Point(465, 290);
            this.btnListRemoveMultiselect.Name = "btnListRemoveMultiselect";
            this.btnListRemoveMultiselect.Size = new System.Drawing.Size(130, 23);
            this.btnListRemoveMultiselect.TabIndex = 12;
            this.btnListRemoveMultiselect.Text = "Seçileneri uçur(çoklu)";
            this.btnListRemoveMultiselect.UseVisualStyleBackColor = true;
            this.btnListRemoveMultiselect.Click += new System.EventHandler(this.btnListRemoveMultiselect_Click);
            // 
            // btnListSecimCancel
            // 
            this.btnListSecimCancel.Location = new System.Drawing.Point(465, 316);
            this.btnListSecimCancel.Name = "btnListSecimCancel";
            this.btnListSecimCancel.Size = new System.Drawing.Size(130, 23);
            this.btnListSecimCancel.TabIndex = 13;
            this.btnListSecimCancel.Text = "Seçimleri iptal et(çoklu)";
            this.btnListSecimCancel.UseVisualStyleBackColor = true;
            this.btnListSecimCancel.Click += new System.EventHandler(this.btnListSecimCancel_Click);
            // 
            // btnChkIsaretCancel
            // 
            this.btnChkIsaretCancel.Location = new System.Drawing.Point(125, 316);
            this.btnChkIsaretCancel.Name = "btnChkIsaretCancel";
            this.btnChkIsaretCancel.Size = new System.Drawing.Size(145, 23);
            this.btnChkIsaretCancel.TabIndex = 14;
            this.btnChkIsaretCancel.Text = "İşaretlemeleri iptal et(Çoklu)";
            this.btnChkIsaretCancel.UseVisualStyleBackColor = true;
            this.btnChkIsaretCancel.Click += new System.EventHandler(this.btnClbIsaretCancel_Click);
            // 
            // chkItemCheckKontrol
            // 
            this.chkItemCheckKontrol.AutoSize = true;
            this.chkItemCheckKontrol.Location = new System.Drawing.Point(22, 39);
            this.chkItemCheckKontrol.Name = "chkItemCheckKontrol";
            this.chkItemCheckKontrol.Size = new System.Drawing.Size(167, 17);
            this.chkItemCheckKontrol.TabIndex = 15;
            this.chkItemCheckKontrol.Text = "ItemCheck Kontrolü olmasın(*)";
            this.toolTip1.SetToolTip(this.chkItemCheckKontrol, "Tekli kayıt denemelerini yaptıktan sonra bunu aktifleştirin\r\nki, çoklu veya tüm s" +
        "eçimlerde tek tek msgbox çıkmasın");
            this.chkItemCheckKontrol.UseVisualStyleBackColor = true;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.rdList);
            this.grp1.Controls.Add(this.rdChkList);
            this.grp1.Controls.Add(this.btnIndexliIsaretdurumu);
            this.grp1.Controls.Add(this.btnIndexliSecimdurumu);
            this.grp1.Controls.Add(this.btnIndexliIsaretClear);
            this.grp1.Controls.Add(this.btnIndexliIsaretle);
            this.grp1.Controls.Add(this.btnIndexliSecimiclear);
            this.grp1.Controls.Add(this.btnIndexliSec);
            this.grp1.Controls.Add(this.txtIndexforChkList);
            this.grp1.Location = new System.Drawing.Point(127, 354);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(318, 108);
            this.grp1.TabIndex = 16;
            this.grp1.TabStop = false;
            this.grp1.Text = "Belli indexli elemanlardaki işlemler";
            // 
            // rdList
            // 
            this.rdList.AutoSize = true;
            this.rdList.Location = new System.Drawing.Point(216, 26);
            this.rdList.Name = "rdList";
            this.rdList.Size = new System.Drawing.Size(59, 17);
            this.rdList.TabIndex = 8;
            this.rdList.Text = "ListBox";
            this.rdList.UseVisualStyleBackColor = true;
            this.rdList.CheckedChanged += new System.EventHandler(this.rdList_CheckedChanged);
            // 
            // rdChkList
            // 
            this.rdChkList.AutoSize = true;
            this.rdChkList.Checked = true;
            this.rdChkList.Location = new System.Drawing.Point(216, 10);
            this.rdChkList.Name = "rdChkList";
            this.rdChkList.Size = new System.Drawing.Size(101, 17);
            this.rdChkList.TabIndex = 7;
            this.rdChkList.TabStop = true;
            this.rdChkList.Text = "CheckedListbox";
            this.rdChkList.UseVisualStyleBackColor = true;
            // 
            // btnIndexliIsaretdurumu
            // 
            this.btnIndexliIsaretdurumu.Location = new System.Drawing.Point(198, 78);
            this.btnIndexliIsaretdurumu.Name = "btnIndexliIsaretdurumu";
            this.btnIndexliIsaretdurumu.Size = new System.Drawing.Size(90, 23);
            this.btnIndexliIsaretdurumu.TabIndex = 6;
            this.btnIndexliIsaretdurumu.Text = "İşaret durumu";
            this.btnIndexliIsaretdurumu.UseVisualStyleBackColor = true;
            this.btnIndexliIsaretdurumu.Click += new System.EventHandler(this.btnIndexliIsaretdurumu_Click);
            // 
            // btnIndexliSecimdurumu
            // 
            this.btnIndexliSecimdurumu.Location = new System.Drawing.Point(199, 50);
            this.btnIndexliSecimdurumu.Name = "btnIndexliSecimdurumu";
            this.btnIndexliSecimdurumu.Size = new System.Drawing.Size(90, 23);
            this.btnIndexliSecimdurumu.TabIndex = 5;
            this.btnIndexliSecimdurumu.Text = "Seçim durumu";
            this.btnIndexliSecimdurumu.UseVisualStyleBackColor = true;
            this.btnIndexliSecimdurumu.Click += new System.EventHandler(this.btnIndexliSecimdurumu_Click);
            // 
            // btnIndexliIsaretClear
            // 
            this.btnIndexliIsaretClear.Location = new System.Drawing.Point(99, 78);
            this.btnIndexliIsaretClear.Name = "btnIndexliIsaretClear";
            this.btnIndexliIsaretClear.Size = new System.Drawing.Size(75, 23);
            this.btnIndexliIsaretClear.TabIndex = 4;
            this.btnIndexliIsaretClear.Text = "İşareti kaldır";
            this.btnIndexliIsaretClear.UseVisualStyleBackColor = true;
            this.btnIndexliIsaretClear.Click += new System.EventHandler(this.btnIndexliIsaretClear_Click);
            // 
            // btnIndexliIsaretle
            // 
            this.btnIndexliIsaretle.Location = new System.Drawing.Point(7, 77);
            this.btnIndexliIsaretle.Name = "btnIndexliIsaretle";
            this.btnIndexliIsaretle.Size = new System.Drawing.Size(75, 23);
            this.btnIndexliIsaretle.TabIndex = 3;
            this.btnIndexliIsaretle.Text = "İşaretle";
            this.btnIndexliIsaretle.UseVisualStyleBackColor = true;
            this.btnIndexliIsaretle.Click += new System.EventHandler(this.btnIndexliIsaretle_Click);
            // 
            // btnIndexliSecimiclear
            // 
            this.btnIndexliSecimiclear.Location = new System.Drawing.Point(100, 48);
            this.btnIndexliSecimiclear.Name = "btnIndexliSecimiclear";
            this.btnIndexliSecimiclear.Size = new System.Drawing.Size(75, 23);
            this.btnIndexliSecimiclear.TabIndex = 2;
            this.btnIndexliSecimiclear.Text = "Seçimi kaldır";
            this.btnIndexliSecimiclear.UseVisualStyleBackColor = true;
            this.btnIndexliSecimiclear.Click += new System.EventHandler(this.btnIndexliSecimiclear_Click);
            // 
            // btnIndexliSec
            // 
            this.btnIndexliSec.Location = new System.Drawing.Point(8, 49);
            this.btnIndexliSec.Name = "btnIndexliSec";
            this.btnIndexliSec.Size = new System.Drawing.Size(75, 23);
            this.btnIndexliSec.TabIndex = 1;
            this.btnIndexliSec.Text = "Seç";
            this.btnIndexliSec.UseVisualStyleBackColor = true;
            this.btnIndexliSec.Click += new System.EventHandler(this.btnIndexliSec_Click);
            // 
            // txtIndexforChkList
            // 
            this.txtIndexforChkList.ForeColor = System.Drawing.Color.LightGray;
            this.txtIndexforChkList.Location = new System.Drawing.Point(8, 20);
            this.txtIndexforChkList.Name = "txtIndexforChkList";
            this.txtIndexforChkList.Size = new System.Drawing.Size(201, 20);
            this.txtIndexforChkList.TabIndex = 0;
            this.txtIndexforChkList.Text = "İşlem yapılacak bir index numarası giriniz";
            this.txtIndexforChkList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtIndexforChkList_MouseClick);
            // 
            // btnChkRemoveChekli
            // 
            this.btnChkRemoveChekli.Location = new System.Drawing.Point(23, 285);
            this.btnChkRemoveChekli.Name = "btnChkRemoveChekli";
            this.btnChkRemoveChekli.Size = new System.Drawing.Size(98, 23);
            this.btnChkRemoveChekli.TabIndex = 17;
            this.btnChkRemoveChekli.Text = "İşaretliyi uçur(tek)";
            this.btnChkRemoveChekli.UseVisualStyleBackColor = true;
            this.btnChkRemoveChekli.Click += new System.EventHandler(this.btnChkRemoveChekli_Click);
            // 
            // btnListIndex
            // 
            this.btnListIndex.Location = new System.Drawing.Point(520, 95);
            this.btnListIndex.Name = "btnListIndex";
            this.btnListIndex.Size = new System.Drawing.Size(72, 47);
            this.btnListIndex.TabIndex = 18;
            this.btnListIndex.Text = "İndex ve isim öğrenme";
            this.btnListIndex.UseVisualStyleBackColor = true;
            this.btnListIndex.Click += new System.EventHandler(this.btnListIndex_Click);
            // 
            // txtListVarmi
            // 
            this.txtListVarmi.ForeColor = System.Drawing.Color.LightGray;
            this.txtListVarmi.Location = new System.Drawing.Point(520, 170);
            this.txtListVarmi.Name = "txtListVarmi";
            this.txtListVarmi.Size = new System.Drawing.Size(81, 20);
            this.txtListVarmi.TabIndex = 19;
            this.txtListVarmi.Text = "Büyük Harf gir";
            this.txtListVarmi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtListVarmi_MouseClick);
            // 
            // btnListVarmi
            // 
            this.btnListVarmi.Location = new System.Drawing.Point(520, 196);
            this.btnListVarmi.Name = "btnListVarmi";
            this.btnListVarmi.Size = new System.Drawing.Size(75, 23);
            this.btnListVarmi.TabIndex = 20;
            this.btnListVarmi.Text = "Var mı?";
            this.btnListVarmi.UseVisualStyleBackColor = true;
            this.btnListVarmi.Click += new System.EventHandler(this.btnListVarmi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 464);
            this.Controls.Add(this.btnListVarmi);
            this.Controls.Add(this.txtListVarmi);
            this.Controls.Add(this.btnListIndex);
            this.Controls.Add(this.btnChkRemoveChekli);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.chkItemCheckKontrol);
            this.Controls.Add(this.btnChkIsaretCancel);
            this.Controls.Add(this.btnListSecimCancel);
            this.Controls.Add(this.btnListRemoveMultiselect);
            this.Controls.Add(this.btnListClearAll);
            this.Controls.Add(this.btnListRemoveSecili);
            this.Controls.Add(this.chkListBxtumunusec);
            this.Controls.Add(this.btnRasgeleHarf);
            this.Controls.Add(this.btnChkClearAll);
            this.Controls.Add(this.chkChkListTumunuIsaretle);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnMoveSelected);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnChkRemoveChekliler);
            this.Controls.Add(this.btnRasgeleNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRasgeleNumber;
        private System.Windows.Forms.Button btnChkRemoveChekliler;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnMoveSelected;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox chkChkListTumunuIsaretle;
        private System.Windows.Forms.Button btnChkClearAll;
        private System.Windows.Forms.Button btnRasgeleHarf;
        private System.Windows.Forms.CheckBox chkListBxtumunusec;
        private System.Windows.Forms.Button btnListRemoveSecili;
        private System.Windows.Forms.Button btnListClearAll;
        private System.Windows.Forms.Button btnListRemoveMultiselect;
        private System.Windows.Forms.Button btnListSecimCancel;
        private System.Windows.Forms.Button btnChkIsaretCancel;
        private System.Windows.Forms.CheckBox chkItemCheckKontrol;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.TextBox txtIndexforChkList;
        private System.Windows.Forms.Button btnIndexliIsaretdurumu;
        private System.Windows.Forms.Button btnIndexliSecimdurumu;
        private System.Windows.Forms.Button btnIndexliIsaretClear;
        private System.Windows.Forms.Button btnIndexliIsaretle;
        private System.Windows.Forms.Button btnIndexliSecimiclear;
        private System.Windows.Forms.Button btnIndexliSec;
        private System.Windows.Forms.RadioButton rdList;
        private System.Windows.Forms.RadioButton rdChkList;
        private System.Windows.Forms.Button btnChkRemoveChekli;
        private System.Windows.Forms.Button btnListIndex;
        private System.Windows.Forms.TextBox txtListVarmi;
        private System.Windows.Forms.Button btnListVarmi;
    }
}

