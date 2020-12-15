namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;
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

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Order> orders = this.ordersRepository.All().OrderByDescending(x => x.CreatedOn);
            if (count.HasValue)
            {
                orders = orders.Take(count.Value);
            }

            return orders.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var order = this.ordersRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return order;
        }
    }
}
