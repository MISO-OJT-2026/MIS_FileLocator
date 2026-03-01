using Microsoft.AspNetCore.Identity;

namespace MIS_FileLocator.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeId { get; set; } = " ";
         public string FullName { get; set; } = " ";

        public string Department { get; set; } = " ";   
    }

}
