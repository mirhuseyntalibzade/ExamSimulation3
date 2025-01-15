using CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Category>().HasData(
                   new Category() { Id = 1,CategoryName= "Academic departments" },
                   new Category() { Id = 2, CategoryName = "Alumni" },
                   new Category() { Id = 3, CategoryName = "Business & Enterprise" },
                   new Category() { Id = 4, CategoryName = "Departments A - Z" }
            );
        }
    }
}
