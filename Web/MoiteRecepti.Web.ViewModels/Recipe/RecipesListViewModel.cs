namespace MoiteRecepti.Web.ViewModels.Recipe
{
    using System.Collections.Generic;

    public class RecipesListViewModel : PagingViewModel
    {
        public IEnumerable<RecipeInListViewModel> Recipes { get; set; }
    }
}
