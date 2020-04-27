using System;
using System.IO;
using System.Collections.Generic;

namespace recursivesearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string klasor = @"C:\Users";
            
            IEnumerable<string> files = EnumerateFilesRecursive(klasor);//Note that there is NO ToArray()
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            Console.Read();
        }
            
       

        static IEnumerable<string> EnumerateFilesRecursive(string root, string pattern = "*")
        {
            var todo = new Queue<string>();
            todo.Enqueue(root);
            while (todo.Count > 0)
            {
                string dir = todo.Dequeue();
                string[] subdirs = new string[0];
                string[] files = new string[0];
                try
                {
                    subdirs = Directory.GetDirectories(dir);
                    files = Directory.GetFiles(dir, pattern);
                }
                catch (IOException)
                {
                }
                catch (System.UnauthorizedAccessException)
                {
                }

                foreach (string subdir in subdirs)
                {
                    todo.Enqueue(subdir);
                }
                foreach (string filename in files)
                {
                    yield return filename;
                }
            }
        }
    }
}
