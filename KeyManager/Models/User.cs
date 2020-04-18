using KeyManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyManager.Models
{
    [Table("User")]
    public class User : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(); }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; NotifyPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(); }
        }

        private int _id;
        private string _userName;
        private string _password;

        public List<Service> Services { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task<List<User>> GetAll(VaultContext context) 
            => await context.Users.ToListAsync();
    }
}
