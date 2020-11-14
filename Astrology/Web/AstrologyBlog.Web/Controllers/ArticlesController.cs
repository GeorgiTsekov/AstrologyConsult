namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc;

    public class ArticlesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;

        public ArticlesController(
            ICategoriesService categoriesService,
            IArticlesService articlesService)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
        }

        public IActionResult All()
        {
            var viewModel = new IndexArticleViewModel
            {
                Articles = this.articlesService.GetAll<ArticleViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateArticleInputModel
            {
                CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.articlesService.CreateAsync(input);

            // TODO Redirect to article info page
            return this.Redirect("/");
        }
    }
}
