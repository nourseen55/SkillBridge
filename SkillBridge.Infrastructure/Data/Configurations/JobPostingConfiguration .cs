namespace SkillBridge.Infrastructure.Data.Configurations
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {


            builder.HasOne<AppUser>()
           .WithMany()
           .HasForeignKey(j => j.CompanyId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(j => j.Applications)
                .WithOne(a => a.JobPosting)
                .HasForeignKey(a => a.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
