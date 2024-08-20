using Abp.Core.Easy.Template.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Core.Easy.Template;

/* Inherit your application services from this class.
 */
public abstract class AppService : ApplicationService
{
    protected AppService()
    {
        LocalizationResource = typeof(Resource);
    }
}
