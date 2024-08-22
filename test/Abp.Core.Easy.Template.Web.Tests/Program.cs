using Microsoft.AspNetCore.Builder;
using Abp.Core.Easy.Template;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<TemplateWebTestModule>();

public partial class Program
{
}
