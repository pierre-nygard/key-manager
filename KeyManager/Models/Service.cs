using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace KeyManager.Models
{
    [Table("Service")]
    public class Service : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(); }
        }
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; NotifyPropertyChanged(); }
        }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; NotifyPropertyChanged(); }
        }
        public User User { get; set; }
        public List<Key> Keys { get; set; }

        private int _id;
        private string _serviceName;
        private int _userID;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
