using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KeyManager.Views
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private readonly VaultContext _context;
        public Service Service { get; set; }
        public List<Models.Key> Keys  { get; set; }

        public ServiceWindow(VaultContext context, Service service)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            _context = context;

            Service = service;

            Keys = LoadKeys();

            this.VisuallyReset();

            DataContext = this;
        }

        private void VisuallyReset()
        {
            lvKeys.ItemsSource = null;
            lvKeys.ItemsSource = Keys;
        }

        private List<Key> LoadKeys() 
            =>  _context.Keys
                .Where(k => k.ServiceID == Service.ID)
                .ToList();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addKey = new KeyAddWindow();
            addKey.ShowDialog();
            if(addKey.DialogResult == true)
            {
                var key = new Key
                {
                    ServiceID = Service.ID,
                    Value = addKey.KeyName
                };
                key.Add(_context);
                Keys.Add(key);
                VisuallyReset();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lvKeys.SelectedItem == null)
                return;

            Key key = lvKeys.SelectedItem as Key;
            key.Remove(_context);
            Keys.Remove(key);
            VisuallyReset();
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
