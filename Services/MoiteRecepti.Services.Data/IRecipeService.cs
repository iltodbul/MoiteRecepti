namespace MoiteRecepti.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MoiteRecepti.Web.ViewModels.Recipe;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();
    }
}
