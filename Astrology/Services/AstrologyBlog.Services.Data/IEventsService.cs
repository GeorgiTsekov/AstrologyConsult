namespace AstrologyBlog.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AstrologyBlog.Web.ViewModels.Events;

    public interface IEventsService
    {
        Task CreateAsync(CreateEventInputModel input);

        IEnumerable<T> GetAll<T>(int? count = null);

        //int GetCount();

        //Task UpdateAsync(int id, EditEventInputModel input);

        //Task DeleteAsync(int id);
    }
}
