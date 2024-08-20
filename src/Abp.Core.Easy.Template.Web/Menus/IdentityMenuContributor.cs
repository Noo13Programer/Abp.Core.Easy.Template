using System.Threading.Tasks;
using Abp.Core.Easy.Template.Localization;
using Abp.Core.Easy.Template.Permissions;
using Abp.Core.Easy.Template.MultiTenancy;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace Abp.Core.Easy.Template.Web.Menus;

public class IdentityMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<Resource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                IdentityMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;
        
        return Task.CompletedTask;
    }
}
