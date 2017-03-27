using EStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Data
{
    public static class DbInitializer
    {

        public static string[] Categories = new string[]
        {
            "Category1",
            "Category2",
            "Category3",
            "Category4"
        };

        public static string[][] Products = new string[][]
        {
            new string[]{ "Basket Ball", "Description", "Category1" },
            new string[]{ "Basket Ball", "Description", "Category1" },
            new string[]{ "Basket Ball", "Description", "Category1" }
        };

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            foreach (var category in Categories)
            {
                context.Categories.Add(new Category
                {
                    Name = category,
                    User = context.Users.Where(u => u.Email == "admin@demo").FirstOrDefault()
                });
            }

            context.SaveChanges();

            var rand = new Random();

            foreach (var product in Products)
            {
                context.Products.Add(new Product
                {
                    Name = product[0],
                    Description = product[1],
                    Price = (decimal)rand.NextDouble() * 10000,
                    CreatedAt = DateTime.Now,
                    User = context.Users.Where(u => u.Email == "admin@demo").FirstOrDefault(),
                    Public = true,
                });
            }

            context.SaveChanges();
        }
    }
}
