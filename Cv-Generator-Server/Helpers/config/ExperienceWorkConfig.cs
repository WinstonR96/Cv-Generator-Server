using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class ExperienceWorkConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ExperienceWorkConfig(EntityTypeBuilder<Experience_Work> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Company).HasMaxLength(60).IsRequired();
            entityBuilder.Property(x => x.Rol).HasMaxLength(30).IsRequired();
            entityBuilder.Property(x => x.Rol_Description).HasMaxLength(255).IsRequired();
        }
    }
}
