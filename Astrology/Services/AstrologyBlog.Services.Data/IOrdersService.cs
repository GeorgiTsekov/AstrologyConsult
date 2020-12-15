namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<int> CreateAsync(CreateOrderInputModel input);

        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);
    }
}
