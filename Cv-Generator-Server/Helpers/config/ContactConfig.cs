using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class ContactConfig
    {
        public ContactConfig(EntityTypeBuilder<Contact> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ContactId);
            entityBuilder.Property(x => x.Type).HasMaxLength(20);
            entityBuilder.Property(x => x.Description).HasMaxLength(20);
        }
    }
}
