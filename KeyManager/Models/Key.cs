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
    [Table("Key")]
    public class Key : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; NotifyPropertyChanged(); }
        }
        public string Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged(); }
        }
        public int ServiceID
        {
            get { return _serviceID; }
            set { _serviceID = value; NotifyPropertyChanged(); }
        }
        private int _id;
        private string _value;
        private int _serviceID;

        public Service Service { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Remove(VaultContext context) 
        {
            context.Keys.Remove(this);
            context.SaveChanges();
        }

        public void Add(VaultContext context)
        {
            context.Keys.Add(this);
            context.SaveChanges();
        }

        public void Update(VaultContext context)
        {
            context.Keys.Update(this);
            context.SaveChanges();
        }
    }
}
