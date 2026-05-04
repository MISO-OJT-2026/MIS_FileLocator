using Microsoft.AspNetCore.Identity;

namespace MIS_FileLocator.Data
{
    
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeId { get; set; } = " ";
         public string FullName { get; set; } = " ";

        public string Department { get; set; } = " ";   
    }

}
