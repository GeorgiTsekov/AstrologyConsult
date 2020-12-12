namespace AstrologyBlog.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AstrologyBlog.Common;
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
            const int ItemsPerPage = 12;
            var viewModel = new IndexArticleViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Articles = this.articlesService.GetAll<ArticleViewModel>(id, ItemsPerPage),
                ArticlesCount = this.articlesService.GetCount(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.articlesService.GetById<EditArticleInputModel>(id);
            inputModel.ArticlesCategories = this.articlesCategoriesService.GetAll<CategoryDropDowwViewModel>();
            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.ArticlesCategories = this.articlesCategoriesService.GetAll<CategoryDropDowwViewModel>();
                return this.View(input);
            }

            await this.articlesService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }


        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
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

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult ById(int id)
        {
            var article = this.articlesService.GetById<SingleArticleViewModel>(id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.articlesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
