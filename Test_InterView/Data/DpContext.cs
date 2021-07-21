using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_InterView.Models;

namespace Test_InterView.Data
{
    public class DpContext : DbContext
    {
        public DpContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
