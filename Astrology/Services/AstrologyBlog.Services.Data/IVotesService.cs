namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int articleId, string userId, byte starsCount);

        double GetAverageStarsFromVotes(int articleId);
    }
}
