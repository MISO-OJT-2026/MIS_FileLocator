using Microsoft.AspNetCore.Identity;

namespace MIS_FileLocator.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeId { get; set; } = " ";
        public string FullName { get; set; } = " ";
        public string Department { get; set; } = " ";

      
        public string? AllowedConfidentialityLevels { get; set; }

        
        public List<int> GetAllowedLevelIds() =>
            string.IsNullOrWhiteSpace(AllowedConfidentialityLevels)
                ? new List<int>()
                : AllowedConfidentialityLevels.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.TryParse(s.Trim(), out var id) ? id : 0)
                    .Where(id => id > 0).ToList();
    }
}
