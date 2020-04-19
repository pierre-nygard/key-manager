using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<Service> Services { get; set; }
        private List<Models.Key> Keys { get; set; }

        public MainWindow(VaultContext context, User user, List<Service> services)
        {
            InitializeComponent();

            _context = context;
            User = user;

            Services = new List<Models.Service>();
            Keys = new List<Models.Key>();

            Services = services;

            lvServices.ItemsSource = services;
        }

        private List<Service> LoadServices()
        {
            return _context.Services.Where(s => s.UserID == User.ID).ToList();
        }

        public class Foo
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private void lvServices_Click(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            var dataItem = lvServices.ItemContainerGenerator.ItemFromContainer(item);
            var service = (Service)dataItem;

            if (item.IsSelected && item != null)
            {
                MessageBox.Show(service.UserID.ToString());
            }
        }
    }
}
