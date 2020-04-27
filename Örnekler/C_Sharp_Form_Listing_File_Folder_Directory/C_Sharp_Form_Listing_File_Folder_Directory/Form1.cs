using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C_Sharp_Form_Listing_File_Folder_Directory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string[] dirvers = System.IO.Directory.GetLogicalDrives();
 
            for (int i = 0; i <= dirvers.GetUpperBound(0); i++)
            {
                treeViewFolders.Nodes.Add(dirvers[i]);
                try
                {
                    string[] folders = System.IO.Directory.GetDirectories(treeViewFolders.Nodes[i].FullPath);

                    string[] folderNames;

                    //Daha önce eklenmemişse alt klasörleri ekle
                  
                    if (treeViewFolders.Nodes[i].GetNodeCount(true) == 0)
                    {
                        for (int j = 0; j <= folders.GetUpperBound(0); j++)
                        {
                            folderNames = folders[j].Split('\\');

                            treeViewFolders.Nodes[i].Nodes.Add(folderNames[folderNames.GetUpperBound(0)]);
                        }
                    }
                }
                catch
                {
                    ; //herhangi bir hata oldugunda hata vermemesi için
                }
            }
        }

        private void treeViewFolders_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            string[] fileNames;

            //herhangi bir klasör seçildiğinde dosyaları listeleyelim

            lstFiles.Items.Clear();

            string[] files = System.IO.Directory.GetFiles(e.Node.FullPath);

            for (int i = 0; i <= files.GetUpperBound(0); i++)
            {
                fileNames = files[i].Split('\\');

                lstFiles.Items.Add(fileNames[fileNames.GetUpperBound(0)]);
            }
        }

        private void treeViewFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
            // + ya basılınca alt klasörleri listeleyelim

            try
            {
                // seçilen klasör içinde olan klasörleri bir dizi içinde toplayalım.

                string[] selectedFolderDirectories = System.IO.Directory.GetDirectories(e.Node.FullPath + "\\");

                string[] folderNames;
                string[] fileNames;

                // Seçilen klasörün alt klasörleri varsa bunları bu klasör altına ekleyelim

                for (int i = 0; i <= selectedFolderDirectories.GetUpperBound(0); i++)
                {
                    try
                    {
                        //alt klasör içinde alt klasör varsa bu klasörleri bir dizi içinde toplayalım
 
                        string[] subFolderDirectoriesOfSelectedFolder = System.IO.Directory.GetDirectories(e.Node.Nodes[i].FullPath + "\\");

                        //Daha önce eklenmemişse alt klasörleri ekleyelim

                        if (e.Node.Nodes[i].GetNodeCount(true) == 0)
                            for (int j = 0; j <= subFolderDirectoriesOfSelectedFolder.GetUpperBound(0); j++)
                            {
                                folderNames = subFolderDirectoriesOfSelectedFolder[j].Split('\\');
                               
                                e.Node.Nodes[i].Nodes.Add(folderNames[folderNames.GetUpperBound(0)]);
                            }
                    }
                    catch
                    {
                        ; //herhangi bir hata oldugunda hata vermemesi için
                    }
                }

                //seçilen klasördeki dosyaları listeleyelim

                lstFiles.Items.Clear();

                string[] files = System.IO.Directory.GetFiles(e.Node.FullPath);

                for (int i = 0; i <= files.GetUpperBound(0); i++)
                {
                    fileNames = files[i].Split('\\');
                
                    lstFiles.Items.Add(fileNames[fileNames.GetUpperBound(0)]);
                }
            }
            catch
            {
                ; // herhangi bir hata oldugunda hata vermemesi için
            }
        }
    }
}
