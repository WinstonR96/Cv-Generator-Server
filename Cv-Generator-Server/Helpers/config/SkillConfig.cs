using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class SkillConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public SkillConfig(EntityTypeBuilder<Skill> entityBuilder)
        {
            entityBuilder.HasKey(x => x.SkillsId);
            entityBuilder.Property(x => x.Description).HasMaxLength(35).IsRequired();
        }

        
    }
}
