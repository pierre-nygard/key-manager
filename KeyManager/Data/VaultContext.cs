using KeyManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyManager.Data
{
    public class VaultContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<User> Users { get; set; }

        public VaultContext(DbContextOptions<VaultContext> options) : base(options) { }
    }
}
