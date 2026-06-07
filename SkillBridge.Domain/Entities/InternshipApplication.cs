using SkillBridge.Domain.Enums;

namespace SkillBridge.Domain.Entities
{

    public class InternshipApplication : BaseEntity
    {
        public string StudentId { get; set; } = null!;

        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; } = null!;

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public string? CoverLetter { get; set; }
    }
}
