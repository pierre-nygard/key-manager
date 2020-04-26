using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KeyManager.Views
{
    /// <summary>
    /// Interaction logic for KeyAddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public string ObjectName
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        public AddWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
            => this.DialogResult = false;

        private void AddButton_Click(object sender, RoutedEventArgs e)
            => this.DialogResult = true;
    }
}
