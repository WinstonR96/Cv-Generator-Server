using Cv_Generator_Server.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Helpers.config
{
    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);
        }
    }
}
