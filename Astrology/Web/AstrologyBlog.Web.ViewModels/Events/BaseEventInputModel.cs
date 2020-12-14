namespace AstrologyBlog.Web.ViewModels.Events
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEventInputModel
    {
        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [MinLength(4)]
        public string Place { get; set; }

        [Required]
        [MinLength(100)]
        public string Description { get; set; }
    }
}
