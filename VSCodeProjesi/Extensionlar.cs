using System.Data.Common;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using System.Linq ;
using System.Drawing;
using Microsoft.CSharp;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

//burada hem utulity class var hem extension class
//utilitidekileri kendi başına kullanırken, extensionları mevcut sınıflar üzerinde
public static class Ut
{
       // Write custom extension methods here. They will be available to all queries.
          /*Kullanım şekilde aşağıdaki gibi olacak
        int three = Utilities.Sum(1, 2);
        */
             
            public static int RandomNumber(int bas,int son) 
             {
                    Random rnd = new Random();
                    return rnd.Next(bas,son);
             }             
             
             //Python'ın decoratür gibi kullanabiliriz
                        
        public static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public static string[] ResourceNameGetir()
        {
            //getassembleyexecutio v.s
            return null;
        }

        public static void OutputYaz(string s)
        {
            System.Diagnostics.Trace.WriteLine(s);
        }
        public static void yaz(string s)
        {
            Console.WriteLine(s);
        }
             public static string KökDizinGetir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void DiziYazdır(System.Collections.IEnumerable dizi, string diziAd)
        {
            Console.WriteLine(diziAd + " dizisi yazdırılıyor:");
            foreach (var item in dizi)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n");
        }
             
             //diziyazırın overload'u
             public static void DiziYazdır(System.Collections.IEnumerable dizi)
        {
            Console.WriteLine("Bahsekonu dizi yazdırılıyor:");
            foreach (var item in dizi)
            {
               Console.WriteLine(item);
            }
            Console.WriteLine("\r\n");
        }
        //diziyazırın overload'u
        public static void DiziYazdır(System.Collections.IDictionary idict, string diziAd)
        {
            Console.WriteLine(diziAd + " hashtable'ı yazdırılıyor:");
            foreach (System.Collections.DictionaryEntry de in idict)
            {
                Console.WriteLine(de.Key.ToString()+","+de.Value.ToString());
            }
            Console.WriteLine("\r\n");
        }

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

        public static string WhiteSpacelerdenKurtul(string text)
        {
            return Regex.Replace(text, @"\s", " ");
        }

       
}

public static class Extensions
    {
        public static long GecenSure(this Stopwatch sw, Action action)
           {
               sw.Reset();
               sw.Start(); 
               action();          
               sw.Stop(); 
               return sw.ElapsedMilliseconds;
           }
        public static int WordCount(this String str)
        {
            //kullanımı str.WordCount()
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
             
             public static void DiziYazdır(this IEnumerable dizi)
        {
            Console.WriteLine("Bahsekonu dizi yazdırılıyor:");
            foreach (var item in dizi)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n");
        }
             
             public static void Yaz(this String str) //Dump'ın muadili
        {
           Console.WriteLine(str);
        }

         public static void Yaz(this String str, string title) //Dump'ın muadili
        {
           Console.WriteLine("'"+title+"' yazdırılıyor");
           Console.WriteLine("--------------");
           Console.WriteLine(str);
        }
    }


public static class MyDB
       {
             public static SqlConnection ConYarat()
             {
                    SqlConnection conn = new SqlConnection("Data Source=94.73.148.5; database=Excelinefendisi;  uid=Volkitolki; pwd=VOlki19796628;MultipleActiveResultSets=True");
                    return conn;
             }
             
          
       }