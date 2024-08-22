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
   [Route("api/test")]
    public class TestController:TemplateController,ITestAppService
    {
        private readonly ITestAppService _testAppService;

       
        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<string> Test(int id)
        {
            return _testAppService.Test(id);
        }
    }
}
