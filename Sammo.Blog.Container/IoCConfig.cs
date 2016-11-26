using Autofac;
using Sammo.Blog.Domain;
using Sammo.Blog.Domain.Repositories;
using Sammo.Blog.Repository.EntityFramework;
using Sammo.Blog.Repository.EntityFramework.Repositories;

namespace Sammo.Blog.Container
{
    public class IoCConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));
        }
    }
}
