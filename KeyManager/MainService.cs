using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManager
{
    class MainService : IMainService
    {
        private readonly VaultContext _context;
        private User _user;

        public MainService(VaultContext context)
        {
            _context = context;
        }

        public IMainService SetForUser(User user)
        {
            _user = user;
            return this;
        }

        public IMainService Run() 
        {
            var mainWindow = new MainWindow(_context, _user);
            mainWindow.ShowDialog();
            return this;
        }
    }
}
