using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class VocTopicRepository : Repository<VocTopic>, IVocTopicRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _professorRepository;

        public VocTopicRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper,
            IProfessorRepository professorRepository) 
            : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
            _professorRepository = professorRepository;
        }

        public async Task<bool> AddVocTopic(VocTopicModel model, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);

                var topic = _mapper.Map<VocTopic>(model);
                topic.idVocTopic = Guid.NewGuid();
                topic.idProfessor = professor.idProfessor;
                Entities.Add(topic);
                _uow.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVocTopic(Guid topicId)
        {
            var topic = GetById(topicId);
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }
            Entities.Remove(topic);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<VocTopicModel>> GetAllVocTopics()
        {
            var listData = new List<VocTopicModel>();
            var data = await Entities.ToListAsync();
            foreach ( var item in data)
            {
                var obj = _mapper.Map<VocTopicModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<VocTopicModel> GetVocTopicById(Guid topicId)
        {
            IAsyncEnumerable<VocTopic> topics = Entities.AsAsyncEnumerable();
            await foreach (var topic in topics)
            {
                if (topic.idVocTopic == topicId)
                {
                    VocTopicModel data = _mapper.Map<VocTopicModel>(topic);
                    return data;
                }
            }
            return null;
        }

        public async Task<bool> UpdateVocTopic(VocTopicModel model, Guid topicId, string userId)
        {
            try
            {
                //get professor by userId
                var professor = await _professorRepository.GetProfessorByUserId(userId);

                var topic = _mapper.Map<VocTopic>(model);
                topic.idVocTopic = topicId;
                topic.idProfessor = professor.idProfessor;
                Entities.Update(topic);
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
