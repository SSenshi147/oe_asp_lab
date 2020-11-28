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
using TicketApiClient;
using TicketSwap.Shared;

namespace TicketSwap.Wpf
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        RestService<LoginViewModel, string> _loginService;

        public LoginWindow()
        {
            InitializeComponent();
            _loginService = new RestService<LoginViewModel, string>("https://localhost:44398", "/api/user/login");
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var result = await _loginService.Post<LoginResponse>(new LoginViewModel()
            {
                Username = textBox_userName.Text,
                Password = passwordBox_password.Password
            });

            string token = result.Token;

            MainWindow mainWindow = new MainWindow(token);
            mainWindow.ShowDialog();
        }
    }
}
