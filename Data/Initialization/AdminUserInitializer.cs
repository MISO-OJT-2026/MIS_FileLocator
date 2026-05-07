using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MIS_FileLocator.Data.Initialization
{
    public static class AdminUserInitializer
    {
        public static async Task InitializerAdminUserAsync(
            UserManager<ApplicationUser>userManager)
        {
            var employeeId = "19-01690";
            var adminPassword = "Admin@123";

            var existingUser = await userManager.Users.FirstOrDefaultAsync(u => u.EmployeeId == employeeId); 


            if (existingUser == null) 
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "taylorbatumbakal",
                    EmployeeId = employeeId,
                    FullName = "Taylor Batumbakal",
                    Department = "Front Desk",
                    EmailConfirmed = true

                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine("Admin user created successfully!");
                }
                else
                {
                    
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }

            }
                
        }
    }
}
