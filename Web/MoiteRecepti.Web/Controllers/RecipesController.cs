namespace MoiteRecepti.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class RecipesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IRecipeService recipeService;

        public RecipesController(
            ICategoryService categoryService,
            IRecipeService recipeService)
        {
            this.categoryService = categoryService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel
            {
                Categories = this.categoryService.GetAllAsKeyValuePair(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.categoryService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            // return this.Json(inputModel);
            await this.recipeService.CreateAsync(inputModel);
            // TODO: Redirect to recipe info page.
            return this.Redirect("/");
        }
    }
}
