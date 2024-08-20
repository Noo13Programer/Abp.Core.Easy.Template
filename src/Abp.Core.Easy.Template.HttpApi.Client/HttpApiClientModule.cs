using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;


namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(ApplicationContractsModule)
)]
public class HttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Default";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ApplicationContractsModule).Assembly,
            RemoteServiceName
        );

      
    }
}
