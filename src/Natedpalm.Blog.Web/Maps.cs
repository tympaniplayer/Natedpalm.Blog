using AutoMapper;
using Natedpalm.Blog.Core.Entities;
using Natedpalm.Blog.Web.ApiModels;

namespace Natedpalm.Blog.Web
{
    public class Map : Profile 
    {
       public Map()
       {
           CreateMap<BlogPost, BlogPostDTO>(); 
       }
    }
}