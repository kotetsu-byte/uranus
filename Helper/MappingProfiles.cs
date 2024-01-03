using AutoMapper;
using Uranus.Dto;
using Uranus.Models;

namespace Uranus.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<User, UserPostDto>();
        CreateMap<UserPostDto, User>();
        CreateMap<Course, CourseDto>();
        CreateMap<CourseDto, Course>();
        CreateMap<Course, CoursePostDto>();
        CreateMap<CoursePostDto, Course>();
        CreateMap<Lesson, LessonDto>();
        CreateMap<LessonDto, Lesson>();
        CreateMap<Lesson, LessonPostDto>();
        CreateMap<LessonPostDto, Lesson>();
        CreateMap<Homework, HomeworkDto>();
        CreateMap<HomeworkDto, Homework>();
        CreateMap<Homework, HomeworkPostDto>();
        CreateMap<HomeworkPostDto, Homework>();
        CreateMap<Test, TestDto>();
        CreateMap<TestDto, Test>();
        CreateMap<Test, TestPostDto>();
        CreateMap<TestPostDto, Test>();
        CreateMap<Video, VideoDto>();
        CreateMap<VideoDto, Video>();
        CreateMap<Video, VideoPostDto>();
        CreateMap<VideoPostDto, Video>();
        CreateMap<Doc, DocDto>();
        CreateMap<DocDto, Doc>();
        CreateMap<Doc, DocPostDto>();
        CreateMap<DocPostDto, Doc>();
        CreateMap<Material, MaterialDto>();
        CreateMap<MaterialDto, Material>();
        CreateMap<Material, MaterialPostDto>();
        CreateMap<MaterialPostDto, Material>();
        CreateMap<UserCourse, UserCourseDto>();
        CreateMap<UserCourseDto, UserCourse>();
    }
}