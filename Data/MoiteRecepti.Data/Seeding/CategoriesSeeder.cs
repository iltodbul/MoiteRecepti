﻿namespace MoiteRecepti.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category() { Name = "Тарт" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Кекс" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Пай" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Печено свинско" });

            await dbContext.SaveChangesAsync();
        }
    }
}
