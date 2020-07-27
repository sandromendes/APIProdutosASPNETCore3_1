using ControleProdutosWEBAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DBAppSample;Integrated Security=True");
        }
    }
}
