using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ThreadOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //bunu manuel ekledik, çoklu kanal oldugunu söyüyoruz
        }

        Thread t1;
        Thread t2;

        private void buton3KonumDegis()
        {
            for (int i = 0; i < 150; i++)
            {
                button3.Location = new Point(button3.Location.X + 1, button3.Location.Y);
                Thread.Sleep(50);
            }
        }

        private void buton2KonumDegis()
        {
            for (int i = 0; i < 150; i++)
            {
                button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t1 == null)
            {
                t1 = new Thread(buton3KonumDegis);
                t1.Start();
            }
            else
            {
                MessageBox.Show("t1 zaten çalışıyor. Devam tusuna basın");
            }

            if (t2 == null || t2.ThreadState == ThreadState.Unstarted)
            {
                t2 = new Thread(buton2KonumDegis);
                t2.Start();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t1.IsAlive && t1 != null)
            {
                t1.Suspend();
            }

            if (t2.IsAlive && t2 != null)
            {
                t2.Suspend();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (t2 != null && t2.ThreadState == ThreadState.Suspended)
            {
                t2.Resume();
            }

            if (t1 != null && t1.ThreadState == ThreadState.Suspended)
            {
                t1.Resume();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaskForm tf = new TaskForm();
            tf.Show();
        }

     

        private void button8_Click(object sender, EventArgs e)
        {
            TPL_Paralel.Ana();
        }
        #region Threadornek2
        private void consoleThread_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(PrintNumbersWithDelay);
            Console.WriteLine("t durumu: " + t.ThreadState.ToString());
            t.Start();
            Console.WriteLine("t durumu: " + t.ThreadState.ToString());
            //t.Join();//bunu eklerek synhronous olur, t'nin bitmesini bekler
            PrintNumbers();
            Thread t2 = new Thread(PrintNumbersThread2);
            Console.WriteLine("t2 durumu: " + t2.ThreadState.ToString());
            t2.Start();
            Console.WriteLine("t2 durumu: " + t2.ThreadState.ToString());
            Console.WriteLine("t durumu: " + t.ThreadState.ToString());
            Console.WriteLine("t2 durumu: " + t2.ThreadState.ToString());
            t2.Join();
            Console.WriteLine("t durumu: " + t.ThreadState.ToString());
            Console.WriteLine("t2 durumu: " + t2.ThreadState.ToString());
            t.Join();
            Console.WriteLine("t durumu: " + t.ThreadState.ToString());
            Console.WriteLine("t2 durumu: " + t2.ThreadState.ToString());

            var lambdaThread = new Thread(() => Console.WriteLine("ben lamdalı anonim metodum"));
            lambdaThread.Start();
        }
        static void PrintNumbersWithDelay()
        {
            Console.WriteLine("Starting Numbers with delay...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("delayli:" + i + " " + Thread.CurrentThread.ThreadState.ToString());
            }
        }
        static void PrintNumbers()
        {
            Console.WriteLine("Starting Numbers...");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void PrintNumbersThread2()
        {
            Console.WriteLine("Starting Numbers with thread2...");
            for (int i = 1; i < 10; i++)
            {
                //aborting
                if (i == 5)
                {
                    /*
                     When the main program and a separate number-printing thread run, we wait for 6 seconds
                    and then call a t.Abort method on a thread. This injects a ThreadAbortException
                    method into a thread causing it to terminate. It is very dangerous, generally because this
                    exception can happen at any point and may totally destroy the application. In addition, it is
                    not always possible to terminate a thread with this technique. The target thread may refuse to
                    abort by handling this exception and calling the Thread.ResetAbort method. Thus, it is not
                    recommended that you use the Abort method to close a thread. There are different methods
                    that are preferred, such as providing a CancellationToken method to cancel a thread
                    execution.
                     */
                    Console.WriteLine("thread2 iptal");
                    Thread.CurrentThread.Abort();//mevcut thread içn t2 demek yerine
                }
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("thread2:" + i);
            }
        }

        #endregion
        #region parametreli
        private void button9_Click(object sender, EventArgs e)
        {
            var sample = new ThreadSample(10);//sınıfın kendi constructerı parametreli
            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "ThreadOne";
            threadOne.Start();
            threadOne.Join();
            Console.WriteLine("--------------------------");
            var threadTwo = new Thread(Count);
            threadTwo.Name = "ThreadTwo";
            threadTwo.Start(8);//static metod çağılıyor, snıf yok. parametreli. iki seferde
            threadTwo.Join();
            Console.WriteLine("--------------------------");
            var threadThree = new Thread(() => CountNumbers(12));//static metod tek seferde çağılıyor, snıf yok. parametreli.
            threadThree.Name = "ThreadThree";
            threadThree.Start();
            threadThree.Join();
            Console.WriteLine("--------------------------");
            int i = 10;
            var threadFour = new Thread(() => PrintNumber(i));
            i = 20;
            var threadFive = new Thread(() => PrintNumber(i));
            threadFour.Start();
            threadFive.Start();
        }

        static void Count(object iterations)
        {
            CountNumbers((int)iterations);
        }
        static void CountNumbers(int iterations)
        {
            for (int i = 1; i <= iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}",
                Thread.CurrentThread.Name, i);
            }
        }
        static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }
        class ThreadSample //nested class oldu
        {
            private readonly int _iterations;
            public ThreadSample(int iterations)
            {
                _iterations = iterations;
            }
            public void CountNumbers()
            {
                for (int i = 1; i <= _iterations; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(0.5));
                    Console.WriteLine("{0} prints {1}",
                    Thread.CurrentThread.Name, i);
                }
            }
        }



        #endregion
        #region lockornek
        private void button10_Click(object sender, EventArgs e)
        {
            /*Counter class is not thread safe.When several threads access
            the counter at the same time, the first thread gets the counter value 10 and increments it to
            11. Then a second thread gets the value 11 and increments it to 12. The first thread gets the
            counter value 12, but before a decrement happens, a second thread gets the counter value
            12 as well.Then the first thread decrements 12 to 11 and saves it into the counter, and the
            second thread simultaneously does the same.As a result, we have two increments and only
            one decrement, which is obviously not right.This kind of a situation is called race condition
            and is a very common cause of errors in a multithreaded environment.
            To make sure that this does not happen, we must ensure that while one thread works with
            the counter, all other threads must wait until the first one finishes the work.We can use the
            lock keyword to achieve this kind of behavior.If we lock an object, all the other threads
            that require an access to this object will be waiting in a blocked state until it is unlocked.This
            could be a serious performance issue and later, in Chapter 2, Thread Synchronization, we will
            learn more about this.----->ayrıca incele
             */
            Console.WriteLine("Incorrect counter");
            var c = new Counter();
            var t1 = new Thread(() => TestCounter(c));
            var t2 = new Thread(() => TestCounter(c));
            var t3 = new Thread(() => TestCounter(c));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Total count: {0}", c.Count);
            Console.WriteLine("--------------------------");


            Console.WriteLine("Correct counter");
            var c1 = new CounterWithLock();
            t1 = new Thread(() => TestCounter(c1));
            t2 = new Thread(() => TestCounter(c1));
            t3 = new Thread(() => TestCounter(c1));
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Total count: {0}", c1.Count);

        }

        static void TestCounter(CounterBase c)
        {
            for (int i = 0; i < 100000; i++)
            {
                c.Increment();
                c.Decrement();
            }
        }
        class Counter : CounterBase
        {
            public int Count { get; private set; }
            public override void Increment()
            {
                Count++;
            }
            public override void Decrement()
            {
                Count--;
            }
        }
        class CounterWithLock : CounterBase
        {
            private readonly object _syncRoot = new Object();
            public int Count { get; private set; }
            public override void Increment()
            {
                lock (_syncRoot)
                {
                    Count++;
                }
            }
            public override void Decrement()
            {
                lock (_syncRoot)
                {
                    Count--;
                }
            }
        }
        abstract class CounterBase
        {
            public abstract void Increment();
            public abstract void Decrement();
        }

        #endregion
        #region exceptionyonetimi
        private void button11_Click(object sender, EventArgs e)
        {
            /*if you work with threads directly, the general rule is to not throw an exception from a thread, but to
            use a try/catch block inside a thread code instead.*/
            var t = new Thread(FaultyThread);
            t.Start();
            t.Join();
            try
            {
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("We won't get here!");
            }
        }

        static void BadFaultyThread()
        {
            //bunda try block yok. kötü.
            Console.WriteLine("Starting a faulty thread...");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");
        }
        static void FaultyThread()
        {
            try
            {
                Console.WriteLine("Starting a faulty thread...");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                throw new Exception("Boom!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception handled: {0}",
                ex.Message);
            }
        }
        #endregion
        #region thredpool
        /* It is very important to keep operations on a thread pool short-lived!
Do not put long-running operations on a thread pool or block worker
threads. This will lead to all worker threads becoming busy, and they
would no longer be able to serve user operations. This, in turn, will
lead to performance problems and errors that are very hard to debug.

            I would like to emphasize once again that a thread pool is intended to execute shortrunning
operations. Using a thread pool gives us the possibility to save operating system
resources at the cost of reducing the degree of parallelism.

            Please note that worker threads of a thread pool are background
threads. This means that when all of the threads in the foreground
(including the main application thread) are complete, then all the
background threads will be stopped.
         */
        private void button12_Click(object sender, EventArgs e)
        {
            int threadId = 0;
            RunOnThreadPool poolDelegate = Test;
            var t = new Thread(() => Test(out threadId));
            t.Start();
            t.Join();
            Console.WriteLine("Thread id: {0}", threadId);
            IAsyncResult r = poolDelegate.BeginInvoke(out threadId, Callback, "a delegate asynchronous call");

            r.AsyncWaitHandle.WaitOne();
            string result = poolDelegate.EndInvoke(out threadId, r);
            Console.WriteLine("Thread pool worker thread id: {0}", threadId);
            Console.WriteLine(result);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private delegate string RunOnThreadPool(out int threadId);
        private static void Callback(IAsyncResult ar)
        {
            Console.WriteLine("Starting a callback...");
            Console.WriteLine("State passed to a callback: {0}", ar.AsyncState);
            Console.WriteLine("Is thread pool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Thread pool worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
        }
        private static string Test(out int threadId)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Is thread pool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            threadId = Thread.CurrentThread.ManagedThreadId;
            return $"Thread pool worker thread id was:{ threadId}";
        }
        #endregion

        #region asyncpoolagonder
        private void button13_Click(object sender, EventArgs e)
        {
            const int x = 1;
            const int y = 2;
            const string lambdaState = "lambda state 2";
            ThreadPool.QueueUserWorkItem(AsyncOperation);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ThreadPool.QueueUserWorkItem(AsyncOperation, "async state");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine("Operation state: {0}", state);
                Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }, "lambda state");
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine("Operation state: {0}, {1}", x + y, lambdaState);
                Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }, "lambda state");
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private static void AsyncOperation(object state)
        {
            Console.WriteLine("Operation state: {0}", state ?? "(null)");
            Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            Asenkron asf = new Asenkron();
            asf.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            KutuSihirbazı k = new KutuSihirbazı();
            k.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TaskScheduleOrnek t = new TaskScheduleOrnek();
            t.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            BGWOrnek bgw = new BGWOrnek();
            bgw.Show();
        }
    }
}
