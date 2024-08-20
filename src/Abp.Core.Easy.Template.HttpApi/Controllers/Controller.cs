using Abp.Core.Easy.Template.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Core.Easy.Template.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Controller : AbpControllerBase
{
    protected Controller()
    {
        LocalizationResource = typeof(Resource);
    }
}
