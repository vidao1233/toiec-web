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
        public VocTopicRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task<bool> AddVocTopic(VocTopicModel model)
        {
            try
            {
                var topic = _mapper.Map<VocTopic>(model);
                topic.idVocTopic = Guid.NewGuid();
                Entities.Add(topic);
                _uow.SaveChanges();
                return Task.FromResult(true);
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

        public Task<bool> UpdateVocTopic(VocTopicModel model, Guid topicId, Guid professorId)
        {
            try
            {
                var topic = _mapper.Map<VocTopic>(model);
                topic.idVocTopic = topicId;
                topic.idProfessor = professorId;
                Entities.Update(topic);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
