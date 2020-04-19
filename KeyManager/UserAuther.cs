using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManager
{
    class UserAuther : IUserAuther
    {
        private readonly VaultContext _context;
        private User _user;

        public User User
        {
            get { return _user; }
        }


        public UserAuther(VaultContext context)
        {
            _context = context;
        }

        public IUserAuther Run()
        {
            _user = null;
            AuthenticationWindow authWindow = new AuthenticationWindow(_context);
            authWindow.ShowDialog();
            if(authWindow.DialogResult == true)
            {
                _user = authWindow.GetUser();
            }
            return this;
        }

        public bool AuthIsValid() => _user != null;
    }
}
