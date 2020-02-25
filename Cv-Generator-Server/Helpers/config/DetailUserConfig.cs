using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class DetailUserConfig
    {
        public DetailUserConfig(EntityTypeBuilder<DetailUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.DetailId);
            entityBuilder.Property(x => x.Second_Name).HasMaxLength(50).IsRequired();
        }
    }
}
