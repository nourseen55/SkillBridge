
namespace SkillBridge.Domain.Entities;

public class AppUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }

    public ICollection<Progress> Progresses { get; set; }
}
