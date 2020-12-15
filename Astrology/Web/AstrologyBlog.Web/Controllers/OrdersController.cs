namespace AstrologyBlog.Web.Controllers
{
    using System.Threading.Tasks;

    using AstrologyBlog.Common;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IOrdersService ordersService;

        public OrdersController(
            ICategoriesService categoriesService,
            IOrdersService ordersService)
        {
            this.categoriesService = categoriesService;
            this.ordersService = ordersService;
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDowwViewModel>();
            var viewModel = new CreateOrderInputModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ordersService.CreateAsync(input);

            return this.Redirect("/");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult All()
        {
            var viewModel = new IndexOrderViewModel
            {
                Orders = this.ordersService.GetAll<OrderViewModel>(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Details(int id)
        {
            var eventView = this.ordersService.GetById<OrderViewModel>(id);
            if (eventView == null)
            {
                return this.NotFound();
            }

            return this.View(eventView);
        }
    }
}
