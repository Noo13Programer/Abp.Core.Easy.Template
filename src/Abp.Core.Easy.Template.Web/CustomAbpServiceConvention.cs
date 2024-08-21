using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Controllers;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Reflection;

namespace Abp.Core.Easy.Template
{
    public class CustomAbpServiceConvention : AbpServiceConvention
    {
        public CustomAbpServiceConvention(IOptions<AbpAspNetCoreMvcOptions> options, IConventionalRouteBuilder conventionalRouteBuilder) : base(options, conventionalRouteBuilder)
        {
        }

        protected override void ConfigureSelector(ControllerModel controller, ConventionalControllerSetting? configuration)
        {
            //没有route属性直接过滤
            RemoveEmptySelectors(controller.Selectors);

            var controllerType = controller.ControllerType.AsType();
            //通过反射拿到标注RemoteService的控制器
            var remoteServiceAtt = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(controllerType.GetTypeInfo());
            //存在并且关闭远程服务
            if (remoteServiceAtt != null && !remoteServiceAtt.IsEnabledFor(controllerType))
            {
                return;
            }
            //存在有route标注的控制器
            if (controller.Selectors.Any(selector => selector.AttributeRouteModel != null))
            {
                return;
            }

            //获取根路径 app/控制器名 or app/配置根路径
            var rootPath = GetRootPathOrDefault(controller.ControllerType.AsType());

            //重命名控制器名称
            string controllerName = ReflectionHelper.GetSingleAttributeOrDefault<Microsoft.AspNetCore.Mvc.RouteAttribute>(controllerType.GetTypeInfo())!=null?  ReflectionHelper.GetSingleAttributeOrDefault<RouteAttribute>(controllerType.GetTypeInfo()).Template: controller.ControllerName;

            foreach (var action in controller.Actions)
            {
                ConfigureSelector(rootPath, controller.ControllerName, action, configuration);
            }
        }
    }
}
