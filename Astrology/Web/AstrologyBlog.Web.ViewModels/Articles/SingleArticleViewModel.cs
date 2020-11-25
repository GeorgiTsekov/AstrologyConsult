namespace AstrologyBlog.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
    using AutoMapper;

    public class SingleArticleViewModel : IMapFrom<Article>, IMapTo<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedByUserUserName { get; set; }

        public string ArticlesCategoryName { get; set; }

        public string ImageUrl { get; set; }

        public int VotesCount { get; set; }

        public ICollection<CommentInArticleViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, SingleArticleViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/articles/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
