using Abp.Core.Easy.Template.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Core.Easy.Template.Web.Pages;

public abstract class TemplatePageModel : AbpPageModel
{
    protected TemplatePageModel()
    {
        LocalizationResourceType = typeof(TemplateResource);
    }
}
