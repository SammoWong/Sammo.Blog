using Autofac;
using Autofac.Integration.Mvc;
using Sammo.Blog.Application.Account;
using Sammo.Blog.Domain;
using Sammo.Blog.Domain.DomainService;
using Sammo.Blog.Domain.Repositories;
using Sammo.Blog.Repository.EntityFramework;
using Sammo.Blog.Repository.EntityFramework.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Sammo.Blog.Web
{
    public class IoCConfig
    {
        private static IContainer _container;

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(SammoDbContext)).As(typeof(SammoDbContext)).InstancePerLifetimeScope();
            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork));

            //注册Repository
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UserRepository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .As(type => type.GetInterfaces().Single(i => !i.IsGenericType));

            //注册ApplicationService
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AccountAppService)));

            //注册领域服务
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly)
                .Where(a=>a.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();           

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        /// <summary>
        /// 从容器中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Get<T>()
        {
            return _container.Resolve<T>();
            //return (T)DependencyResolver.Current.GetService(typeof(T));
        }
    }
}