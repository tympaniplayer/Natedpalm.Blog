using System;
using Natedpalm.SharedKernel;
using Natedpalm.SharedKernel.Interfaces;

namespace Natedpalm.Blog.Core.Entities
{
    public class BlogPost : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }

        public string PostContent {get; set;}
    }
}