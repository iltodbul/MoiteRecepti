namespace MoiteRecepti.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class RecipesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IRecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public RecipesController(
            ICategoryService categoryService,
            IRecipeService recipeService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.categoryService = categoryService;
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel
            {
                Categories = this.categoryService.GetAllAsKeyValuePair(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.categoryService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            var imagePath = $"{this.environment.WebRootPath}/images";

            try
            {
                await this.recipeService.CreateAsync(inputModel, user.Id, imagePath);
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError(string.Empty, e.Message);
                inputModel.Categories = this.categoryService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            // TODO: Redirect to recipe info page.
            return this.Redirect("/");
        }

        // Recipes/All/nomer str.
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new RecipesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                RecipesCount = this.recipeService.GetCount(),
                Recipes = this.recipeService.GetAll<RecipeInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var recipe = this.recipeService.GetById<SingleRecipeViewModel>(id);
            return this.View(recipe);
        }
    }
}
