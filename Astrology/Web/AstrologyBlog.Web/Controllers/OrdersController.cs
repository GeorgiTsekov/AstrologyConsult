namespace AstrologyBlog.Web.Controllers
{
    using System.Text;
    using System.Threading.Tasks;

    using AstrologyBlog.Common;
    using AstrologyBlog.Services.Data;
    using AstrologyBlog.Services.Messaging;
    using AstrologyBlog.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SendGrid;

    public class OrdersController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IOrdersService ordersService;
        private readonly IEmailSender emailSender;

        public OrdersController(
            ICategoriesService categoriesService,
            IOrdersService ordersService,
            IEmailSender emailSender)
        {
            this.categoriesService = categoriesService;
            this.ordersService = ordersService;
            this.emailSender = emailSender;
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

            var htmlUser = new StringBuilder();
            htmlUser.AppendLine($"<h1>Здравейте {input.Name} {input.Surname}!</h1>");
            htmlUser.AppendLine($"<h1>Вие си поръчахте хороскоп</h1>");
            htmlUser.AppendLine($"<h1>Ще се свържем с вас на телефон {input.Phone} и на имейл {input.Email} за повече информация</h1>");
            await this.emailSender.SendEmailAsync(
                GlobalConstants.SystemEmail,
                GlobalConstants.SystemName,
                input.Email,
                input.Name,
                htmlUser.ToString());

            var htmlAdmin = new StringBuilder();
            htmlAdmin.AppendLine($"<h1>Клиент {input.Name} {input.Surname} ви поръча хороскоп!</h1>");
            htmlAdmin.AppendLine($"<h1>телефон {input.Phone} имейл {input.Email}</h1>");
            await this.emailSender.SendEmailAsync(
                GlobalConstants.SystemEmail,
                GlobalConstants.SystemName,
                GlobalConstants.SystemEmail,
                GlobalConstants.SystemName,
                htmlAdmin.ToString());
            return this.RedirectToAction("ThankYou");
        }

        // [HttpPost]
        //  public async Task<IActionResult> Create(CreateOrderInputModel input)
        //  {
        //      if (!this.ModelState.IsValid)
        //      {
        //          return this.View(input);
        //      }
        //      var id = await this.ordersService.CreateAsync(input);
        //      return this.RedirectToAction(nameof(this.Details), new { id });
        //  }
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
            var order = this.ordersService.GetById<OrderViewModel>(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.View(order);
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        // [HttpPost]
        // public async Task<IActionResult> SendToEmail(int id)
        // {
        //    var order = this.ordersService.GetById<OrderViewModel>(id);
        //    var html = new StringBuilder();
        //    html.AppendLine($"<h1>Здравейте {order.Name} {order.Surname}!</h1>");
        //    html.AppendLine($"<h1>Вие си поръчахте хороскоп</h1>");
        //    html.AppendLine($"<h1>Ще се свържем с вас на {order.Phone} и на имейл {order.Email} за повече информация</h1>");
        //    await this.emailSender.SendEmailAsync("JelanieZaNovJivot.com", "AstrologyBlog", "becosa4476@febeks.com", order.Name, html.ToString());
        //    return this.Redirect("/");
        // }
    }
}
