using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRpg.Data.Configuration
{
    public class WeaponConfig : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasKey(w => w.WeaponId);
            builder.Property(w => w.WeaponName);
            builder.Property(w => w.Damage);

            //builder.HasOne(weapon => weapon.Character)
            //    .WithOne(character => character.Weapon)
            //    .HasForeignKey<Character>(w => w.WeaponId);
        }
    }
}
