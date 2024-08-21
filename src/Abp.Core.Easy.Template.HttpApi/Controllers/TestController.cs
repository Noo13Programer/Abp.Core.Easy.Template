using Abp.Core.Easy.Template.Test;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Abp.Core.Easy.Template.Controllers
{
    [RemoteService]
    [Route("api/tets")]
    public class TestController:Controller,ITestAppService
    {
        private readonly ITestAppService _testAppService;

        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }


        [HttpGet]
        public async Task<string> Test()
        {
            return await _testAppService.Test();
        }
    }
}
