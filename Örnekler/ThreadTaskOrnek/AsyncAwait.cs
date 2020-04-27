using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadOrnek
{
    public static class AsyncAwait
    {
        public static void AnaAsync()
        {
            Task t = AsyncTask();
            SyncCode();
            t.Wait();
            Console.ReadLine();
        }

        static async Task AsyncTask()
        {
            //async ise task veya void dönmeli
            //eksik çalışıyor, kontrol et**********************************
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("async: Starting");
            Task bekle = Task.Delay(5000);
            Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            await bekle;
            Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("async: Done");
        }

        static void SyncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("sync: Starting");
            Thread.Sleep(5000);
            Console.WriteLine("sync: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("sync: Done");
        }
    }
}