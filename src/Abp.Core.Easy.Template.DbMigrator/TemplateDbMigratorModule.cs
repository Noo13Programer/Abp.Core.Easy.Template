using Abp.Core.Easy.Template.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TemplateEntityFrameworkCoreModule),
    typeof(TemplateApplicationContractsModule)
)]
public class TemplateDbMigratorModule : AbpModule
{
}
