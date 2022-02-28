namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Mapping;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class RecipeService : IRecipeService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public RecipeService(IDeletableEntityRepository<Recipe> recipeRepository, IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                Instructions = input.Instruction,
                PortionsCount = input.PortionCount,
                AddedByUserId = userId,
            };

            foreach (var inputIngredient in input.Ingredients)
            {
                var ingredient = this.ingredientRepository.All().FirstOrDefault();
                if (ingredient == null)
                {
                    ingredient = new Ingredient() { Name = inputIngredient.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient()
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });
            }

            await this.recipeRepository.AddAsync(recipe);
            await this.recipeRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var recipes = this.recipeRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            // 1-12-page 1 propuskame 0 formula: (page-1)*itemsPerPage
            // 13-24-page 2
            return recipes;
        }

        public int GetCount()
        {
            return this.recipeRepository.All().Count();
        }
    }
}
