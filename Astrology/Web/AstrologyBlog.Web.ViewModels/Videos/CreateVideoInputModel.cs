using System.ComponentModel.DataAnnotations;

namespace AstrologyBlog.Web.ViewModels.Videos
{
    public class CreateVideoInputModel : BaseVideoInputModel
    {
        [Required]
        public string VideoUrl { get; set; }
    }
}
