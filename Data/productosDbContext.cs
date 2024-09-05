using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSRosaAPI.Models;

namespace MSRosaAPI.Data
{
    public class productosDbContext : DbContext
    {
        public DbSet<Producto> productos{get;set;}

        public productosDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}