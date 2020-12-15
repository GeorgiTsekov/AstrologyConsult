namespace AstrologyBlog.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class IndexOrderViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
