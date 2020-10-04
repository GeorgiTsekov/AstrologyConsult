namespace ForumSystem.Services.Data
{
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreateAsynk(string title, string content, int categoryId, string userId);
    }
}
