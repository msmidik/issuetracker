using DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;
using System;
using System.Data.Entity;

namespace BL
{
    public class AppUnitOfWork : EntityFrameworkUnitOfWork
    {
        public new AppDbContext Context => (AppDbContext)base.Context;

        public AppUnitOfWork(IUnitOfWorkProvider provider, Func<DbContext> dbContextFactory, DbContextOptions options) : base(provider, dbContextFactory, options)
        {
        }
    }
}
