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
using System.Windows.Input;

namespace ThreadOrnek
{
    public partial class TaskScheduleOrnek : Form
    {
        public TaskScheduleOrnek()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            try
            {
                //string result = TaskMethod(TaskScheduler.
                //FromCurrentSynchronizationContext()).Result;
                /*If we uncomment the line with getting the result with the UI thread
        task scheduler provided, we will never get any result. This is a classical deadlock situation:
        we are dispatching an operation in the queue of the UI thread and the UI thread waits for
        this operation to complete, but as it waits, it cannot run the operation, which will never
        end (not even start). This will also happen if we call the Wait method on task. To avoid the
        deadlock, never use the synchronous operations on task scheduled to the UI thread; just use
        ContinueWith, or async/await from C# 5.0.*/
                string result = TaskMethod().Result;
                label1.Text = result;
            }
            catch (Exception ex)
            {
                label1.Text = ex.InnerException.Message;
            }
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            Task<string> task = TaskMethod();
            task.ContinueWith(t =>
            {
                label1.Text = t.Exception.InnerException.Message;
                Mouse.OverrideCursor = null;
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnAsyncOk_Click(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            Task<string> task = TaskMethod(TaskScheduler.FromCurrentSynchronizationContext());
            task.ContinueWith(t => Mouse.OverrideCursor = null, CancellationToken.None,
            TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        Task<string> TaskMethod()
        {
            return TaskMethod(TaskScheduler.Default);
        }

        Task<string> TaskMethod(TaskScheduler scheduler)
        {
            Task delay = Task.Delay(TimeSpan.FromSeconds(5));
            return delay.ContinueWith(t =>
            {
                string str = string.Format("Task is running on a thread id {0}. Is thread pool thread {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
                label1.Text = str;
                return str;
            }, scheduler);
        }
    }
}
