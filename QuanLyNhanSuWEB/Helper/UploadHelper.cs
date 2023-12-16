namespace QuanLyNhanSuWEB.Helper
{
    public class UploadHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }
        public void DeleteImage(string fileName)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
