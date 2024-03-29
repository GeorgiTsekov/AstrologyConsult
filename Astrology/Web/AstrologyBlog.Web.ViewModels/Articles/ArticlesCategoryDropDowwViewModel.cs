﻿namespace AstrologyBlog.Web.ViewModels.Articles
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class ArticlesCategoryDropDowwViewModel : IMapFrom<ArticlesCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
