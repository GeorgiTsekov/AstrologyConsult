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
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(
            ICategoriesService categoriesService,
            IArticlesService articlesService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
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
            var categories = this.categoriesService.GetAll<CategoryDropDowwViewModel>();
            var viewModel = new CreateArticleInputModel
            {
                Categories = categories,
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
            var articleId = await this.articlesService.CreateAsync(input.Name, input.Description, input.ImageUrl, input.CategoryId, user.Id);

            return this.RedirectToAction("ById", new { id = articleId });
        }
    }
}
