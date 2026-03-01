using Microsoft.AspNetCore.Identity;    
namespace MIS_FileLocator.Data.Initialization
{
    public static class RolesInitializer
    {
        public static async Task InitializationRolesAsync (RoleManager<IdentityRole> roleManager) // manages roles in identity
        {
            string[] roles = { "Admin", "Editor", "Viewer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    // if not exist then create one
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }


    }
}
