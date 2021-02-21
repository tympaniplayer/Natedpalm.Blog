using Natedpalm.Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Natedpalm.Blog.Infrastructure.Data.Config
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired();
        }
    }
}
