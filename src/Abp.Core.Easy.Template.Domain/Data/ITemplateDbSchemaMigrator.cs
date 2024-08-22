using System.Threading.Tasks;

namespace Abp.Core.Easy.Template.Data;

public interface ITemplateDbSchemaMigrator
{
    Task MigrateAsync();
}
