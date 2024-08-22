using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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
            /*//存在有route标注的控制器
            if (controller.Selectors.Any(selector => selector.AttributeRouteModel != null))
            {
                return;
            }*/

            //获取根路径 app/控制器名 or app/配置根路径
            var rootPath = GetRootPathOrDefault(controller.ControllerType.AsType());

            //重命名控制器名称
            string controllerName = ReflectionHelper.GetSingleAttributeOrDefault<Microsoft.AspNetCore.Mvc.RouteAttribute>(controllerType.GetTypeInfo())!=null?  ReflectionHelper.GetSingleAttributeOrDefault<RouteAttribute>(controllerType.GetTypeInfo()).Template: controller.ControllerName;

            foreach (var action in controller.Actions)
            {
                ConfigureSelector(rootPath, controllerName, action, configuration);
            }
        }

        protected override void ConfigureSelector(string rootPath, string controllerName, ActionModel action, ConventionalControllerSetting? configuration)
        {
            //过滤没打route的方法
            RemoveEmptySelectors(action.Selectors);
            //反射拿到所有标注RemoteService的方法名
            var remoteServiceAtt = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(action.ActionMethod);
            //存在且关闭状态
            if (remoteServiceAtt != null && !remoteServiceAtt.IsEnabledFor(action.ActionMethod))
            {
                return;
            }

            //规范路由命名
            NormalizeSelectorRoutes(rootPath, controllerName, action, configuration);
        }

        protected override void NormalizeSelectorRoutes(string rootPath, string controllerName, ActionModel action, ConventionalControllerSetting? configuration)
        {
            foreach (var selector in action.Selectors)
            {
                //拿到请求类型
                var httpMethod = selector.ActionConstraints
                    .OfType<HttpMethodActionConstraint>()
                    .FirstOrDefault()?
                    .HttpMethods?
                    .FirstOrDefault();

                //没写默认约束
                if (httpMethod == null)
                {
                    httpMethod = SelectHttpMethod(action, configuration);
                }

                //规范route
                selector.AttributeRouteModel = CreateAbpServiceAttributeRouteModel(rootPath, controllerName, action, httpMethod, configuration);
                

                if (!selector.ActionConstraints.OfType<HttpMethodActionConstraint>().Any())
                {
                    selector.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { httpMethod }));
                }
            }
        }


    }
}
