using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using XGame.Domain.Services;
using XGame.Infra.Persistence;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Infra.Persistence.Repositories.Base;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories;
using XGame.Infra.Transactions;

namespace XGame.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, XGame.Infra.Transactions.UnityOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());
            //container.RegisterType<IServiceJogo, ServiceJogo>(new HierarchicalLifetimeManager());



            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());
            //container.RegisterType<IRepositoryJogo, RepositoryJogo>(new HierarchicalLifetimeManager());



        }
    }
}
