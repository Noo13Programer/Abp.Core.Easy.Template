
using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(TemplateDomainSharedModule)
)]
public class TemplateApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        TemplateDtoExtensions.Configure();
    }
}
