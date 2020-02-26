using Cv_Generator_Server.Helpers.config;
using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_Generator_Server.Helpers
{
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Model
        /// </summary>
        public DbSet<DetailUser> detailUsers { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<User> users { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Skill> skills { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Profesional_Info> profesional_Infos { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Academic> academics { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Contact> contacts { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Experience_Work> experience_Works { get; set; }
        /// <summary>
        /// Model
        /// </summary>
        public DbSet<Reference> references { get; set; }


        /// <summary>
        /// Aplicando el afluent api
        /// </summary>
        /// <param name="builder"></param>
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
