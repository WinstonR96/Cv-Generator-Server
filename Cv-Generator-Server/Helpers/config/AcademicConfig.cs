using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class AcademicConfig
    {
        public AcademicConfig(EntityTypeBuilder<Academic> entityBuilder)
        {
            entityBuilder.HasKey(x => x.AcademicId);
            entityBuilder.Property(x => x.Institution).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Degree).HasMaxLength(25).IsRequired();
        }
    }
}
