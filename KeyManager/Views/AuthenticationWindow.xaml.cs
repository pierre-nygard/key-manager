using KeyManager.Data;
using KeyManager.Models;
using System.Linq;
using System.Windows;

namespace KeyManager.Views
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

        public User User { get; private set; }

        public AuthenticationWindow(VaultContext context)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            _context = context;
            User = null;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            User = _context.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            if (User != null)
            {
                DialogResult = true;
            }
        }

    }
}
