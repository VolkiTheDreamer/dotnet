using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;



namespace beforeshutdown
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            //Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);
        }

        protected override void OnStart(string[] args)
        {            
	    File.Create("C:\\Onstart.txt");
            //bosalt();
            //yedekle();
            //base.OnStart();
        }

        protected override void OnStop()
        {
           File.Create("C:\\Onstop.txt");
        }

        protected override void OnShutdown()
        {
            this.RequestAdditionalTime(60000);
            File.Create("C:\\Onshut.txt");
            bosalt();
            yedekle();
            base.OnShutdown();
        }
        void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            File.Create("C:\\Onshut2.txt");            
        }

        void bosalt()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Volkan\OneDrive\0-uygulama örnek ve yedekler\excelinefendisi");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        void yedekle()
        {
            string sourceFolder = @"C:\inetpub\wwwroot\aspnettest\excelefendi2";
            string outputFolder = @"C:\Users\Volkan\OneDrive\0-uygulama örnek ve yedekler\excelinefendisi";
            new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(sourceFolder, outputFolder);
        }
    }
}
