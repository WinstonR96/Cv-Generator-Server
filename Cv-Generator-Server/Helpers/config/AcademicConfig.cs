using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{

    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class AcademicConfig
    {

        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public AcademicConfig(EntityTypeBuilder<Academic> entityBuilder)
        {
            entityBuilder.HasKey(x => x.AcademicId);
            entityBuilder.Property(x => x.Institution).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Degree).HasMaxLength(25).IsRequired();
        }
    }
}
