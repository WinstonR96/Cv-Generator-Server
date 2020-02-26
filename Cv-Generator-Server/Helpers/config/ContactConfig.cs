using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cv_Generator_Server.Helpers.config
{
    /// <summary>
    /// Aplicando fluent api al model
    /// </summary>
    public class ContactConfig
    {
        /// <summary>
        /// Configurando model
        /// </summary>
        /// <param name="entityBuilder"></param>
        public ContactConfig(EntityTypeBuilder<Contact> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ContactId);
            entityBuilder.Property(x => x.Type).HasMaxLength(20);
            entityBuilder.Property(x => x.Description).HasMaxLength(20);
        }
    }
}
