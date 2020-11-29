namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        /// <summary>
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="userId"></param>
        /// <param name="isUpVote">If true - up vote, else - neutral vote.</param>
        /// <returns></returns>
        Task VoteAsync(int articleId, string userId, bool isUpVote);

        int GetVotes(int articleId);
    }
}
