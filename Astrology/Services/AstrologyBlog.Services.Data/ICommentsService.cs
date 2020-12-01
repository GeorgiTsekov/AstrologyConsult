namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int articleId, string userId, string content, int? parentId = null);

        bool IsCommentInArticle(int commentId, int articleId);
    }
}
