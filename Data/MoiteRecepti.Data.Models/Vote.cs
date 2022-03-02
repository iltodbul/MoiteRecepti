namespace MoiteRecepti.Data.Models
{
    using MoiteRecepti.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public virtual Recipe Recipe { get; set; }

        public int RecipeId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public byte Value { get; set; }
    }
}
