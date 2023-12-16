namespace QuanLyNhanSuWEB.Helper
{
    public class UploadFileHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploadfiles");
           
            string filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return file.FileName; // Trả về tên gốc của file
        }

        public void DeleteFile(string fileName)
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploadfiles", fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
