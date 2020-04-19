using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyManager.Data
{
    public class DbInitializer
    {
        private readonly VaultContext _context;

        /// <summary>
        /// For Development purpose only
        /// </summary>
        /// <param name="context"></param>
        public DbInitializer(VaultContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            if(_context.Services.Count() > 3) 
            {
                return;
            }

            int userID = 1;

            var services = new List<Service>
            {
                new Service {Name = "Facebook", UserID = userID},
                new Service {Name = "Loopia", UserID = userID},
                new Service {Name = "Gmail", UserID = userID},
                new Service {Name = "Github", UserID = userID},
                new Service {Name = "LendFair", UserID = userID},
                new Service {Name = "StackOverflow", UserID = userID},
                new Service {Name = "RentPersonligt", UserID = userID}
            };

            services.ForEach(s =>
            {
                _context.Services.Add(s);
            });

            _context.SaveChanges();
        }
    }
}
