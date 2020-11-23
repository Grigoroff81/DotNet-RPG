﻿// <auto-generated />
using System;
using DotNet_RPG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetRpg.Data.Migrations
{
    [DbContext(typeof(DotNetRpgContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DotNetRpg.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Defence")
                        .HasColumnType("int");

                    b.Property<int>("Hitpoints")
                        .HasColumnType("int");

                    b.Property<int>("Inelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RpgClassId")
                        .HasColumnType("int");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RpgClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Defence = 10,
                            Hitpoints = 100,
                            Inelligence = 10,
                            Name = "Frodo",
                            RpgClassId = 1,
                            Strenght = 10
                        });
                });

            modelBuilder.Entity("DotNetRpg.Models.RpgClass", b =>
                {
                    b.Property<int>("RpgClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RpgClassName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RpgClassId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            RpgClassId = 1,
                            RpgClassName = "Hobit"
                        });
                });

            modelBuilder.Entity("DotNetRpg.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DotNetRpg.Models.Character", b =>
                {
                    b.HasOne("DotNetRpg.Models.RpgClass", "Class")
                        .WithMany("Characters")
                        .HasForeignKey("RpgClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetRpg.Models.User", "User")
                        .WithMany("UserChararacters")
                        .HasForeignKey("UserId");

                    b.Navigation("Class");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotNetRpg.Models.RpgClass", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("DotNetRpg.Models.User", b =>
                {
                    b.Navigation("UserChararacters");
                });
#pragma warning restore 612, 618
        }
    }
}
