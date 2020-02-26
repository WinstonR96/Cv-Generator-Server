using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class UserConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public UserConfig(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);
        }
    }
}
