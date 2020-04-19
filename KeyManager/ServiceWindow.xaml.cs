using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private readonly VaultContext _context;
        public Service Service { get; set; }
        public List<Models.Key> Keys  { get; set; }

        public ServiceWindow(VaultContext context, Service service, List<Models.Key> keys)
        {
            InitializeComponent();
            Keys = new List<Models.Key>();
            Keys = keys;

            Service = new Service();
            Service = service;

            _context = context;

            lvKeys.ItemsSource = Keys;

            DataContext = this;
        }
    }
}
