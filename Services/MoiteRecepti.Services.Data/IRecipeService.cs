namespace MoiteRecepti.Services.Data
{
    using System.Threading.Tasks;

    using MoiteRecepti.Web.ViewModels.Recipe;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel input);
    }
}
