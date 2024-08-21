using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Abp.Core.Easy.Template.Test
{
    [RemoteService(IsEnabled =false)]
    public class TestAppService : AppService,ITestAppService
    {
        public async Task<string> Test()
        {
            return "测试成功";
        }
    }
}
