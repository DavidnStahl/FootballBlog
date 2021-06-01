using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballBlog.Models.Data
{
    public class Blog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Category { get; set; }
        [Required]
        [StringLength(maximumLength: 2000)]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
        public bool Published { get; set; }
    }
}
