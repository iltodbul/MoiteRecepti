namespace MoiteRecepti.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            var categories = this.categoryRepository
                .AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

            return categories;
        }
    }
}
