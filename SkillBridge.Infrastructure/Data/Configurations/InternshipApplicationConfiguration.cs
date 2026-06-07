namespace SkillBridge.Infrastructure.Data.Configurations
{
    public class InternshipApplicationConfiguration : IEntityTypeConfiguration<InternshipApplication>
    {
        public void Configure(EntityTypeBuilder<InternshipApplication> builder)
        {
          
            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
