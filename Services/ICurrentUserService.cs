namespace MIS_FileLocator.Services
{
    public interface ICurrentUserService
    {
        Task<string> GetCurrentFullNameAsync(); // like $_SESSION['full_name']
        Task<string?> GetCurrentUserIdAsync();
    }
}
