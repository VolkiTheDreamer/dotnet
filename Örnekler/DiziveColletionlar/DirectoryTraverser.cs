using System;
using System.IO;
using System.Collections.Generic;

public static class DirectoryTraverser
{
    static string klasor = @"C:\inetpub\wwwroot\aspnettest\excelefendi2\syntaxhighlighter_3.0.83";

    public static void Ana()
    {
        TraverseDirDFS(klasor);
        Console.ReadLine();
        TraverseDirBFS(klasor);
        Console.ReadLine();
        KlasorGetir(klasor);
        Console.ReadLine();
        KlasorGetirAsList(klasor);
        Console.ReadLine();
        DosyaGetir(klasor);
        Console.ReadLine();
    }

    static void TraverseDirDFS(string directoryPath)
    {
        //Bu yönteme önce 1.üyenin derinine kadar in, sonra 2nin sonra 3 v.s
        Console.WriteLine("ilk olarak PDFten aldığım yönteme göre DFS çalışacak");
        TraverseDirDFS(new DirectoryInfo(directoryPath), string.Empty);
    }

    private static void TraverseDirDFS(DirectoryInfo dir, string spaces)
    {
        Console.WriteLine(spaces + dir.FullName);
        DirectoryInfo[] children = dir.GetDirectories();
        // For each child go and visit its sub-tree
        foreach (DirectoryInfo child in children)
        {
            TraverseDirDFS(child, spaces + " ");
        }
    }

    static void TraverseDirBFS(string directoryPath)
    {
        //Bu yönteme önce 1.seviyedekiler, sonra 2.seviyedekiler, sonra3 v.s
        Console.WriteLine("ikinci olarak PDFten aldığım yönteme göre BFS çalışacak");
        Queue<DirectoryInfo> visitedDirsQueue = new Queue<DirectoryInfo>();
        visitedDirsQueue.Enqueue(new DirectoryInfo(directoryPath));
        while (visitedDirsQueue.Count > 0)
        {
            DirectoryInfo currentDir = visitedDirsQueue.Dequeue();
            Console.WriteLine(currentDir.FullName);
            DirectoryInfo[] children = currentDir.GetDirectories();
            foreach (DirectoryInfo child in children)
            {
                visitedDirsQueue.Enqueue(child);
            }
        }
    }
    static public void KlasorGetir(string path)
    {
        //BFS mantıgı ile çalışır
        Console.WriteLine("\r\nŞimdi de GetFolder(Utulityden) metodum çalışacak");
        IEnumerable<string> folders = MyUtility.Utilities.GetFolders(path);
        foreach (string folder in folders)
        {
            Console.WriteLine(folder);
        }
    }

    static public void KlasorGetirAsList(string path)
    {
        //BFS mantıgı ile çalışır
        Console.WriteLine("\r\nŞimdi de ListOlarakFolderGetir metodum çalışacak");
        List<string> folders = ListOlarakFolderGetir(klasor);
        foreach (string folder in folders)
        {
            Console.WriteLine(folder);
        }        
    }

    static public void DosyaGetir(string path)
    {
        //BFS mantıgı ile çalışır
        Console.WriteLine("\r\nŞimdi de Get_Files(Utulityden) metodum çaışacak");
        IEnumerable<string> files = MyUtility.Utilities.GetFiles(path);
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }   

    static List<string> ListOlarakFolderGetir(string root, string pattern = "*")
    {
        //myuytility içndeki IEnumerable ve yield ile yapılmış ama gerek yokki, List ile de gayet oluyor
        //bunun dizi versiyonu olmaz, çünkü Ekleme işlemi gerekiyor.
        var todo = new Queue<string>();
        var nihai = new List<string>();
        todo.Enqueue(root);
        while (todo.Count > 0)
        {
            string dir = todo.Dequeue();
            string[] subdirs = new string[0];
            try
            {
                subdirs = System.IO.Directory.GetDirectories(dir);
            }
            catch (System.IO.IOException)
            {
            }
            catch (System.UnauthorizedAccessException)
            {
            }

            foreach (string subdir in subdirs)
            {
                todo.Enqueue(subdir);
            }

            foreach (string subdir in subdirs)
            {
                nihai.Add(subdir);
            }
        }
        return nihai;
    }
    
}