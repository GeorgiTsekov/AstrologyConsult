namespace AstrologyBlog.Services.Data
{
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Web.ViewModels.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task<int> CreateAsync(CreateOrderInputModel input)
        {
            var order = new Order
            {
                Name = input.Name,
                Surname = input.Surname,
                Email = input.Email,
                Phone = input.Phone,
                BirthDay = input.BirthDay,
                BirthTown = input.BirthTown,
                Question = input.Question,
                CategoryId = input.CategoryId,
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();
            return order.Id;
        }
    }
}
