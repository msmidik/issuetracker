using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Data.Entity;
using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace BL
{
    public class Installer : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<Func<DbContext>>()
                    .Instance(() => new AppDbContext())
                    .LifestyleTransient(),

                Component.For<IAppUnitOfWorkProvider, IUnitOfWorkProvider>()
                    .ImplementedBy<AppUnitOfWorkProvider>()
                    .LifestyleSingleton(),

                Component.For<IUnitOfWorkRegistry>()
                    .Instance(new HttpContextUnitOfWorkRegistry(new ThreadLocalUnitOfWorkRegistry()))
                    .LifestyleSingleton(),

                Component.For<IUserStore<AppUser, int>>()
                    .ImplementedBy<AppUserStore>()
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(AppQuery<>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppUnitOfWork>()
                    .BasedOn(typeof(IRepository<,>))
                    .LifestyleTransient(),

                Component.For(typeof(IRepository<,>))
                    .ImplementedBy(typeof(EntityFrameworkRepository<,>))
                    .LifestyleTransient(),

                Classes.FromAssemblyContaining<AppFacadeBase>()
                    .BasedOn<AppFacadeBase>()
                    .LifestyleTransient(),


                Component.For<Func<AppUserManager>>()
                    .Instance(() => new AppUserManager(new AppUserStore(new AppDbContext())))
                    .LifestyleTransient()

            );

            Mapping.Create();
        }
    }
}
