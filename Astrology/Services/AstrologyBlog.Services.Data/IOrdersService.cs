namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<int> CreateAsync(CreateOrderInputModel input);
    }
}
