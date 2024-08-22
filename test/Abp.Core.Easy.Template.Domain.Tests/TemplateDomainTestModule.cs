using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

[DependsOn(
    typeof(TemplateTestBaseModule)
)]
public class TemplateDomainTestModule : AbpModule
{

}
