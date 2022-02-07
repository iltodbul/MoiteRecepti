namespace MoiteRecepti.Services.Data.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CountsDTO
    {
        public int CategoriesCount { get; set; }

        public int RecipesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int ImagesCount { get; set; }
    }
}
