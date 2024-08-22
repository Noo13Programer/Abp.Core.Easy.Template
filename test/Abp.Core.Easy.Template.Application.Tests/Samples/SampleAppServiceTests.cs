﻿using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Abp.Core.Easy.Template.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public abstract class SampleAppServiceTests<TStartupModule> : TemplateApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

   

    [Fact]
    public async Task Initial_Data_Should_Contain_Admin_User()
    {
       
    }
}
