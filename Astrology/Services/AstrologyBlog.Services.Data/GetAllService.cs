namespace AstrologyBlog.Services.Data
{
    using System.Linq;

    using AstrologyBlog.Data.Common.Repositories;
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Data.Models;

    public class GetAllService : IGetAllService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public GetAllService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public AllDto GetAll()
        {
            var data = new AllDto
            {
                Categories = this.categoriesRepository.All().ToList(),
            };

            return data;
        }
    }
}
