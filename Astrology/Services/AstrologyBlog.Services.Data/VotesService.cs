namespace AstrologyBlog.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageStarsFromVotes(int articleId)
        {
            var averageStarsVote = this.votesRepository.All()
                 .Where(x => x.ArticleId == articleId)
                 .Average(x => x.StarsCount);
            return averageStarsVote;
        }

        public async Task VoteAsync(int articleId, string userId, byte starsCount)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ArticleId == articleId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    ArticleId = articleId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.StarsCount = starsCount;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
