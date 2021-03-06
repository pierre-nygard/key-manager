﻿using KeyManager.Data;
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
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; NotifyPropertyChanged(); }
        }
        public User User { get; set; }
        public List<Key> Keys { get; set; }

        private int _id;
        private string _name;
        private int _userID;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete(VaultContext context)
        {
            context.Services.Remove(this);
            context.SaveChanges();
        }

        public void Add(VaultContext context)
        {
            context.Services.Add(this);
            context.SaveChanges();
        }
    }
}
