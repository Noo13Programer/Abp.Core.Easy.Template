using Abp.Core.Easy.Template.Localization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Core.Easy.Template.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TemplateController : AbpControllerBase
{
    protected TemplateController()
    {
        LocalizationResource = typeof(TemplateResource);
    }
}
