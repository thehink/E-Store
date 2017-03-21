using EStore.Models;
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
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "More Stuff",
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Even More Stuff",
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Lul",
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Balbla",
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new Category {
                    Name = "Sub Category to More Stuff",
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var subCategories = new SubCategory[]
            {
                new SubCategory {
                    Name = "Stuff",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new SubCategory {
                    Name = "More Stuff",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new SubCategory {
                    Name = "Even More Stuff",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new SubCategory {
                    Name = "Lul",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new SubCategory {
                    Name = "Balbla",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
                new SubCategory {
                    Name = "Sub Category to More Stuff",
                    ParentCategory = context.Categories.Where(u => u.Id == 1).FirstOrDefault(),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault()
                },
            };

            foreach (var subCategory in subCategories)
            {
                context.SubCategories.Add(subCategory);
            }

            context.SaveChanges();

            var products = new Product[]
            {
                new Product {
                    Name = "Basket Ball",
                    Description = "Really Nice basket ball",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
                    Public = true,
                },
                new Product {
                    Name = "Football",
                    Description = "Really Nice basket ball",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
                    Public = true,
                },
                new Product {
                    Name = "Key",
                    Description = "A really nice key",
                    Price = 4.99m,
                    CreatedAt = new DateTime(1996, 5, 2),
                    Author = context.Users.Where(u => u.Email == "benja280@gmail.com").FirstOrDefault(),
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
