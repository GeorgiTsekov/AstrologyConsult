namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly IArticlesCategoriesService articlesCategoriesService;
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(
            IArticlesCategoriesService articlesCategoriesService,
            IArticlesService articlesService,
            UserManager<ApplicationUser> userManager)
        {
            this.articlesCategoriesService = articlesCategoriesService;
            this.articlesService = articlesService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new IndexArticleViewModel
            {
                Articles = this.articlesService.GetAll<ArticleViewModel>(),
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
            var articleId = await this.articlesService.CreateAsync(input.Name, input.Description, input.ImageUrl, input.ArticlesCategoryId, user.Id);

            return this.RedirectToAction("ById", new { id = articleId });
        }
    }
}
