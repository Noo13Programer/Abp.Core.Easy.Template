using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Abp.Core.Easy.Template.Pages;

[Collection(TemplateTestConsts.CollectionDefinitionName)]
public class Index_Tests : TemplateWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
