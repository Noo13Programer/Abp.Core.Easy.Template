
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(DomainModule),
    typeof(ApplicationContractsModule)
    )]
public class ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApplicationModule>();
        });
    }
}
