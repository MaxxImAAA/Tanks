﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TanksProject2.DAL.Data;

#nullable disable

namespace TanksProject2.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230924204222_init5")]
    partial class init5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.Tank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Made")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TankType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tanks");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Firepower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ammunition")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("GunName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RateOfFire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TankId")
                        .IsUnique();

                    b.ToTable("Firepowers");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Mobility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EnginePower")
                        .HasColumnType("int");

                    b.Property<int>("SpeedBack")
                        .HasColumnType("int");

                    b.Property<int>("SpeedForward")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TankId")
                        .IsUnique();

                    b.ToTable("Mobilities");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Observation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommunicationRange")
                        .HasColumnType("int");

                    b.Property<int>("Review")
                        .HasColumnType("int");

                    b.Property<int>("TankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TankId")
                        .IsUnique();

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.UserModel.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Firepower", b =>
                {
                    b.HasOne("TanksProject2.Domain.Models.TankModel.Tank", "Tank")
                        .WithOne("Firepower")
                        .HasForeignKey("TanksProject2.Domain.Models.TankModel.TankComponents.Firepower", "TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Mobility", b =>
                {
                    b.HasOne("TanksProject2.Domain.Models.TankModel.Tank", "Tank")
                        .WithOne("Mobility")
                        .HasForeignKey("TanksProject2.Domain.Models.TankModel.TankComponents.Mobility", "TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.TankComponents.Observation", b =>
                {
                    b.HasOne("TanksProject2.Domain.Models.TankModel.Tank", "Tank")
                        .WithOne("Observation")
                        .HasForeignKey("TanksProject2.Domain.Models.TankModel.TankComponents.Observation", "TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.UserModel.User", b =>
                {
                    b.HasOne("TanksProject2.Domain.Models.UserModel.UserAccount", "UserAccount")
                        .WithOne("User")
                        .HasForeignKey("TanksProject2.Domain.Models.UserModel.User", "UserAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.TankModel.Tank", b =>
                {
                    b.Navigation("Firepower")
                        .IsRequired();

                    b.Navigation("Mobility")
                        .IsRequired();

                    b.Navigation("Observation")
                        .IsRequired();
                });

            modelBuilder.Entity("TanksProject2.Domain.Models.UserModel.UserAccount", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}