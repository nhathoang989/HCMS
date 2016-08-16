using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCMS.CRM.UserControls
{
    /// <summary>
    /// Interaction logic for UCLoading.xaml
    /// </summary>
    public partial class UCProcessing : UserControl
    {
        public UCProcessing()
        {
            InitializeComponent();
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worder_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainProgressBar.Value = e.ProgressPercentage;
            ProgressTexBlock.Text = (string)e.UserState;
        }

        private void worder_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(50, "Processing 50");
            Thread.Sleep(3000);
            worker.ReportProgress(100, "Done");

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("All Done");
            MainProgressBar.Value = 0;
            ProgressTexBlock.Text = "";
        }
    }
}
