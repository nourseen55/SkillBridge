namespace SkillBridge.Infrastructure.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasMany(l => l.Quizzes)
          .WithOne(q => q.Lesson)
          .HasForeignKey(q => q.LessonId)
          .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.Progresses)
                .WithOne(p => p.Lesson)
                .HasForeignKey(p => p.LessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
