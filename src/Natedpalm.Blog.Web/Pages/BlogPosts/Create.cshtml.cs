using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.Blog.Web.ApiModels;
using Natedpalm.SharedKernel.Interfaces;

namespace Natedpalm.Blog.Web.Pages.BlogPosts
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public BlogPostDTO BlogPost { get; set; }
        public CreateModel(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var blogPost = _mapper.Map<BlogPost>(BlogPost);
            await _repository.AddAsync<BlogPost>(blogPost);
            return RedirectToPage("./");
        }
    }
}