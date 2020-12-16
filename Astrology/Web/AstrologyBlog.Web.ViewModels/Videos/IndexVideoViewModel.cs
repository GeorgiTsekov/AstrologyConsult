using System;
using System.Collections.Generic;
using System.Text;

namespace AstrologyBlog.Web.ViewModels.Videos
{
    public class IndexVideoViewModel : PagingViewModel
    {
        public IEnumerable<VideoViewModel> Videos { get; set; }
    }
}
