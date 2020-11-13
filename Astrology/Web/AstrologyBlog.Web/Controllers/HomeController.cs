namespace AstrologyBlog.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels;
    using AstrologyBlog.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetAllService allService;

        public HomeController(IGetAllService allService)
        {
            this.allService = allService;
        }

        public IActionResult Index()
        {
            var allDto = this.allService.GetAll();

            var viewModel = new IndexViewModel
            {
                Categories = allDto.Categories,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
