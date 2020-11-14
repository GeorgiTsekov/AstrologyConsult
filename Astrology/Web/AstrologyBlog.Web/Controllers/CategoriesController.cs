namespace AstrologyBlog.Web.Controllers
{
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly IGetAllCategoriesService getAllCategoriesService;

        public CategoriesController(IGetAllCategoriesService getAllCategoriesService)
        {
            this.getAllCategoriesService = getAllCategoriesService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.getAllCategoriesService.GetByName<CategoryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
