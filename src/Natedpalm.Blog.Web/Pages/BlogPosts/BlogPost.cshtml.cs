using System.Threading.Tasks;
using MarkdownSharp;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.SharedKernel.Interfaces;

namespace Natedpalm.Blog.Web.Pages.BlogPosts
{
    public class BlogPostModel : PageModel
    {
        private IRepository _repository;
        private Markdown _markDownRenderer;
        public BlogPost BlogPost { get; set; }
        public string RawHtml { get; set; }

        public BlogPostModel(IRepository repository)
        {
            _repository = repository;
            _markDownRenderer = new Markdown();
        }

        public async Task OnGetAsync(int id)
        {
            BlogPost = await _repository.GetByIdAsync<BlogPost>(id);
            RawHtml = _markDownRenderer.Transform(BlogPost.PostContent);
        }
    }
}