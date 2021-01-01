using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace VolkansUtility
{
    public static class Extensions
    {
        public static int CountWords(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static void WriteItemsInConsole(this IEnumerable arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\r\n");
        }

        public static void Dump(this string str) //Imitating LinqPad's Dump
        {
            Console.WriteLine(str);
        }

        public static void DumpToOutput(this string s)
        {
            System.Diagnostics.Trace.WriteLine(s);
        }

        public static string SuperTrim(this string str)
        {
            Regex trimmer = new Regex(@"\s\s+");
            return trimmer.Replace(str, " ");
        }

        public static string SuperTrimFast(this string str)
        {
            //this looks longer than SuperTrim but runs faster
            var sb = new StringBuilder();
            var prevIsWhiteSpace = false;
            foreach (var ch in str)
            {
                var isWhiteSpace = char.IsWhiteSpace(ch);
                if (prevIsWhiteSpace && isWhiteSpace)
                {
                    continue;
                }
                sb.Append(ch);
                prevIsWhiteSpace = isWhiteSpace;
            }
            return sb.ToString();
        }

        public static long TimeElapsed(this System.Diagnostics.Stopwatch sw, Action action)
        {
            sw.Reset();
            sw.Start();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        public static void OpenWithControl(this OleDbConnection conn)
        {
            if (conn.State!=System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }

        #region LINQ Replace implementation
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sequence, T find, T replaceWith, IEqualityComparer<T> comparer)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (comparer == null) throw new ArgumentNullException("comparer");
            return ReplaceImpl(sequence,find,replaceWith,comparer);
        }
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> sequence, T find, T replaceWith)
        {
            return Replace(sequence, find, replaceWith, EqualityComparer<T>.Default);
        }
        
        public static IEnumerable<T> ReplaceImpl<T>(IEnumerable<T> sequence, T find, T replaceWith, IEqualityComparer<T> comparer)
        {
            foreach (T item in sequence)
            {
                bool match = comparer.Equals(find, item);
                T x = match ? replaceWith : item;
                yield return x;
            }
        }
        #endregion

        #region conversions
        public static int ConvertIoInt(this string s) 
        {
            return Convert.ToInt32(s);       
        }
        #endregion
    }
}
