using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Core.Easy.Template.Web;

[Dependency(ReplaceServices = true)]
public class TemplateBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Template";
}
