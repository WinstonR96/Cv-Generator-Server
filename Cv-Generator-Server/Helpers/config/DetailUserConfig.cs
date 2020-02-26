using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class DetailUserConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public DetailUserConfig(EntityTypeBuilder<DetailUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.DetailId);
            entityBuilder.Property(x => x.Second_Name).HasMaxLength(50).IsRequired();
        }
    }
}
