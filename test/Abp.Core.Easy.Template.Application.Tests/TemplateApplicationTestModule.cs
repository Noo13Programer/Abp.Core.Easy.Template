using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(TemplateApplicationModule),
    typeof(TemplateDomainTestModule)
)]
public class TemplateApplicationTestModule : AbpModule
{

}
