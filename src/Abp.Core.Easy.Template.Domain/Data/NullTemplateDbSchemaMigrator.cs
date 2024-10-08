﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.Core.Easy.Template.Data;

/* This is used if database provider does't define
 * ITemplateDbSchemaMigrator implementation.
 */
public class NullTemplateDbSchemaMigrator : ITemplateDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
