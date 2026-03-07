using Microsoft.AspNetCore.Components.Authorization;
using MIS_FileLocator.Services;
using System.Security.Claims;

namespace FileLocator.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public CurrentUserService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<string> GetCurrentFullNameAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                
                var fullName = user.FindFirst("FullName")?.Value;

                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    return fullName;
                }

                
                return user.Identity.Name ?? "Unknown User";
            }

            return "System";
        }
    }
}