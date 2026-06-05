
using SkillBridge.Application.Dtos;
using SkillBridge.Application.Interfaces.Services;
using SkillBridge.Application.Interfaces.UnitOfWork;
using SkillBridge.Domain.Entities;

namespace SkillBridge.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCourseAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title
            };

            await _unitOfWork.Repository<Course>().AddAsync(course);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _unitOfWork.Repository<Course>().GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }

    }
}
