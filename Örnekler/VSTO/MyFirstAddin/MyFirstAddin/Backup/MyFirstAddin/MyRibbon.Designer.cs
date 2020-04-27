namespace MyFirstAddin
{
    partial class MyRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MyRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyRibbon));
            this.MyFirstAddin = this.Factory.CreateRibbonTab();
            this.gpTaskPane = this.Factory.CreateRibbonGroup();
            this.btnOpen = this.Factory.CreateRibbonButton();
            this.btnClose = this.Factory.CreateRibbonButton();
            this.MyFirstAddin.SuspendLayout();
            this.gpTaskPane.SuspendLayout();
            // 
            // MyFirstAddin
            // 
            this.MyFirstAddin.Groups.Add(this.gpTaskPane);
            this.MyFirstAddin.Label = "MyFirstAddin";
            this.MyFirstAddin.Name = "MyFirstAddin";
            // 
            // gpTaskPane
            // 
            this.gpTaskPane.Items.Add(this.btnOpen);
            this.gpTaskPane.Items.Add(this.btnClose);
            this.gpTaskPane.Label = "Task Pane";
            this.gpTaskPane.Name = "gpTaskPane";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Label = "Open Task Pane";
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ShowImage = true;
            this.btnOpen.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::MyFirstAddin.Properties.Resources.close;
            this.btnClose.Label = "Close Task Pane";
            this.btnClose.Name = "btnClose";
            this.btnClose.ShowImage = true;
            this.btnClose.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnClose_Click);
            // 
            // MyRibbon
            // 
            this.Name = "MyRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.MyFirstAddin);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MyRibbon_Load);
            this.MyFirstAddin.ResumeLayout(false);
            this.MyFirstAddin.PerformLayout();
            this.gpTaskPane.ResumeLayout(false);
            this.gpTaskPane.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab MyFirstAddin;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup gpTaskPane;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpen;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnClose;
    }

    partial class ThisRibbonCollection
    {
        internal MyRibbon MyRibbon
        {
            get { return this.GetRibbon<MyRibbon>(); }
        }
    }
}
