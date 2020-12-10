namespace AstrologyBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
