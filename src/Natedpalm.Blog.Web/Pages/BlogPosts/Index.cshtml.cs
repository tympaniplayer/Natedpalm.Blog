using System.Collections.Generic;
using Natedpalm.SharedKernel.Interfaces;
using Natedpalm.Blog.Core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Natedpalm.Blog.Web.Pages.BlogPosts
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public List<BlogPost> BlogPosts { get; set; }

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            BlogPosts = await _repository.ListAsync<BlogPost>();
        }
    }
}