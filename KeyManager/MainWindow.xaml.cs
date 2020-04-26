using KeyManager.Data;
using KeyManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using KeyManager.Views;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KeyManager
{
    public partial class MainWindow : Window
    {
        private readonly VaultContext _context;

        public User User { get; set; }

        private List<Service> Services { get; set; }

        public MainWindow(VaultContext context, User user)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            _context = context;

            User = user;

            Services = LoadServices();

            this.VisuallyReset();

            DataContext = this;
        }

        public List<Service> LoadServices()
        {
            return _context.Services.Where(s => s.UserID == User.ID).ToList();
        }

        private void VisuallyReset()
        {
            lvServices.ItemsSource = null;
            lvServices.ItemsSource = Services;
        }

        private void lvServices_Click(object sender, MouseButtonEventArgs e)
        {
            if (lvServices.SelectedItem == null)
                return;

            Service service = lvServices.SelectedItem as Service;

            var window = new ServiceWindow(_context, service);
            window.ShowDialog();
            this.VisuallyReset();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
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
            service.Delete(_context);
            Services.Remove(service);
            this.VisuallyReset();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var addService = new AddWindow();
            addService.ShowDialog();

            if(addService.DialogResult == true && string.IsNullOrEmpty(addService.ObjectName) == false)
            {
                var service = new Service 
                { 
                    Name = addService.ObjectName,
                    User = this.User
                };
                service.Add(_context);
                Services.Add(service);
            }
            this.VisuallyReset();
        }
    }
}
