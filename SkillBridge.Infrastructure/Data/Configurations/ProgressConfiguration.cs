namespace SkillBridge.Infrastructure.Data.Configurations
{
    public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
    {
        public void Configure(EntityTypeBuilder<Progress> builder)
        {

            builder.HasIndex(p => new { p.UserId, p.LessonId })
                .IsUnique();

            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
