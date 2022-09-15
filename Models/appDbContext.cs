using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Post_Experience.Models
{
    public class appDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {



        }
    }
}

