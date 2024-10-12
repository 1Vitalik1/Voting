using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Voting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.frame = frame;
            App.backFrame = backFrame;
        }

        private void win_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.Close();

        private void win_state_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else { this.WindowState = WindowState.Normal; }
        }

        private void win_minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.WindowState = WindowState.Minimized;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void backFrame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.frame.GoBack();
            Border border = (Border)sender;
            border.Visibility = Visibility.Collapsed;
        }
    }
}