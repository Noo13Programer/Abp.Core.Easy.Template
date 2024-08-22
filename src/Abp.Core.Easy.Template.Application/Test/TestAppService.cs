using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Abp.Core.Easy.Template.Test
{
    [RemoteService(IsEnabled =  false)]
    public class TestAppService : TemplateAppService, ITestAppService
    {
        public async Task<string> Test(int id)
        {
            return "成功";
        }
    }
}
