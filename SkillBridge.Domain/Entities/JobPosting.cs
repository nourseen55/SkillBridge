namespace SkillBridge.Domain.Entities
{
    public class JobPosting : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Requirements { get; set; } = null!;
        public string Location { get; set; } = null !;
        public DateTime Deadline { get; set; }

        public string CompanyId { get; set; }=null!;

        public ICollection<InternshipApplication> Applications { get; set; } = new List<InternshipApplication>();
    }
}
