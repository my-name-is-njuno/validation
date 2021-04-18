using db.dbmodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace db
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<User> Users { get; set; }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
