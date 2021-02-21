﻿using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Natedpalm.Blog.Web.Endpoints.ToDoItems
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateToDoItemRequest>
        .WithResponse<ToDoItemResponse>
    {
        private readonly IRepository _repository;

        public Update(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("/ToDoItems")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "ToDoItem.Update",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ToDoItemResponse>> HandleAsync(UpdateToDoItemRequest request, CancellationToken cancellationToken)
        {
            var existingItem = await _repository.GetByIdAsync<ToDoItem>(request.Id);

            existingItem.Title = request.Title;
            existingItem.Description = request.Description;

            await _repository.UpdateAsync(existingItem);

            var response = new ToDoItemResponse
            {
                Id = existingItem.Id,
                Title = existingItem.Title,
                Description = existingItem.Description,
                IsDone = existingItem.IsDone
            };
            return Ok(response);
        }
    }
}