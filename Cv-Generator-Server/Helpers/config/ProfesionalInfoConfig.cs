using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class ProfesionalInfoConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ProfesionalInfoConfig(EntityTypeBuilder<Profesional_Info> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Profesion).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Profile).HasMaxLength(100).IsRequired();
        }
    }
}
