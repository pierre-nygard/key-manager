using KeyManager.Data;
using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManager
{
    class MainService : IMainService
    {
        private readonly VaultContext _context;
        private List<Service> _services;
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
            _services = new List<Service>();

            var task = Task.Run(() => LoadServices());
            task.Wait();

            _services = task.Result;
            MainWindow mainWindow = new MainWindow(_context, _user, _services);
            mainWindow.ShowDialog();
            return this;
        }

        private List<Service> LoadServices()
        {
            return _context.Services.Where(s => s.UserID == _user.ID).ToList();
        }
    }
}
