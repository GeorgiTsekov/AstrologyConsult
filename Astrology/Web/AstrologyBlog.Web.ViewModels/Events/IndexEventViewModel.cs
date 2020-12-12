namespace AstrologyBlog.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class IndexEventViewModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
