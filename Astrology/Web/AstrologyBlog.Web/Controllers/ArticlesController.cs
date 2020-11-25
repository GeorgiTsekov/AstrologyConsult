namespace AstrologyBlog.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly IArticlesCategoriesService articlesCategoriesService;
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public ArticlesController(
            IArticlesCategoriesService articlesCategoriesService,
            IArticlesService articlesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.articlesCategoriesService = articlesCategoriesService;
            this.articlesService = articlesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 10;
            var viewModel = new IndexArticleViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Articles = this.articlesService.GetAll<ArticleViewModel>(id, ItemsPerPage),
                ArticlesCount = this.articlesService.GetCount(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var articleCategories = this.articlesCategoriesService.GetAll<CategoryDropDowwViewModel>();
            var viewModel = new CreateArticleInputModel
            {
                ArticlesCategories = articleCategories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.articlesService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            // var articleId = await this.articlesService.CreateAsync(input.Name, input.Description, input.ImageUrl, input.ArticlesCategoryId, user.Id);
            // return this.RedirectToAction("ById", new { id = articleId });
            return this.Redirect("/");
        }

        public IActionResult ById(int id)
        {
            var article = this.articlesService.GetById<SingleArticleViewModel>(id);

            return this.View(article);
        }
    }
}
