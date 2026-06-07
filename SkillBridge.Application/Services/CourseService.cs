
using Microsoft.EntityFrameworkCore;
using SkillBridge.Application.Dtos;
using SkillBridge.Application.Dtos.Common;
using SkillBridge.Application.Interfaces.Services;
using SkillBridge.Application.Interfaces.UnitOfWork;
using SkillBridge.Application.ReturnObject;
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
                Title = dto.Title,
                Description = dto.Description,
                ThumbnailUrl = dto.ThumbnailUrl
            };

            await _unitOfWork.Repository<Course>().SaveAsync(course);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<Result<PagedResults<CourseDto>>> GetAllCoursesAsync(int pageNumber, int pageSize)
        {
            var courses = _unitOfWork.Repository<Course>().GetAllQueryable(x => true).Select(x => new CourseDto
            {
                Id = x.Id,
                Title = x.Title
            });
            var query = await courses
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            int totalItems = await courses.CountAsync();

            return Result<PagedResults<CourseDto>>.Success(new PagedResults<CourseDto>
            {
                Data = query,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalOfPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                TotalOfItems = totalItems
            });


        }

        
    }
}
