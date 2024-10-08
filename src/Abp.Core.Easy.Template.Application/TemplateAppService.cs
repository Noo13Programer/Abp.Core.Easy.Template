﻿using Abp.Core.Easy.Template.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Core.Easy.Template;

/* Inherit your application services from this class.
 */
public abstract class TemplateAppService : ApplicationService
{
    protected TemplateAppService()
    {
        LocalizationResource = typeof(TemplateResource);
    }
}
