

namespace SkillBridge.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int DurationInMinutes { get; set; }
        public int Order { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}
