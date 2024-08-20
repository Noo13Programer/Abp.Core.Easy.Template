using Abp.Core.Easy.Template.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Abp.Core.Easy.Template.Permissions;

public class IdentityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IdentityPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(IdentityPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Resource>(name);
    }
}
