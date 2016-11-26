using Sammo.Blog.Domain;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Sammo.Blog.Repository.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SammoDbContext _sammoDbContext;
        private readonly IDbTransaction _transaction;
        private readonly ObjectContext _objectContext;

        public UnitOfWork(SammoDbContext sammoDbContext)
        {
            _sammoDbContext = sammoDbContext;

            _objectContext = ((IObjectContextAdapter)_sammoDbContext).ObjectContext;
            if(_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
                _transaction = _objectContext.Connection.BeginTransaction();
            }

        }
        public void Commit()
        {
            _sammoDbContext.SaveChanges();
            _transaction.Commit();
        }

        public void Dispose()
        {
            if (_objectContext.Connection.State == ConnectionState.Open)
            {
                _objectContext.Connection.Close();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public Task SaveChangesAsync()
        {
            return _sammoDbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _sammoDbContext.SaveChanges();
        }
    }
}
