using System;

namespace Sammo.Blog.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void SaveChanges();
    }
}
