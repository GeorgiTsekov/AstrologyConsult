namespace AstrologyBlog.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[0-9]+")]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string BirthTown { get; set; }

        public string Question { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDowwViewModel> Categories { get; set; }
    }
}
