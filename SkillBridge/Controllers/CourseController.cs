using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SkillBridge.Application.Dtos;
using SkillBridge.Application.Interfaces.Services;

namespace SkillBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService, IValidator<CreateCourseDto> validator)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
           
            await _courseService.CreateCourseAsync(dto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _courseService.GetAllCoursesAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("test-exception")]
        public IActionResult TestException()
        {
            throw new Exception("Test Global Exception Handler");
        }
    }
}
