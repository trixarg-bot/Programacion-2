using Microsoft.AspNetCore.Components.Forms;

namespace DiarioDeJuegos.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    private readonly string _uploadsFolder;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
        _uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        if (!Directory.Exists(_uploadsFolder))
        {
            Directory.CreateDirectory(_uploadsFolder);
        }
    }

    public async Task<string> SaveImageAsync(IBrowserFile file)
    {
        if (file == null) return string.Empty;

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
        var filePath = Path.Combine(_uploadsFolder, fileName);

        using var stream = file.OpenReadStream(maxAllowedSize: 4 * 1024 * 1024); // 4MB max
        using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return $"/uploads/{fileName}";
    }

    public void DeleteImage(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return;

        var filePath = Path.Combine(_environment.WebRootPath, fileName.TrimStart('/'));
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}