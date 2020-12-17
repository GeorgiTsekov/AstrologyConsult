namespace AstrologyBlog.Web.ViewModels.Videos
{
    using AstrologyBlog.Data.Models;
    using AstrologyBlog.Services.Mapping;

    public class EditVideoInputModel : BaseVideoInputModel, IMapFrom<Video>
    {
        public int Id { get; set; }
    }
}
