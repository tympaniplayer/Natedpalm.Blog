using Natedpalm.Blog.Core.Entities;
using Natedpalm.SharedKernel;

namespace Natedpalm.Blog.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}