using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetRpg.Data.Migrations
{
    public partial class DataSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "RpgClassId", "RpgClassName" },
                values: new object[,]
                {
                    { 1, "Hobbit" },
                    { 2, "Wizzard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 119, 198, 136, 253, 245, 137, 214, 75, 190, 190, 133, 133, 222, 192, 254, 146, 140, 155, 38, 26, 85, 182, 7, 151, 157, 193, 201, 77, 129, 107, 26, 218, 167, 131, 215, 96, 234, 106, 32, 86, 153, 135, 155, 11, 92, 53, 143, 29, 148, 202, 131, 4, 5, 180, 50, 214, 239, 19, 58, 93, 48, 18, 146, 65 }, new byte[] { 23, 9, 43, 188, 63, 209, 149, 111, 67, 95, 114, 131, 207, 99, 138, 9, 91, 195, 25, 147, 39, 206, 64, 118, 160, 167, 169, 30, 58, 224, 144, 165, 120, 46, 34, 209, 87, 141, 205, 77, 237, 207, 90, 87, 225, 218, 12, 116, 118, 218, 34, 155, 45, 27, 254, 154, 157, 2, 178, 76, 225, 250, 30, 171, 192, 225, 243, 224, 1, 141, 89, 223, 90, 6, 115, 18, 200, 87, 25, 204, 85, 112, 59, 51, 53, 139, 141, 226, 149, 196, 159, 45, 224, 71, 66, 2, 238, 194, 163, 183, 158, 174, 14, 253, 163, 145, 102, 158, 97, 131, 144, 226, 240, 80, 102, 123, 7, 32, 11, 150, 65, 59, 197, 156, 148, 155, 225, 94 }, "Ivo" },
                    { 2, new byte[] { 119, 198, 136, 253, 245, 137, 214, 75, 190, 190, 133, 133, 222, 192, 254, 146, 140, 155, 38, 26, 85, 182, 7, 151, 157, 193, 201, 77, 129, 107, 26, 218, 167, 131, 215, 96, 234, 106, 32, 86, 153, 135, 155, 11, 92, 53, 143, 29, 148, 202, 131, 4, 5, 180, 50, 214, 239, 19, 58, 93, 48, 18, 146, 65 }, new byte[] { 23, 9, 43, 188, 63, 209, 149, 111, 67, 95, 114, 131, 207, 99, 138, 9, 91, 195, 25, 147, 39, 206, 64, 118, 160, 167, 169, 30, 58, 224, 144, 165, 120, 46, 34, 209, 87, 141, 205, 77, 237, 207, 90, 87, 225, 218, 12, 116, 118, 218, 34, 155, 45, 27, 254, 154, 157, 2, 178, 76, 225, 250, 30, 171, 192, 225, 243, 224, 1, 141, 89, 223, 90, 6, 115, 18, 200, 87, 25, 204, 85, 112, 59, 51, 53, 139, 141, 226, 149, 196, 159, 45, 224, 71, 66, 2, 238, 194, 163, 183, 158, 174, 14, 253, 163, 145, 102, 158, 97, 131, 144, 226, 240, 80, 102, 123, 7, 32, 11, 150, 65, 59, 197, 156, 148, 155, 225, 94 }, "Desy" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defeats", "Defence", "Fights", "Hitpoints", "Inelligence", "Name", "RpgClassId", "Strenght", "UserId", "Victories" },
                values: new object[] { 1, 0, 10, 0, 100, 10, "Frodo", 1, 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defeats", "Defence", "Fights", "Hitpoints", "Inelligence", "Name", "RpgClassId", "Strenght", "UserId", "Victories" },
                values: new object[] { 2, 0, 10, 0, 100, 20, "Gandalf", 2, 10, 2, 0 });

            migrationBuilder.InsertData(
                table: "ChararacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "WeaponId", "CharacterId", "Damage", "WeaponName" },
                values: new object[,]
                {
                    { 1, 1, 20, "Sword" },
                    { 2, 2, 30, "Wand" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChararacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ChararacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ChararacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "WeaponId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "RpgClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "RpgClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
