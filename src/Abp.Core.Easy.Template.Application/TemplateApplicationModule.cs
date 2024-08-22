
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(TemplateDomainModule),
    typeof(TemplateApplicationContractsModule)
    )]
public class TemplateApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TemplateApplicationModule>();
        });
    }
}
