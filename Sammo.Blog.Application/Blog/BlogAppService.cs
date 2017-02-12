using Sammo.Blog.Application.Blog.Dto;
using Sammo.Blog.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Sammo.Blog.Application.Blog
{
    public class BlogAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        public BlogAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public  IEnumerable<CategoryOutput> GetCategories()
        {
            return _categoryRepository.Find().OrderByDescending(c => c.CreatedOn).Select(
                c => new CategoryOutput
                {
                    Id = c.Id.ToString(), Name = c.Name, Description = c.Description
                }).ToList();
        }
    }
}
