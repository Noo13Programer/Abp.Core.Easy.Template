using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace Abp.Core.Easy.Template.EntityFrameworkCore;

[DependsOn(
    typeof(DomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
    )]
public class EntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also IdentityDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
        
    }
}
