using Abp.Core.Easy.Template.Samples;
using Xunit;

namespace Abp.Core.Easy.Template.EntityFrameworkCore.Applications;

[Collection(TemplateTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TemplateEntityFrameworkCoreTestModule>
{

}
