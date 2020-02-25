using Cv_Generator_Server.Helpers.config;
using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_Generator_Server.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DetailUser> detailUsers { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Profesional_Info> profesional_Infos { get; set; }
        public DbSet<Academic> academics { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Experience_Work> experience_Works { get; set; }
        public DbSet<Reference> references { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            new DetailUserConfig(builder.Entity<DetailUser>());
            new UserConfig(builder.Entity<User>());
            new SkillConfig(builder.Entity<Skill>());
            new ProfesionalInfoConfig(builder.Entity<Profesional_Info>());
            new AcademicConfig(builder.Entity<Academic>());
            new ContactConfig(builder.Entity<Contact>());
            new ExperienceWorkConfig(builder.Entity<Experience_Work>());
            new ReferenceConfig(builder.Entity<Reference>());

            base.OnModelCreating(builder);
        }

    }
}
