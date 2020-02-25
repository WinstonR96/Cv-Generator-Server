using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class ExperienceWorkConfig
    {
        public ExperienceWorkConfig(EntityTypeBuilder<Experience_Work> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Company).HasMaxLength(60).IsRequired();
            entityBuilder.Property(x => x.Rol).HasMaxLength(30).IsRequired();
            entityBuilder.Property(x => x.Rol_Description).HasMaxLength(255).IsRequired();
        }
    }
}
