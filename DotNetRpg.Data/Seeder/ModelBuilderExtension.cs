using DotNetRpg.Data;
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
            builder.Entity<Skill>().HasData(
                 new Skill { Id = 1, Name = "Fireball", Damage = 30 },
                 new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
                 new Skill { Id = 3, Name = "Blizzrad", Damage = 50 });

            Utility.CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

            builder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Ivo" },
                new User { Id = 2, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Username = "Desy" });

            builder.Entity<RpgClass>().HasData(
                new RpgClass { RpgClassId = 1, RpgClassName = "Hobbit" },
                new RpgClass { RpgClassId = 2, RpgClassName = "Wizzard" }
                );

            builder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frodo",
                    RpgClassId = 1,
                    Hitpoints = 100,
                    Strenght = 15,
                    Defence = 10,
                    Inelligence = 10,
                    UserId = 1
                },
                new Character
                {
                    Id = 2,
                    Name = "Gandalf",
                    RpgClassId = 2,
                    Hitpoints = 100,
                    Strenght = 10,
                    Defence = 10,
                    Inelligence = 20,
                    UserId = 2
                }
                );

            builder.Entity<Weapon>().HasData(
                new Weapon { WeaponId = 1, WeaponName = "Sword", Damage = 20, CharacterId = 1 },
                new Weapon { WeaponId = 2, WeaponName = "Wand", Damage = 30, CharacterId = 2 }
                );

            builder.Entity<CharacterSkill>().HasData(
                new CharacterSkill { CharacterId = 1, SkillId = 2 },
                new CharacterSkill { CharacterId = 2, SkillId = 1 },
                new CharacterSkill { CharacterId = 2, SkillId = 3 }
                );
        }
    }
}
