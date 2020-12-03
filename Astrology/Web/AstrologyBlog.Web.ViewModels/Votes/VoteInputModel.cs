namespace AstrologyBlog.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class VoteInputModel
    {
        public int ArticleId { get; set; }

        [Range(1, 5)]
        public byte StarsCount { get; set; }
    }
}
