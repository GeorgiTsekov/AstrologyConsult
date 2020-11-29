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

        public int GetVotes(int articleId)
        {
            var votes = this.votesRepository.All()
                 .Where(x => x.ArticleId == articleId).Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int articleId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ArticleId == articleId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.Neutral;
            }
            else
            {
                vote = new Vote
                {
                    ArticleId = articleId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.Neutral,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
