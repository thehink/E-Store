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
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category {
                    Name = "Stuff",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "More Stuff",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Even More Stuff",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Lul",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Balbla",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Sub Category to More Stuff",
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var products = new Product[]
            {
                new Product {
                    Name = "Basket Ball",
                    Description = "Really Nice basket ball",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
                    Public = true,
                },
                new Product {
                    Name = "Football",
                    Description = "Really Nice basket ball",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
                    Public = true,
                },
                new Product {
                    Name = "Key",
                    Description = "A really nice key",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    User = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
                    Public = true,
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}
