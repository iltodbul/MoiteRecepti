namespace MoiteRecepti.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> voteRepository;

        public VotesService(IRepository<Vote> voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public async Task SetVoteAsync(int recipeId, string userId, byte value)
        {
            var vote = this.voteRepository
                .All()
                .FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    RecipeId = recipeId,
                    UserId = userId,
                };

                await this.voteRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.voteRepository.SaveChangesAsync();
        }

        public double GetAverageVote(int recipeId)
        {
            return this.voteRepository
                .All()
                .Where(r => r.RecipeId == recipeId)
                .Average(x => x.Value);
        }
    }
}
