using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;
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

        public User _user;

        private List<Service> services;
        private List<KeyManager.Models.Key> keys;

        public MainWindow(VaultContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;

            services = LoadServices();
            services.ForEach(s => MessageBox.Show(s.Name));
            keys = new List<KeyManager.Models.Key>();
        }

        private List<Service> LoadServices()
        {
            return _context.Services.Where(s => s.UserID == _user.ID).ToList();
        }
    }
}
