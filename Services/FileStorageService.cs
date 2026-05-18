using Microsoft.AspNetCore.Components.Forms;

namespace MIS_FileLocator.Services
{
    public class FileStorageService
    {
        private readonly IWebHostEnvironment _env;

        public FileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Saves an uploaded file to wwwroot/uploads/{folder}/ and returns the relative URL.
        /// Creates the folder automatically if it doesn't exist.
        /// </summary>
        public async Task<string> SaveFileAsync(IBrowserFile file, string folder, long maxSizeBytes = 50 * 1024 * 1024)
        {
            // Build the physical path: wwwroot/uploads/{folder}/
            var uploadDir = Path.Combine(_env.WebRootPath, "uploads", folder);
            Directory.CreateDirectory(uploadDir); // creates if not exists

            // Sanitize filename and make it unique
            var safeName = Path.GetFileNameWithoutExtension(file.Name)
                .Replace(" ", "_")
                .Replace("/", "_")
                .Replace("\\", "_");
            var ext = Path.GetExtension(file.Name);
            var fileName = $"{Guid.NewGuid()}_{safeName}{ext}";
            var filePath = Path.Combine(uploadDir, fileName);

            // Write to disk
            await using var fs = new FileStream(filePath, FileMode.Create);
            await using var stream = file.OpenReadStream(maxAllowedSize: maxSizeBytes);
            await stream.CopyToAsync(fs);

            // Return relative URL for browser access
            return $"/uploads/{folder}/{fileName}";
        }

        /// <summary>
        /// Deletes a file given its relative URL (e.g. /uploads/documents/file.pdf).
        /// Silently ignores if file doesn't exist.
        /// </summary>
        public void DeleteFile(string? relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(relativeUrl)) return;

            // Convert relative URL to physical path
            var relativePath = relativeUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var physicalPath = Path.Combine(_env.WebRootPath, relativePath);

            if (File.Exists(physicalPath))
                File.Delete(physicalPath);
        }
    }
}
