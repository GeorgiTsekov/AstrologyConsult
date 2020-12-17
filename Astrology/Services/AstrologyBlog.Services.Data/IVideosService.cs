namespace AstrologyBlog.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Videos;

    public interface IVideosService
    {
        Task<int> CreateAsync(CreateVideoInputModel input);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditVideoInputModel input);

        Task DeleteAsync(int id);
    }
}
