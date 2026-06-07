namespace SkillBridge.Domain.Entities
{
    public class Module:BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Order { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }= null!;
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
