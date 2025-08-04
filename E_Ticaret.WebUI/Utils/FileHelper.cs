namespace E_Ticaret.WebUI.Utils
{
    public class FileHelper
    {
        // Burada 1 tane dosya yükleyici metod oluşturucaz ve bu class'ımızı tüm projede kullanıcaz.
        public static async Task<string> FileLoaderAsync(IFormFile formfile, string filePath = "/Img/") //async yaptık ki metodumuz daha hızlı çalışsın
        {
            string fileName = "";
            if (formfile != null && formfile.Length > 0)
            { 
                fileName= formfile.FileName.ToLower();
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await formfile.CopyToAsync(stream);
            }
            return fileName;
        }
        // ŞİMDİ DE DOSYA SİLME METODU OLUŞTURUYORUZ
        public static bool FileRemover(string fileName, string filePath = "/wwwroot/Img/")
        {
            string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            if (File.Exists(directory)) 
            { File.Delete(directory);
                return true;
            }
            return false;
        }
    }
}
