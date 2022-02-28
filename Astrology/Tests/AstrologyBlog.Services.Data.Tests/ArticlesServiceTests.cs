namespace AstrologyBlog.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AstrologyBlog.Web.ViewModels;
    using AstrologyBlog.Web.ViewModels.Articles;
    using Moq;
    using Xunit;

    public class ArticlesServiceTests
    {
        public ArticlesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void TestGetCountOfArticles_WithoutAnyData_ShouldReturnZero()
        {
            var mockArticleRepo = new Mock<IDeletableEntityRepository<Article>>();
            mockArticleRepo.Setup(x => x.All()).Returns(ListOfArticles().AsQueryable());

            var articlesService = new ArticlesService(mockArticleRepo.Object);
            var allArticles = articlesService.GetAll<ArticleViewModel>(1, 12);
            ////Assert.Equal("Sesho", articlesService.GetById<SingleArticleViewModel>(1).Name);
            ////Assert.Equal("Gosho", articlesService.GetById<EventViewModel>(2).Name);
            Assert.Equal(2, allArticles.Count());
        }

        private static List<Article> ListOfArticles()
        {

            ////    var content = "Hello World from a Fake File";
            ////    var fileName = "test.pdf";
            ////    var stream = new MemoryStream();
            ////    var writer = new StreamWriter(stream);
            ////    writer.Write(content);
            ////    writer.Flush();
            ////    stream.Position = 0;
            ////    IFormFile presentation = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            ////    var presentations = new List<IFormFile>
            ////    {
            ////        presentation,
            ////    };
            Directory.CreateDirectory("../images/articles/");
            var fileName = "https://i.stack.imgur.com/bWyA9.png";
            var extension = Path.GetExtension(fileName).TrimStart('.');

            var user = new ApplicationUser
            {
                UserName = "Gosho123",
                Id = "Gosho",
            };

            var dbImage = new Image
            {
                AddedByUserId = user.Id,
                Extension = extension,
            };

            var article = new Article
            {
                Id = 1,
                CreatedByUser = user,
                Name = "Pesho",
                ArticlesCategory = new ArticlesCategory
                {
                    Name = "asdjkjasld",
                    Id = 1,
                },
                Description = "asdasdAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
            };

            article.Images.Add(dbImage);
            var article2 = new Article
            {
                Id = 1,
                CreatedByUser = user,
                Name = "Gesho",
                ArticlesCategory = new ArticlesCategory
                {
                    Name = "Asdjkjasld",
                    Id = 2,
                },
                Description = "asdasdAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fAAAsdasd;lsd jls fklsd fjsklfj sdkl fjsdkl sdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjssdasd;lsd jls fklsd fjsklfj sdkl fjsdkl fjsdkj fsdklfj klsd fjsfjsdkj fsdklfj klsd fjsd",
            };
            article2.Images.Add(dbImage);
            return new List<Article>
                {
                article,
                article2,
                };
        }
    }
}
