using _0_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private IWebHostEnvironment _webHostEnvironment;//گرفتن مسیر فایل

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        string IFileUploader.Upload(IFormFile file, string path)
        {
            if (file == null) return "";
            var directoryPath = $"{ _webHostEnvironment.WebRootPath }//ProductPictures//{path}";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var fileName =$"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output = System.IO.File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}
