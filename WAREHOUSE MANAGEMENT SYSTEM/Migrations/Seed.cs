using System.Collections.Generic;
using WAREHOUSE_MANAGEMENT_SYSTEM.Data.Models;
using WAREHOUSE_MANAGEMENT_SYSTEM.Data;
using System.Linq;
using System;

namespace WAREHOUSE_MANAGEMENT_SYSTEM.Migrations
{
    public class Seed
    {

        public static void Initialize(ApplicationDbContext context)
        {
            Console.WriteLine("Seeding data...");
            if (!context.Categories.Any())
            {
                SeedCategories(context);
            }

            if (!context.Products.Any())
            {
                SeedProducts(context);
            }
        }

        private static void SeedCategories(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Clothing" },
                // Add more categories as needed
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedProducts(ApplicationDbContext context)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Laptop",
                    Description = "Powerful laptop for all your needs",
                    Cost = 800,
                    Price = 1200,
                    Count = 10,
                    CategoryId = context.Categories.FirstOrDefault(c => c.Name == "Electronics").Id,
                    ImageUrl = "https://th.bing.com/th/id/OIP.PkZI8I15yCPQrsDGgW_LxAHaEY?rs=1&pid=ImgDetMain"
                },
                // Add more products as needed
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
