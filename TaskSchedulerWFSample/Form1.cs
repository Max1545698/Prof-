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

namespace TaskSchedulerWFSample
{
    public partial class MyForm : Form
    {
        private readonly TaskScheduler m_syncContextTaskScheduler;

        public MyForm()
        {
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true; Width = 600; Height = 100;
            //InitializeComponent();
        }

        // private readonly TaskScheduler m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        private CancellationTokenSource m_cts;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else
            {
                Text = "Operation running";
                m_cts = new CancellationTokenSource();

                Task<int> t = Task.Run(() => Sum(m_cts.Token, 20000), m_cts.Token);

                t.ContinueWith(task => Text = "Result: " + task.Result,
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    m_syncContextTaskScheduler);

                t.ContinueWith(task => Text = "Operation faulted",
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnCanceled,
                    m_syncContextTaskScheduler);

                t.ContinueWith(task => Text = "Operation faulted",
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnFaulted,
                    m_syncContextTaskScheduler);
            }
            base.OnMouseClick(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public int Sum(CancellationToken token, int sum)
        {
            int result = 0; ;
            for (; sum > 0; sum--)
            {
                token.ThrowIfCancellationRequested();
                checked { result += sum; }
            }
            return result;
        }
    }
}
