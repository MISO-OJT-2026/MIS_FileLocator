using Microsoft.AspNetCore.Components.Authorization;
using MIS_FileLocator.Services;
using Microsoft.AspNetCore.Identity;
using FileLocator.Models;
using MIS_FileLocator.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace FileLocator.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IServiceProvider _serviceProvider ;
        public CurrentUserService(AuthenticationStateProvider authStateProvider, IServiceProvider serviceProvider)
        {
            _authStateProvider = authStateProvider;
            _serviceProvider = serviceProvider; 
        }

        public async Task<string> GetCurrentFullNameAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                
                var fullNameClaim = user.FindFirst("FullName")?.Value;

                if (!string.IsNullOrWhiteSpace(fullNameClaim))
                {
                    return fullNameClaim;
                }

                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    using var scope = _serviceProvider.CreateScope();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var appUser = await userManager.FindByIdAsync(userId);

                    if (appUser != null && !string.IsNullOrWhiteSpace(appUser.FullName))
                    {
                        return appUser.FullName;
                    }
                }

                return user.Identity.Name ?? "Unknown User";
            }

            return "System";
        }
        public async Task<string> GetCurrentUserIdAsync()
        {
            var userState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = userState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                // This retrieves the GUID/ID of the user from their claims
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return null;
        }




    }

}