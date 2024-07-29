namespace ILPManagementSystem.Services
{
    public static class FileUploadHelper
    {
        public static async Task<(string filePath, string fileName)> UploadFile(IFormFile file, string folderName)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", folderName);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return (filePath, fileName);
        }
    }
}
