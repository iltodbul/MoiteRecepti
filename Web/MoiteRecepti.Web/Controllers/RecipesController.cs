namespace MoiteRecepti.Web.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class RecipesController : Controller
    {
        private readonly ICategoryService categoryService;

        public RecipesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
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
        public IActionResult Create(CreateRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.categoryService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            // TODO: Create recipe using service method
            // TODO: Redirect to recipe info page.
            return this.Redirect("/");
        }
    }
}
