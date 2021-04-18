using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace db
{
    public class ProjectDbContextOptionFactory
    {
        private readonly string _cs;

        public ProjectDbContextOptionFactory(string cs)
        {
            _cs = cs;
        }

        public ProjectDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>();
            options.UseMySql(_cs);
            return new ProjectDbContext(options.Options);
        }
    }
}
