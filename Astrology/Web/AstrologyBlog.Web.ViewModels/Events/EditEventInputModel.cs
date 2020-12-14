namespace AstrologyBlog.Web.ViewModels.Events
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class EditEventInputModel : BaseEventInputModel, IMapFrom<Event>
    {
        public int Id { get; set; }
    }
}
