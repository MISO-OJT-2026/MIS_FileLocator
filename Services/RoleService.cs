using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MIS_FileLocator.Data;
using System.Security.Claims;

namespace MIS_FileLocator.Services
{
    public interface IRoleService
    {
        Task<bool> IsAdminAsync(ClaimsPrincipal user);
        Task<bool> IsEditorAsync(ClaimsPrincipal user);
        Task<bool> IsViewerAsync(ClaimsPrincipal user);
        Task<string> GetUserRoleAsync(ClaimsPrincipal user);
        bool CanAccessDashboard(string role);
        bool CanAccessUserManagement(string role);
        bool CanAccessStorage(string role);
        bool CanAccessDocuments(string role);
        bool CanAddEditDocuments(string role);
        bool CanAccessForms(string role);
        bool CanAccessTransactionLogs(string role);
    }

    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> IsAdminAsync(ClaimsPrincipal user)
        {
            return await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(user), "Admin");
        }

        public async Task<bool> IsEditorAsync(ClaimsPrincipal user)
        {
            return await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(user), "Editor");
        }

        public async Task<bool> IsViewerAsync(ClaimsPrincipal user)
        {
            return await _userManager.IsInRoleAsync(await _userManager.GetUserAsync(user), "Viewer");
        }

        public async Task<string> GetUserRoleAsync(ClaimsPrincipal user)
        {
            if (await IsAdminAsync(user)) return "Admin";
            if (await IsEditorAsync(user)) return "Editor";
            if (await IsViewerAsync(user)) return "Viewer";
            return "Staff";
        }

        public bool CanAccessDashboard(string role)
        {
            return role == "Admin" || role == "Editor";
        }

        public bool CanAccessUserManagement(string role)
        {
            return role == "Admin";
        }

        public bool CanAccessStorage(string role)
        {
            return role == "Admin" || role == "Editor";
        }

        public bool CanAccessDocuments(string role)
        {
            return role == "Admin" || role == "Editor" || role == "Viewer";
        }

        public bool CanAddEditDocuments(string role)
        {
            return role == "Admin" || role == "Editor";
        }

        public bool CanAccessForms(string role)
        {
            return role == "Admin" || role == "Editor" || role == "Viewer";
        }

        public bool CanAccessTransactionLogs(string role)
        {
            return role == "Admin";
        }
    }
}
