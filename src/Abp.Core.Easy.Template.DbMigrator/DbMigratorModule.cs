using Abp.Core.Easy.Template.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EntityFrameworkCoreModule),
    typeof(ApplicationContractsModule)
)]
public class DbMigratorModule : AbpModule
{
}
