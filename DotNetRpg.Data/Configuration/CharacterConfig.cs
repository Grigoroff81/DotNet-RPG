using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Data.Configuration
{
    public class CharacterConfig : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(character => character.Id);

            builder.Property(character => character.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(character => character.Hitpoints);

            builder.Property(character => character.Defence);

            builder.Property(character => character.Inelligence);

            builder.Property(character => character.Strenght);

            builder.HasOne(character => character.Class)
                .WithMany(rpgclass => rpgclass.Characters)
                .HasForeignKey(key => key.RpgClassId);

            builder.HasOne(character => character.Weapon)
                .WithOne(weapon => weapon.Character)
                .HasForeignKey<Weapon>(key=>key.CharacterId);

        }
    }
}
