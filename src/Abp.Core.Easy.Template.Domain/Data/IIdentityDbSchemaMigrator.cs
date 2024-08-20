using System.Threading.Tasks;

namespace Abp.Core.Easy.Template.Data;

public interface IIdentityDbSchemaMigrator
{
    Task MigrateAsync();
}
