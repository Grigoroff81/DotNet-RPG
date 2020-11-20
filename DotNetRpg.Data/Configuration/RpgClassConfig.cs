using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Data.Configuration
{
    public class RpgClassConfig : IEntityTypeConfiguration<RpgClass>
    {
        public void Configure(EntityTypeBuilder<RpgClass> builder)
        {
            builder.HasKey(rpg => rpg.RpgClassId);
            builder.Property(rpg => rpg.RpgClassName);
        }
    }
}
