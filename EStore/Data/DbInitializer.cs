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
            "Fruits",
            "Animals",
            "Stuff",
            "Misc",
        };

        public static string[][] Products = new string[][]
        {
            new string[]{ "Yellow Banana", "Nice yellow banana delivered to your nearest service point." },
            new string[]{ "Red Cherry", "", "Fruits", "cherry.png" },

            new string[]{ "Sofisticated Crocodile", "", "Animals", "crocodile.png" },
            new string[]{ "Bouncy Rubber Duck", "", "Animals", "duck.png" },

            new string[]{ "Greasy Gear", "", "Stuff", "gear.png" },
            new string[]{ "Shiny Key", "This shiny key opens many doors", "Stuff", "key.png" },
            new string[]{ "Real Human Skull", "Ever felt the need to own a real human skull?", "Stuff", "skull.png" },
            new string[]{ "Stop Sign", "When just saying stop is not enough", "Stuff", "stop.png" },
            new string[]{ "Single Wheel", "", "Stuff", "wheel.png" },
            new string[]{ "Bright Sun", "", "Stuff", "sun.png" },
            new string[]{ "Real Fake Diamond", "", "Stuff", "diamond.png" },
            new string[]{ "Carpet", "", "Stuff", "carpet.png" },

            new string[]{ "Abstract Question Mark", "", "Misc", "question-mark12.png" },
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
                    Category = context.Categories.FirstOrDefault(c => c.Name == product[2]),
                    Image = $"/product_images/{product[3]}",
                });
            }

            context.SaveChanges();
        }
    }
}
