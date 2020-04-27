using System;
using System.Collections.Generic;
using System.IO;

namespace MyUtility
{

    /// <summary>
    /// class da altındaki metodlar da static
    /// </summary>
    public static class Ut
    {
        #region StringMetodlar
        public static void DumpToConsole(string s)
        {
            Console.WriteLine(s);
        }

        public static void DumpToOutput(string s)
        {
            System.Diagnostics.Trace.WriteLine(s);
        }

        public static string KökDizimsinGetir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion

        #region DiziMetodları

        public static void DizimsiYazdırToConsole(System.Collections.IEnumerable dizimsi, bool bitişikmi=true)
        {
            Console.WriteLine("Dizimsi yazdırılıyor:");
            if (bitişikmi==false)
            {                
                foreach (var item in dizimsi)
                {
                    Console.WriteLine(item);
                }                
            }
            else
            {
                Console.WriteLine(String.Join("-", dizimsi));
            }
            Console.WriteLine("\r\n");
        }

        public static void DizimsiYazdırToConsole(System.Collections.IEnumerable dizimsi, string dizimsiAd, bool bitişikmi = true)
        {
            Console.WriteLine(dizimsiAd + " dizimsisi yazdırılıyor:");
            if (bitişikmi==false)
            {
                foreach (var item in dizimsi)
                {
                    Console.WriteLine(item);
                } 
            }
             else
            {
                Console.WriteLine(String.Join("-", dizimsi));
            }
            Console.WriteLine("\r\n");
        }
        
        public static void DizimsiYazdırToConsole(System.Collections.IDictionary idict, string dizimsiAd)
        {
            Console.WriteLine(dizimsiAd + " hashtable'ı yazdırılıyor:");
            foreach (System.Collections.DictionaryEntry de in idict)
            {
                Console.WriteLine(de.Key.ToString()+","+de.Value.ToString());
            }
            Console.WriteLine("\r\n");
        }

        public static void DizimsiYazdırToOutput(System.Collections.IEnumerable dizimsi, bool bitişikmi = true)
        {
            System.Diagnostics.Trace.WriteLine("Dizimsi yazdırılıyor:");
            if (bitişikmi==false)
            {
                foreach (var item in dizimsi)
                {
                    System.Diagnostics.Trace.WriteLine(item);
                } 
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(String.Join("-", dizimsi));
            }
            System.Diagnostics.Trace.WriteLine("\r\n");
        }

        public static void DizimsiYazdırToOutput(System.Collections.IEnumerable dizimsi, string dizimsiAd, bool bitişikmi = true)
        {
            System.Diagnostics.Trace.WriteLine(dizimsiAd + " dizimsisi yazdırılıyor:");
            if (bitişikmi==false)
            {
                foreach (var item in dizimsi)
                {
                    System.Diagnostics.Trace.WriteLine(item);
                } 
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(String.Join("-", dizimsi));
            }
            System.Diagnostics.Trace.WriteLine("\r\n");
        }

        public static void DizimsiYazdırToOutput(System.Collections.IDictionary idict, string dizimsiAd, bool bitişikmi = true)
        {
            System.Diagnostics.Trace.WriteLine(dizimsiAd + " hashtable'ı yazdırılıyor:");
            foreach (System.Collections.DictionaryEntry de in idict)
            {
                System.Diagnostics.Trace.WriteLine(de.Key.ToString() + "," + de.Value.ToString());
            }
            System.Diagnostics.Trace.WriteLine("\r\n");
        }

        #endregion
        #region FileFolderMetodlar
        public static IEnumerable<string> GetFiles(string root, string pattern = "*")
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

        public static IEnumerable<string> GetFolders(string root, string pattern = "*")
        {
            var todo = new Queue<string>();
            todo.Enqueue(root);
            while (todo.Count > 0)
            {
                string dir = todo.Dequeue();
                string[] subdirs = new string[0];                
                try
                {
                    subdirs = Directory.GetDirectories(dir);                    
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
                
                foreach (string subdir in subdirs)
                {
                    yield return subdir;
                }

            }
        }
        #endregion
    }
       
}
