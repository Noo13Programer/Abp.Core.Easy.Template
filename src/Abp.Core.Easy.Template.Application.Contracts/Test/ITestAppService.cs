using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.Core.Easy.Template.Test
{
    public interface ITestAppService:IApplicationService
    {
        Task<string> Test();
    }
}
