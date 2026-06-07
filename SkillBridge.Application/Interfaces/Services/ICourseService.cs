
using SkillBridge.Application.Dtos;
using SkillBridge.Application.Dtos.Common;
using SkillBridge.Application.ReturnObject;

namespace SkillBridge.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CreateCourseDto dto);
        Task<Result<PagedResults<CourseDto>>> GetAllCoursesAsync(int pageNumber, int pageSize);

    }
}
