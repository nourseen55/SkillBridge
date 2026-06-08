
namespace SkillBridge.Application.Dtos;

public record CreateCourseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
}
public record CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    

}