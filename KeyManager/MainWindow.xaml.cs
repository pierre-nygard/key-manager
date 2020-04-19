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

            RefreshVisualServices();

            DataContext = this;
        }

        private void RefreshVisualServices()
        {
            lvServices.ItemsSource = null;
            lvServices.ItemsSource = Services;
        }

        public class Foo
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private void lvServices_Click(object sender, MouseButtonEventArgs e)
        {
            if (lvServices.SelectedItem == null)
                return;

            Service service = lvServices.SelectedItem as Service;

            var keys = GetKeys(service);
            var window = new ServiceWindow(_context, service, keys);
            window.ShowDialog();
            RefreshVisualServices();
        }

        private List<Models.Key> GetKeys(Service service)
        {
            return _context.Keys.Where(k => k.ServiceID == service.ID).ToList();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lvServices.SelectedItem == null)
                return;

            Service service = lvServices.SelectedItem as Service;

            int foundKeys = _context.Keys.Where(k => k.ServiceID == service.ID).Count();
            if (foundKeys > 0)
            {
                MessageBox.Show($"Kan ej ta bort {service.Name}!\nHittade tillhörande {foundKeys} Keys. Ta bort dessa ifall du vill fortsätta.");
                return;
            }
            service.Remove(_context);
            Services.Remove(service);
            RefreshVisualServices();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Services.Add(new Service { Name = "New Service Name" });
            RefreshVisualServices();
        }
    }
}
