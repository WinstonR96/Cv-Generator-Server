using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class ProfesionalInfoConfig
    {
        public ProfesionalInfoConfig(EntityTypeBuilder<Profesional_Info> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Profesion).HasMaxLength(25).IsRequired();
            entityBuilder.Property(x => x.Profile).HasMaxLength(100).IsRequired();
        }
    }
}
