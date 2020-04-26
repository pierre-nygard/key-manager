using KeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Set user ID
            int userID = 1;

            // Seed Services here
            var services = new List<Service>
            {
                new Service {Name = "Facebook", UserID = userID},
                new Service {Name = "Gmail", UserID = userID},
                new Service {Name = "Github", UserID = userID},
                new Service {Name = "StackOverflow", UserID = userID}
            };

            services.ForEach(s =>
            {
                _context.Services.Add(s);
            });

            _context.SaveChanges();
        }
    }
}
