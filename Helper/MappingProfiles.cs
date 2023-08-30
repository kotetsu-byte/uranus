using AutoMapper;
using Uranus.Dto;
using Uranus.Models;

namespace Uranus.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<Homework, HomeworkDto>();
            CreateMap<HomeworkDto, Homework>();
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
        }
    }
}
