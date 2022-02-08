namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
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

        public async Task CreateAsync(CreateRecipeInputModel input)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                Instruction = input.Instruction,
                PortionCount = input.PortionCount,
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
    }
}
