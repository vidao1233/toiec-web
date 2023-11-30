using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toiec_web.Infrastructure;
using toiec_web.Models;
using toiec_web.Repository.IRepository;

namespace toiec_web.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CourseRepository(ToiecDbContext dbContext, IUnitOfWork uow, IMapper mapper) : base(dbContext)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCourse(Guid courseId)
        {
            var course = GetById(courseId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            Entities.Remove(course);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            var listData = new List<CourseModel>();
            var data = await Entities.ToListAsync();
            foreach (var item in data)
            {
                var obj = _mapper.Map<CourseModel>(item);
                listData.Add(obj);
            }
            return listData;
        }

        public async Task<CourseModel> GetCourseById(Guid courseId)
        {
            IAsyncEnumerable<Course> courses = Entities.AsAsyncEnumerable();
            await foreach (var course in courses)
            {
                if (course.idCourse == courseId)
                {
                    CourseModel data = _mapper.Map<CourseModel>(course);
                    return data;
                }
            }
            return null;
        }

        public Task<bool> AddCourse(CourseModel model)
        {
            try
            {
                var course = _mapper.Map<Course>(model);
                course.idCourse = Guid.NewGuid();
                Entities.Add(course);
                _uow.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> UpdateCourse(CourseModel model, Guid courseId)
        {
            try
            {
                var course = _mapper.Map<Course>(model);
                course.idCourse = courseId;
                Entities.Update(course);
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
