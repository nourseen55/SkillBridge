namespace SkillBridge.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string UserId { get; set; }
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; } = false;
    }
}
