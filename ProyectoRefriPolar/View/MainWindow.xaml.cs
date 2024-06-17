using ProyectoRefriPolar.ViewModel;
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

namespace ProyectoRefriPolar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count;
        MainWindowVM vm;
        public MainWindow()
        {
            vm = new MainWindowVM();
            InitializeComponent();
            count = 0;
            this.DataContext = vm;
            this.SizeChanged += MainWindow_SizeChanged;
        }
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                AdjustBorderMarginForMaximized();
            }
            else
            {
                RestoreBorderMargin();
            }
        }
        private void AdjustBorderMarginForMaximized()
        {
            btnMaxSize.Content = "🗗";
            windowBorder.BorderThickness = new Thickness(0);
            windowGrid.Margin = new Thickness(7);
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResize;
        }

        private void RestoreBorderMargin()
        {
            // Restaurar el margen del Border cuando la ventana se restaura
            btnMaxSize.Content = "🗖";
            windowBorder.BorderThickness = new Thickness(0.5);
            windowGrid.Margin = new Thickness(0);
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResize;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void WindowBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            count++;
            if (count == 2)
            {
                btnMaxSize_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinim_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaxSize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
            count = 0;
        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
