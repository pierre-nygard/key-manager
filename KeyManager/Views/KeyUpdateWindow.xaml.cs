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

namespace KeyManager.Views
{
    /// <summary>
    /// Interaction logic for KeyUpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public string KeyName 
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        public UpdateWindow(Models.Key key)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            NameTextBox.Text = key.Value;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
            => this.DialogResult = false;

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
            => this.DialogResult = true;
    }
}
