﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Natedpalm.Blog.Web.Endpoints.ToDoItems
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<List<ToDoItemResponse>>
    {
        private readonly IRepository _repository;

        public List(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/ToDoItems")]
        [SwaggerOperation(
            Summary = "Gets a list of all ToDoItems",
            Description = "Gets a list of all ToDoItems",
            OperationId = "ToDoItem.List",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<List<ToDoItemResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _repository.ListAsync<ToDoItem>())
                .Select(item => new ToDoItemResponse
                {
                    Id = item.Id,
                    Description = item.Description,
                    IsDone = item.IsDone,
                    Title = item.Title
                });

            return Ok(items);
        }
    }
}
