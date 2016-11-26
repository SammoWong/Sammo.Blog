using Sammo.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sammo.Blog.Domain.Repositories
{
    public interface IRepository<T> where T: EntityBase
    {

    }
}
