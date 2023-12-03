using toiec_web.Repository;
using toiec_web.Repository.IRepository;
using toiec_web.Services;
using toiec_web.Services.IService;

namespace toiec_web.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(ICourseRepository), typeof(CourseRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddTransient(typeof(IProfessorRepository), typeof(ProfessorRepository));
            services.AddTransient(typeof(ILessonRepository), typeof(LessonRepository));
            services.AddTransient(typeof(IQuizRepository), typeof(QuizRepository));
            services.AddTransient(typeof(IVocTopicRepository), typeof(VocTopicRepository));
            services.AddTransient(typeof(IVocabularyRepository), typeof(VocabularyRepository));
            services.AddTransient(typeof(ITestTypeRepository), typeof(TestTypeRepository));
            services.AddTransient(typeof(IPaymentMethodRepository), typeof(PaymentMethodRepository));
            services.AddTransient(typeof(IPaymentRepository), typeof(PaymentRepository));
            return services;
        }
        
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IProfessorService, ProfessorService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IVocTopicService, VocTopicService>();
            services.AddTransient<IVocabularyService, VocabularyService>();
            services.AddTransient<ITestTypeService, TestTypeService>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddScoped<IMomoService, MomoService>();
            return services;
        }
    }
}
