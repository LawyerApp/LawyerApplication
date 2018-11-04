using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LawyerApp.Infrastructures
{
    public static class FileService
    {
        public async static Task<string> UploadImageAsync(IFormFile file, string directoryName)
        {
            if (file == null)
                throw new ArgumentNullException("File can't be empty!");

            string fileNameWithExtension = Path.GetFileName(file.FileName);
            string fileExtension = Path.GetExtension(fileNameWithExtension);

            if (!(fileExtension.ToLower() == "."+FileExtensions.jpeg.ToString() ||
                fileExtension.ToLower() == "."+FileExtensions.jpg.ToString() ||
                fileExtension.ToLower() == "."+FileExtensions.png.ToString() ||
                fileExtension.ToLower() == "."+FileExtensions.svg.ToString() ||
                fileExtension.ToLower() == "."+FileExtensions.gif.ToString()
                ))
                throw new InvalidContentTypeException("This content type does not supported !!!");

            try
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_file"+fileExtension;
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot", directoryName, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return fileName;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void DeleteFile(string fileName ,string directoryName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directoryName, fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

        }
    }
}
