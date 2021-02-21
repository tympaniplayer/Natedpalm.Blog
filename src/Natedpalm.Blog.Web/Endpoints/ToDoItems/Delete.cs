using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Natedpalm.Blog.Web.Endpoints.ToDoItems
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<int>
        .WithoutResponse
    {
        private readonly IRepository _repository;

        public Delete(IRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("/ToDoItems/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a ToDoItem",
            Description = "Deletes a ToDoItem",
            OperationId = "ToDoItem.Delete",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(int id, CancellationToken cancellationToken)
        {
            var itemToDelete = await _repository.GetByIdAsync<ToDoItem>(id);
            if (itemToDelete == null) return NotFound();

            await _repository.DeleteAsync<ToDoItem>(itemToDelete);

            return NoContent();
        }
    }
}
