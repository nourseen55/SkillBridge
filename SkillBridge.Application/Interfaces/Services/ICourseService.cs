
using SkillBridge.Application.Dtos;

namespace SkillBridge.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CreateCourseDto dto);
        Task<List<CourseDto>> GetAllCoursesAsync();

    }
}
