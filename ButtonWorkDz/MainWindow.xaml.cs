using System;
using System.Collections.Generic;
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

namespace ButtonWorkDz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Task task;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HardWork(object sender, RoutedEventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            task = new Task(new Action(TaskMethod));
            task.Start();
        }

        private void StopWork(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
        }

        private void TaskMethod()
        {
            MessageBox.Show("Раб работает!");
            int allWork = 10;
            int workTime = 0;
            while (workTime<allWork)
            {

                Thread.Sleep(1000);
                if (token.IsCancellationRequested)
                {
                    MessageBox.Show("Раб отдыхает!");
                    return;
                }
                workTime++;
            }
            
            MessageBox.Show("Раб выполнил работу!");
        }
    }
}
