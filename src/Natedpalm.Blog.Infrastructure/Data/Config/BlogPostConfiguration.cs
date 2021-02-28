using Natedpalm.Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Natedpalm.Blog.Infrastructure.Data.Config
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
            builder.Property(t => t.PublishDate)
                .IsRequired();
        }
    }
}