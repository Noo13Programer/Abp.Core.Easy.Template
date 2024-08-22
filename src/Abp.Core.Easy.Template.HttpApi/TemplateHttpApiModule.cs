using Localization.Resources.AbpUi;
using Abp.Core.Easy.Template.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;

namespace Abp.Core.Easy.Template;

 [DependsOn(
    typeof(TemplateApplicationContractsModule)
    )]
public class TemplateHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TemplateResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
