using Microsoft.AspNetCore.Identity;

namespace MIS_FileLocator.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeId { get; set; } = " ";
        public string FullName { get; set; } = " ";
        public string Department { get; set; } = " ";

        /// <summary>
        /// Comma-separated ConfidentialityLevel IDs this user can view.
        /// NULL = no restriction (Admin/Editor see all).
        /// e.g. "1,2" = can see Public and Internal Use only.
        /// </summary>
        public string? AllowedConfidentialityLevels { get; set; }

        // Helper: parse to list
        public List<int> GetAllowedLevelIds() =>
            string.IsNullOrWhiteSpace(AllowedConfidentialityLevels)
                ? new List<int>()
                : AllowedConfidentialityLevels.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.TryParse(s.Trim(), out var id) ? id : 0)
                    .Where(id => id > 0).ToList();
    }
}
