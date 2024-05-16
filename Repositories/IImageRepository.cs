using LAB1_WEB2_12201039.Models.Domain;

namespace LAB1_WEB2_12201039.Repositories
{
    public interface IImageRepository
    {
        Image Upload(Image image);
        List<Image> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}
