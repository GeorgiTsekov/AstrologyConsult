namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;

    public class CreateArticleInputModel : BaseArticleInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
