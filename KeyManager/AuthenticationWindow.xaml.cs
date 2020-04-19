using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeyManager
{
    public partial class AuthenticationWindow : Window
    {
        private readonly VaultContext _context;
        public string UserName 
        {
            get => userNameTextBox.Text;
            set => userNameTextBox.Text = value;
        }

        public string Password
        {
            get => passwordTextBox.Password;
            set => passwordTextBox.Password = value;
        }

        private User _user;

        public AuthenticationWindow(VaultContext context)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            _context = context;
            _user = null;
            InitializeComponent();
        }

        public User GetUser()
        {
            return _user;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            _user = _context.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            if (_user != null)
            {
                DialogResult = true;
            }
        }

    }
}
