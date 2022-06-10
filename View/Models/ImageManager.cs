using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace View.Models;

public class ImageManager {
    private readonly IHostingEnvironment _hostingEnvironment;
    public ImageManager(IHostingEnvironment env) { _hostingEnvironment = env; }

    public List<string> SaveImage(IFormFileCollection collection) {
        ArgumentNullException.ThrowIfNull(collection);
        var webRootPath = _hostingEnvironment.WebRootPath;
        webRootPath = Path.Combine(webRootPath, "Images");
        var returnPaths = new List<string>();
        foreach (var file in collection) {
            var savePath = Path.Combine(webRootPath, file.FileName);
            file.CopyTo(File.Create(savePath));
            returnPaths.Add(Path.Combine("/Images", file.FileName));
        }
        return returnPaths;
    }
}