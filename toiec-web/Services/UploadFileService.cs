using CloudinaryDotNet.Actions;
using toeic_web.Repository.IRepository;
using toeic_web.Services.IService;

namespace toeic_web.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public UploadFileService(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public async Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files)
        {
            return await _uploadFileRepository.AddListFileAsync(files);
        }

        public async Task<ImageUploadResult> AddFileAsync(IFormFile file)
        {
            return await _uploadFileRepository.AddFileAsync(file);
        }

        public async Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId)
        {
            return await _uploadFileRepository.DeleteListFileAsync(listId);
        }

        public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
            return await _uploadFileRepository.DeleteFileAsync(publicId);
        }

        public async Task<VideoUploadResult> AddAudioAsync(IFormFile file)
        {
            return await _uploadFileRepository.AddAudioAsync(file);
        }
    }
}
