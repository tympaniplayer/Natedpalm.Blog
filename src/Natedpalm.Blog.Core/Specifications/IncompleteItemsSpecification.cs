using Ardalis.Specification;
using Natedpalm.Blog.Core.Entities;

namespace Natedpalm.Blog.Core.Specifications
{
    public class IncompleteItemsSpecification : Specification<ToDoItem>
    {
        public IncompleteItemsSpecification()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}
