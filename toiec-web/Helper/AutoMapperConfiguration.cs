using AutoMapper;
using toiec_web.Models;
using toiec_web.ViewModels.Course;
using toiec_web.ViewModels.Lesson;
using toiec_web.ViewModels.Quiz;
using toiec_web.ViewModels.Test;
using toiec_web.ViewModels.TestQuestionUnit;
using toiec_web.ViewModels.TestType;
using toiec_web.ViewModels.User;
using toiec_web.ViewModels.Vocabulary;
using toiec_web.ViewModels.VocTopic;

namespace toiec_web.Helper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region Course
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<CourseModel, CourseViewModel>().ReverseMap();
            CreateMap<CourseModel, CourseAddModel>().ReverseMap();
            CreateMap<CourseModel, CourseUpdateModel>().ReverseMap();
            #endregion

            #region User
            CreateMap<Users, UserModel>().ReverseMap();
            CreateMap<Users, UserViewModel>().ReverseMap();
            CreateMap<UserModel, UserViewModel>().ReverseMap();
            #endregion

            #region Student
            CreateMap<Student, StudentModel>().ReverseMap();
            #endregion

            #region Professor
            CreateMap<Professor, ProfessorModel>().ReverseMap();
            #endregion

            #region Lesson
            CreateMap<Lesson, LessonModel>().ReverseMap();
            CreateMap<LessonModel, LessonAddModel>().ReverseMap();
            CreateMap<LessonModel, LessonViewModel>().ReverseMap();
            CreateMap<LessonModel, LessonUpdateModel>().ReverseMap();
            #endregion

            #region Quiz
            CreateMap<Quiz, QuizModel>().ReverseMap();
            CreateMap<QuizModel, QuizAddModel>().ReverseMap();
            CreateMap<QuizModel, QuizUpdateModel>().ReverseMap();
            CreateMap<QuizModel, QuizViewModel>().ReverseMap();
            #endregion

            #region VocTopic
            CreateMap<VocTopic, VocTopicModel>().ReverseMap();
            CreateMap<VocTopicModel, VocTopicViewModel>().ReverseMap();
            CreateMap<VocTopicModel, VocTopicAddModel>().ReverseMap();
            CreateMap<VocTopicModel, VocTopicUpdateModel>().ReverseMap();
            #endregion

            #region Vocabulary
            CreateMap<Vocabulary, VocabularyModel>().ReverseMap();
            CreateMap<VocabularyModel, VocabularyAddModel>().ReverseMap();
            CreateMap<VocabularyModel, VocabularyViewModel>().ReverseMap();
            CreateMap<VocabularyModel, VocabularyUpdateModel>().ReverseMap();
            #endregion

            #region TestType
            CreateMap<TestType, TestTypeModel>().ReverseMap();
            CreateMap<TestTypeModel, TestTypeViewModel>().ReverseMap();
            CreateMap<TestTypeModel, TestTypeAddModel>().ReverseMap();
            CreateMap<TestTypeModel, TestTypeUpdateModel>().ReverseMap();
            #endregion

            #region Test
            CreateMap<Test, TestModel>().ReverseMap();
            CreateMap<TestModel, TestViewModel>().ReverseMap();
            CreateMap<TestModel, TestAddModel>().ReverseMap();
            CreateMap<TestModel, TestUpdateModel>().ReverseMap();
            #endregion

            #region TestQuestionUnit
            CreateMap<TestQuestionUnit, TestQuestionUnitModel>().ReverseMap();
            CreateMap<TestQuestionUnitModel, TestQuestionUnitViewModel>().ReverseMap();
            CreateMap<TestQuestionUnitModel, TestQuestionUnitAddModel>().ReverseMap();
            CreateMap<TestQuestionUnitModel, TestQuestionUnitUpdateModel>().ReverseMap();
            #endregion

        }
    }
}
