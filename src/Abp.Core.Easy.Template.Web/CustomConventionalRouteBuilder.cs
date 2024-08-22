using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.Reflection;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abp.Core.Easy.Template
{
    public class CustomConventionalRouteBuilder : ConventionalRouteBuilder
    {
        public CustomConventionalRouteBuilder(IOptions<AbpConventionalControllerOptions> options) : base(options)
        {
        }

        public override string Build(string rootPath,
        string controllerName,
        ActionModel action,
        string httpMethod,
        ConventionalControllerSetting? configuration)
        {
            //apiroute前缀 一般是"api"
            var apiRoutePrefix = GetApiRoutePrefix(action, configuration);
            //控制器前缀 还是控制器名称
            var controllerNameInUrl =
                NormalizeUrlControllerName(rootPath, controllerName, action, httpMethod, configuration);

            var url = $"/{apiRoutePrefix}/{NormalizeControllerNameCase(controllerNameInUrl, configuration)}";

            /*//Add {id} path if needed
            //占位符添加
            var idParameterModel = action.Parameters.FirstOrDefault(p => p.ParameterName == "id");
            if (idParameterModel != null)
            {
                if (TypeHelper.IsPrimitiveExtended(idParameterModel.ParameterType, includeEnums: true))
                {
                    url += "/{id}";
                }
                else
                {
                    var properties = idParameterModel
                        .ParameterType
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public);

                    foreach (var property in properties)
                    {
                        url += "/{" + NormalizeIdPropertyNameCase(property, configuration) + "}";
                    }
                }
            }*/

            //Add action name if needed

            var actionNameInUrl = NormalizeUrlActionName(rootPath, controllerName, action, httpMethod, configuration);
            if (!actionNameInUrl.IsNullOrEmpty())
            {
                url += $"/{NormalizeActionNameCase(actionNameInUrl, configuration)}";

                //Add secondary Id
                var secondaryIds = action.Parameters
                    .Where(p => p.ParameterName.EndsWith("Id", StringComparison.Ordinal)).ToList();
                if (secondaryIds.Count == 1)
                {
                    url += $"/{{{NormalizeSecondaryIdNameCase(secondaryIds[0], configuration)}}}";
                }
            }

            return url;
        }

        protected override string GetApiRoutePrefix(ActionModel actionModel, ConventionalControllerSetting? configuration)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configurationRoot = config.Build();
            var apiPrefix = configurationRoot["App:ApiPrefix"];
            if (string.IsNullOrWhiteSpace(apiPrefix))
            {
                apiPrefix = AbpAspNetCoreConsts.DefaultApiPrefix;
            }
            return apiPrefix;
        }

        protected override string NormalizeUrlActionName(string rootPath, string controllerName, ActionModel action,
        string httpMethod, ConventionalControllerSetting? configuration)
        {
            string actionNameInUrl = null;
            //没额外配置则直接返回
            if (configuration?.UrlActionNameNormalizer == null)
            {
                // 获取路由属性
                var routeAtt = action.ActionMethod.GetCustomAttributes(typeof(RouteAttribute), inherit: true)
                .Cast<RouteAttribute>()
                .FirstOrDefault();
                if (routeAtt != null)
                {
                    actionNameInUrl = routeAtt.Template;
                }
                else
                {
                    //去除掉http方法跟Async得到剩下的方法名
                    actionNameInUrl = HttpMethodHelper
                .RemoveHttpMethodPrefix(action.ActionName, httpMethod)
                .RemovePostFix("Async");
                }
            }
            else
            {
                actionNameInUrl = configuration.UrlActionNameNormalizer(
                new UrlActionNameNormalizerContext(
                    rootPath,
                    controllerName,
                    action,
                    actionNameInUrl,
                    httpMethod
                )
            );
            }

            return actionNameInUrl;
        }

    }
}
