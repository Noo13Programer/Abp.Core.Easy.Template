using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abp.Core.Easy.Template.Data;
using Volo.Abp.DependencyInjection;

namespace Abp.Core.Easy.Template.EntityFrameworkCore;

public class EntityFrameworkCoreIdentityDbSchemaMigrator
    : IIdentityDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIdentityDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IdentityDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DbContext>()
            .Database
            .MigrateAsync();
    }
}
