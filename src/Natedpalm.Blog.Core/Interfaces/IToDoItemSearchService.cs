using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using Natedpalm.Blog.Core.Entities;

namespace Natedpalm.Blog.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync();
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(string searchString);
    }
}
