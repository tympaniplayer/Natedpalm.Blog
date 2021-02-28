using System;
using System.ComponentModel.DataAnnotations;

namespace Natedpalm.Blog.Web.ApiModels
{
    public class BlogPostDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string PostContent { get; set; }
    }
}
