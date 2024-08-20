
using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(DomainSharedModule)
)]
public class ApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DtoExtensions.Configure();
    }
}
