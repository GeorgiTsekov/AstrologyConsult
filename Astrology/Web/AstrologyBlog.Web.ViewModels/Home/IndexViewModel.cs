namespace AstrologyBlog.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using AstrologyBlog.Data.Models;

    public class IndexViewModel
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
