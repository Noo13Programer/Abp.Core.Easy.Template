using Abp.Core.Easy.Template.Samples;
using Xunit;

namespace Abp.Core.Easy.Template.EntityFrameworkCore.Domains;

[Collection(TemplateTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TemplateEntityFrameworkCoreTestModule>
{

}
