namespace MoiteRecepti.Services.Data
{
    using System.Linq;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Data.DTOs;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly IRepository<Image> imageRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipeRepository,
            IRepository<Image> imageRepository)
        {
            this.categoryRepository = categoryRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeRepository = recipeRepository;
            this.imageRepository = imageRepository;
        }

        public CountsDTO GetCounts()
        {
            var countsDto = new CountsDTO()
            {
                CategoriesCount = this.categoryRepository.All().Count(),
                ImagesCount = this.imageRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
                RecipesCount = this.recipeRepository.All().Count(),
            };

            return countsDto;
        }
    }
}
