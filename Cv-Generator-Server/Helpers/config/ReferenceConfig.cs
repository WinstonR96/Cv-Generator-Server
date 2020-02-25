using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class ReferenceConfig
    {
        public ReferenceConfig(EntityTypeBuilder<Reference> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ReferenceId);
            entityBuilder.Property(x => x.Name).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Email).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Phone).HasMaxLength(25).IsRequired();
        }
    }
}
