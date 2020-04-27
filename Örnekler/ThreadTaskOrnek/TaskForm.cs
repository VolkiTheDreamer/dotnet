using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadOrnek
{
    public partial class TaskForm : Form
    {
        CancellationTokenSource cts;
        public TaskForm()
        {
            CheckForIllegalCrossThreadCalls = false; //buna gerek yok çünkü TPL bunu hallediyor?? ama picbbox koyunca gerekti
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            await AsyncMetod();
            Task t = new Task(() => Kutu1Oynat());
            t.Start();
        }

        private async Task Kutu1Oynat()
        {
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {
                pic1.Location = new Point(pic1.Location.X + r.Next(1, 5), pic1.Location.Y);
                Thread.Sleep(50);
            }

        }
        private async Task AsyncMetod()
        {
            //başlama sıasıya bitiş sırası aynı olmayabiliyor.
            cts = new CancellationTokenSource();
            try
            {
                await Task.Factory.StartNew(() => GoAyrıMetod(cts.Token));
                await Task.Factory.StartNew(() => textBox1.AppendText("Hello from the thread pool, in te lambda!\r\n"));
                Task t1 = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i <= 6; i++)
                        {
                            for (int k = 0; k < 10000000; k++)
                            {
                            }
                            //Thread.Sleep(500);//pretending sanki yarım sn süren bir iş
                            textBox1.AppendText(i.ToString() + "\r\n");
                        }
                    }
                    );
                await t1.ContinueWith(öncekiTask => ArayaYaz());
                Task t2 = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i <= 6; i++)
                        {
                            for (int k = 0; k < 10000000; k++)
                            {
                            }
                            //Thread.Sleep(500);
                            textBox1.AppendText((i * 10).ToString() + "\r\n");
                        }
                    }
                    );

                t2.Wait();//buunun yerine t2yi task değil de bir alt bloktaki gibi syncronize kod yapabilirdik??
                Task t3 = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i <= 6; i++)
                        {
                            for (int k = 0; k < 10000000; k++)
                            {
                            }
                            //Thread.Sleep(500);
                            textBox1.AppendText((i * 100).ToString() + "\r\n");
                        }
                    }
                    );
                //araya biraz syncronous kod girelim???
                for (int i = 0; i < 10; i++)
                {
                    textBox1.AppendText("biraz bekliyoruz\r\n");
                    //Thread.Sleep(250);
                    for (int k = 0; k < 10000000; k++)
                    {
                    }
                }

                var t4 = new Task(
                    () =>
                    {
                        for (int i = 0; i <= 6; i++)
                        {
                            //Thread.Sleep(500);
                            for (int k = 0; k < 10000000; k++)
                            {
                            }
                            textBox1.AppendText((i * 1000).ToString() + "\r\n");
                        }
                    });
                t4.Start();//4.yöntemden ziyade öncekiler kullanılır,factory yani.
                Task.WaitAny(t1, t2, t3, t4);
                textBox1.AppendText("en az biri bitti \r\n");
                Task.WaitAll(t1, t2, t3, t4);
                textBox1.AppendText("hepsi bitti\r\n");
            }
            catch (Exception ex)
            {
                textBox1.AppendText("hata" + ex.GetType());
            }
        }

        void GoAyrıMetod(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                textBox1.AppendText("İPTAL");
                token.ThrowIfCancellationRequested();
            }
            textBox1.AppendText("Hello from the thread pool, in the ayrı metod!\r\n");
        }

        void ArayaYaz()
        {
            textBox1.AppendText("araya girdim\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();//???almıyor
            }
        }

        #region ornek2
        private void btnOrnek2_Click(object sender, EventArgs e)
        {
            TaskMethod("Main Thread Task");//synconus çalşır, ünkü bi task içine sarılmadı. Obviously, it is not a thread - pool thread.
            Task<int> task = CreateTask("Task 1"); /*Then we run Task 1, starting it with the Start method and waiting for the result.
                This task will be placed on a thread pool, and the main thread waits and is blocked until the task returns.*/
            task.Start();
            int result = task.Result;
            textBox1.AppendText("Result is:" + result + "\r\n");

            task = CreateTask("Task 2");/*We do the same with Task 2, except that we run it using the RunSynchronously() method. This task will run on the main thread, and we get exactly the same output as in the very first case when we just called TaskMethod synchronously.This is a very useful
            optimization, allowing us to avoid thread pool usage for very short-lived operations.*/
            task.RunSynchronously();
            result = task.Result;
            textBox1.AppendText("Result is:" + result + "\r\n");

            task = CreateTask("Task 3");
            task.Start();
            while (!task.IsCompleted)
            {
                textBox1.AppendText(task.Status.ToString() + "\r\n");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            textBox1.AppendText(task.Status.ToString() + "\r\n");
            result = task.Result;
            textBox1.AppendText("Result is: " + result + "\r\n");
        }

        Task<int> CreateTask(string name)
        {
            return new Task<int>(() => TaskMethod(name));
        }
        int TaskMethod(string name)
        {
            textBox1.AppendText("Task " + name + " is running on a thread id  " + Thread.CurrentThread.ManagedThreadId + ".Is thread pool thread:" + Thread.CurrentThread.IsThreadPoolThread + "\r\n");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return 42;
        }
        #endregion


        #region ornek3
        private void btnOrnek3_Click(object sender, EventArgs e)
        {
            var firstTask = new Task<int>(() => TaskMethod("First Task",
3));
            var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));
            var whenAllTask = Task.WhenAll(firstTask, secondTask);
            whenAllTask.ContinueWith(t =>
            textBox1.AppendText("The first answer is "+ t.Result[0]+", the second is"+ t.Result[1]+ "\r\n"),TaskContinuationOptions.OnlyOnRanToCompletion);
            firstTask.Start();
            secondTask.Start();
            Thread.Sleep(TimeSpan.FromSeconds(4));
            var tasks = new List<Task<int>>();
            for (int i = 1; i < 4; i++)
            {
                int counter = i;
                var task = new Task<int>(() => TaskMethod(string.Format(
                "Task {0}", counter), counter));
                tasks.Add(task);
                task.Start();
            }

            while (tasks.Count > 0)
            {
                var completedTask = Task.WhenAny(tasks).Result;
                tasks.Remove(completedTask);
                textBox1.AppendText("A task has been completed with result "+ completedTask.Result + "\r\n");
}
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

         int TaskMethod(string name, int seconds)
        {
            textBox1.AppendText("Task "+ name+" is running on a thread id "+ Thread.CurrentThread.ManagedThreadId+". Is thread pool thread: "+Thread.CurrentThread.IsThreadPoolThread + "\r\n");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            return 42 * seconds;
        }
        #endregion
    }
}
