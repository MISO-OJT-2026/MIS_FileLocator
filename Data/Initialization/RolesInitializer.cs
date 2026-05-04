using Microsoft.AspNetCore.Identity;    
namespace MIS_FileLocator.Data.Initialization
{
    public static class RolesInitializer
    {
        public static async Task InitializationRolesAsync (RoleManager<IdentityRole> roleManager) 
        {
            string[] roles = { "Admin", "Editor", "Viewer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }


    }
}
