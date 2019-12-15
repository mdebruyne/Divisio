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
using System.Windows.Shapes;

namespace Divisio.Views
{
    /// <summary>
    /// Interaction logic for Login_Window.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public Login_Window()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void OpenRegister(object sender, RoutedEventArgs e)
        {
            Register_Window register = new Register_Window();
            this.Visibility = Visibility.Hidden;
            register.Show();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            StartScreen start = new StartScreen();
            this.Visibility = Visibility.Hidden;
            start.Show();

        }
    }
}

