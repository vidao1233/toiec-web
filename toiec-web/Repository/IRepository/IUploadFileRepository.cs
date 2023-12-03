using CloudinaryDotNet.Actions;

namespace toiec_web.Repository.IRepository
{
    public interface IUploadFileRepository
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<ImageUploadResult> AddAudioAsync(IFormFile file);
        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);
        Task<DeletionResult> DeleteFileAsync(string publicId);
        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId);
    }
}
