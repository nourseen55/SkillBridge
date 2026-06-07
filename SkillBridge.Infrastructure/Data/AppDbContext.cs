namespace SkillBridge.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("UserId").StartsAt(1).IncrementsBy(1);
            builder.Entity<AppUser>().Property(t => t.UserId).HasDefaultValueSql("NEXT VALUE FOR UserId");

            //Register Configuration
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateIsDeletedFilter(entityType.ClrType));
                }
            }
        }
        private static LambdaExpression CreateIsDeletedFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");

            var property = Expression.Property(parameter, "IsDeleted");

            var condition = Expression.Equal(property, Expression.Constant(false));

            return Expression.Lambda(condition, parameter);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entity.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Domain.Entities.Module> Modules { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<InternshipApplication> InternshipApplications { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Lesson> Lessons { get; set; }




    }
}
