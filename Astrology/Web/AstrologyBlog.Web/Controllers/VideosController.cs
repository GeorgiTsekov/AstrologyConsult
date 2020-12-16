namespace AstrologyBlog.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Common;

    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Articles;
    using AstrologyBlog.Web.ViewModels.Videos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class VideosController : Controller
    {
        private readonly IVideosService videosService;
        private readonly IArticlesCategoriesService articlesCategoriesService;

        public VideosController(
            IVideosService videosService,
            IArticlesCategoriesService articlesCategoriesService)
        {
            this.videosService = videosService;
            this.articlesCategoriesService = articlesCategoriesService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var articleCategories = this.articlesCategoriesService.GetAll<ArticlesCategoryDropDowwViewModel>();
            var viewModel = new CreateVideoInputModel
            {
                ArticlesCategories = articleCategories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateVideoInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.videosService.CreateAsync(input);
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(int id = 1)
        {
            var viewModel = new IndexVideoViewModel
            {
                ItemsPerPage = GlobalConstants.ItemsPerPage,
                PageNumber = id,
                Videos = this.videosService.GetAll<VideoViewModel>(id, GlobalConstants.ItemsPerPage),
                ItemsCount = this.videosService.GetCount(),
            };
            return this.View(viewModel);
        }
    }
}
