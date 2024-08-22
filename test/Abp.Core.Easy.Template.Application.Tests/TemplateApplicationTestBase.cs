using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

public abstract class TemplateApplicationTestBase<TStartupModule> : TemplateTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
