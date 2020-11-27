using DotNetRpg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_RPG.Data.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seeder(this ModelBuilder builder)
        {
            builder.Entity<RpgClass>().HasData(

                new RpgClass
                {
                    RpgClassId = 1,
                    RpgClassName = "Hobit"

                });
            builder.Entity<Weapon>().HasData(
                new Weapon
                {
                    WeaponId = 1,
                    WeaponName = "Sword",
                    Damage = 20,
                    CharacterId = 1,
                });
            builder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frodo",
                    Hitpoints = 100,
                    Defence = 10,
                    Strenght = 10,
                    Inelligence = 10,
                    RpgClassId = 1,
                    WeaponId =1,
                });
        }
    }
}
