namespace AstrologyBlog.Web.ViewModels.Videos
{
    using System.Collections.Generic;

    public class IndexVideoViewModel : PagingViewModel
    {
        public IEnumerable<VideoViewModel> Videos { get; set; }
    }
}
