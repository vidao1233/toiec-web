using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class VocabularyRepository : Repository<Vocabulary>, IVocabularyRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _professorRepository;

        public VocabularyRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper,
            IProfessorRepository professorRepository) 
            : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
            _professorRepository = professorRepository;
        }

        public async Task<bool> AddVocabulary(VocabularyModel model, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);

                var voc = _mapper.Map<Vocabulary>(model);
                voc.idVoc = Guid.NewGuid();
                voc.idProfessor = professor.idProfessor;
                Entities.Add(voc);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVocabulary(Guid vocId)
        {
            var voc = GetById(vocId);
            if (voc == null)
            {
                throw new ArgumentNullException(nameof(voc));
            }
            Entities.Remove(voc);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<VocabularyModel>> GetAllVocabularies()
        {
            var listData = new List<VocabularyModel>();
            var data = await Entities.OrderBy(v => v.engWord).ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<VocabularyModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<IEnumerable<VocabularyModel>> GetAllVocabularyByTopic(Guid topicId)
        {
            var listData = new List<VocabularyModel>();
            var data = await Entities.OrderBy(v => v.engWord).ToListAsync();
            foreach(var item in data)
            {
                if(item.idTopic == topicId)
                {
                    var obj = _mapper.Map<VocabularyModel>(item);
                    listData.Add(obj);
                }
            }
            return listData;
        }

        public async Task<VocabularyModel> GetVocabularyById(Guid vocId)
        {
            IAsyncEnumerable<Vocabulary> vocs = Entities.AsAsyncEnumerable();
            await foreach (var voc in vocs)
            {
                if (voc.idVoc == vocId)
                {
                    VocabularyModel data = _mapper.Map<VocabularyModel>(voc);
                    return data;
                }
            }
            return null;
        }

        public async Task<bool> UpdateVocabulary(VocabularyModel model, Guid vocId, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);

                var voc = _mapper.Map<Vocabulary>(model);
                voc.idVoc = vocId;
                voc.idProfessor = professor.idProfessor;
                Entities.Update(voc);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
