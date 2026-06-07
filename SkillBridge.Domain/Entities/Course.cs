namespace SkillBridge.Domain.Entities;

public class Course:BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;

    public ICollection<Module> Modules { get; set; }= new List<Module>();
}
