using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class ReferenceConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ReferenceConfig(EntityTypeBuilder<Reference> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ReferenceId);
            entityBuilder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Email).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Phone).HasMaxLength(25).IsRequired();
        }
    }
}
