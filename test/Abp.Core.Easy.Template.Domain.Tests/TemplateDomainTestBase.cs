﻿using Volo.Abp.Modularity;

namespace Abp.Core.Easy.Template;

/* Inherit from this class for your domain layer tests. */
public abstract class TemplateDomainTestBase<TStartupModule> : TemplateTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
