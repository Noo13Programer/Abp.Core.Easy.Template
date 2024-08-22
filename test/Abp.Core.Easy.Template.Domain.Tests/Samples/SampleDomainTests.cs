using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace Abp.Core.Easy.Template.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IdentityUserManager here).
 * Only test your own domain services.
 */
public abstract class SampleDomainTests<TStartupModule> : TemplateDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{



    [Fact]
    public async Task Should_Set_Email_Of_A_User()
    {


        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
       
    }
}
