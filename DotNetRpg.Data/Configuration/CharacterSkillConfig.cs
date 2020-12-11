using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Data.Configuration
{
    public class CharacterSkillConfig : IEntityTypeConfiguration<CharacterSkill>
    {
        public void Configure(EntityTypeBuilder<CharacterSkill> builder)
        {
            builder.HasKey(cs => new { cs.CharacterId, cs.SkillId });
        }
    }
}
