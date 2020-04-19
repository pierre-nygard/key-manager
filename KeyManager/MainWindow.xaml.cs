using KeyManager.Data;
using KeyManager.Models;
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

namespace KeyManager
{
    public partial class MainWindow : Window
    {
        private readonly VaultContext _context;

        public User User { get; set; }

        public MainWindow(VaultContext context, User user)
        {
            InitializeComponent();
            _context = context;
            User = new User();
            mainLabel.Content = User.UserName;
        }
    }
}
