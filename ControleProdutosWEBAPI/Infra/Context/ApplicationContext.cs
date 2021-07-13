/*
 * Copyright 2021 Sandro Mendes
 * 
 * This file is part of ControleEstoqueBackEnd.
 * 
 * ControleEstoqueBackEnd is free software: you can redistribute it and/or modify it under the terms 
 * of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * 
 * ControleEstoqueBackEnd is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * 
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with Foobar. 
 * 
 * If not, see http://www.gnu.org/licenses/.
 */

using ControleProdutosWEBAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleProdutosWEBAPI.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DBProduct");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.CategoryFK);
        }
    }

    public class ReadContext
    {
        private readonly ApplicationContext _dbContext;

        public ReadContext(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Set<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}
