namespace SkillBridge.Domain.Entities
{
    public class Progress:BaseEntity
    {

        public string UserId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public double CompletionPercentage { get; set; }
        public double Score { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
