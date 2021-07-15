using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace My1stWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _animationtimer = new();
        private bool MoveToRight = true;
        private bool MoveToBottom = true;
        public MainWindow()
        {
            InitializeComponent();
            _animationtimer.Interval = TimeSpan.FromMilliseconds(40);
            _animationtimer.Tick += SetBallPosition;
        }

        private void SetBallPosition(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            double x = Canvas.GetLeft(ellBall);
            double y = Canvas.GetTop(ellBall);

            if (MoveToRight)
            {
                Canvas.SetLeft(ellBall, x + 5);
            }
            else
            {
                Canvas.SetLeft(ellBall, x - 5);
            }
            if (MoveToBottom)
            {
                Canvas.SetTop(ellBall, y + 5);
            }
            else
            {
                Canvas.SetTop(ellBall, y - 5);
            }

            if (x >= CanGameCourt.ActualWidth-ellBall.ActualWidth)
            {
                MoveToRight = false;
            }
            else if (x <= 0)
            {
                MoveToRight = true;
            }

            if (y >= CanGameCourt.ActualHeight - ellBall.ActualHeight)
            {
                MoveToBottom = false;
            }
            else if (y <= 0)
            {
                MoveToBottom = true;
            }

        }

        private void BtnOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (_animationtimer.IsEnabled)
            {
                _animationtimer.Stop();
            }
            else
            {
                _animationtimer.Start();
            }
            //double MitteX = CanGameCourt.ActualWidth / 2;
            //double MitteY = CanGameCourt.ActualHeight / 2;
            //Canvas.SetLeft(ellBall, MitteX);
            //Canvas.SetTop(ellBall, MitteY);
        }

        private void ellBall_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
