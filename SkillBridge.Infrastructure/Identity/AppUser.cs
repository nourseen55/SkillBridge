

namespace SkillBridge.Infrastructure.Identity;

public class AppUser:IdentityUser
{
    public int UserId { get; set; }
    public string FullName { get; set; } = null!;


    public ICollection<Progress> Progresses { get; set; }=new List<Progress>();
    public ICollection<InternshipApplication> Applications { get; set; }=new List<InternshipApplication>();
}
