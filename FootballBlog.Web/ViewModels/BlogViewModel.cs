using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballBlog.Web.ViewModels
{
    public class BlogViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maximum numbers of characters are 100")]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [StringLength(maximumLength: 2000, ErrorMessage = "Maximum numbers of characters are 2000")]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
        public bool Published { get; set; }
    }
}
