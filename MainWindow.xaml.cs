using System;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Homework2._14
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private bool Direct = true;
        private bool isStopping = false;
        private bool firstCheck = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tickfunc(object sender, EventArgs e)
        {
            if (!isStopping)
            {
                if (Direct == true && (int)(grid1.ActualWidth - label1.Margin.Left - label1.ActualWidth) >= 30)
                {
                    label1.Margin = new Thickness(label1.Margin.Left + 30, 119, 0, 0);
                }
                if((int)(grid1.ActualWidth - label1.Margin.Left - label1.ActualWidth) < 30)
                {
                    label1.Margin = new Thickness(grid1.ActualWidth - label1.ActualWidth, 119, 0, 0);
                }
                if (label1.Margin.Left == grid1.ActualWidth - label1.ActualWidth)
                {
                    Direct = false;
                }

                if (Direct == false  &&label1.Margin.Left >= 0)
                {
                    label1.Margin = new Thickness(label1.Margin.Left - 30, 119, 0, 0);
                }
                if (label1.Margin.Left < 30)
                {
                    label1.Margin = new Thickness(0, 119, 0, 0);
                }
                if (label1.Margin.Left == 0)
                {
                    Direct = true;
                }
            }
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (firstCheck)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += new EventHandler(tickfunc);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                firstCheck = false;
            }
            isStopping = false;
        }

        private void buttonEnd_Click(object sender, RoutedEventArgs e)
        {
            isStopping = true;
        }
    }
}