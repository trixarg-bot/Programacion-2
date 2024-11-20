using Microsoft.AspNetCore.Components.Forms;

namespace DiarioDeJuegos.Services;

public interface IFileService
{
    Task<string> SaveImageAsync(IBrowserFile file);
    void DeleteImage(string fileName);
}