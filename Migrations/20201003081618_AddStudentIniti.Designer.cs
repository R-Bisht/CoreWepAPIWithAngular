﻿// <auto-generated />
using System;
using CoreWepAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreWepAPI.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20201003081618_AddStudentIniti")]
    partial class AddStudentIniti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("CoreWepAPI.Model.AddStudentDetail", b =>
                {
                    b.Property<int>("ASD_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("ASD_AadharNo")
                        .HasColumnType("bigint");

                    b.Property<int>("ASD_Category")
                        .HasColumnType("int");

                    b.Property<int>("ASD_CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ASD_CreatedDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("ASD_DOB")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ASD_DOJ")
                        .HasColumnType("datetime");

                    b.Property<int>("ASD_Distric")
                        .HasColumnType("int");

                    b.Property<string>("ASD_EmailId")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ASD_FatherName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ASD_FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ASD_ImageName")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ASD_LastName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ASD_Leaving_Status")
                        .HasColumnType("int");

                    b.Property<string>("ASD_MotherName")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ASD_PermanentAddress")
                        .HasColumnType("varchar(250)");

                    b.Property<long>("ASD_PhoneNo")
                        .HasColumnType("bigint");

                    b.Property<string>("ASD_PrincipalName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ASD_SignatureName")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ASD_State")
                        .HasColumnType("int");

                    b.Property<int>("ASD_StudentClass")
                        .HasColumnType("int");

                    b.Property<string>("ASD_TeacherName")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ASD_TemporaryAddress")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ASD_gender")
                        .HasColumnType("int");

                    b.HasKey("ASD_Id");

                    b.ToTable("addStudentDetails");
                });

            modelBuilder.Entity("CoreWepAPI.Model.Category", b =>
                {
                    b.Property<int>("CTG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CTG_CREATED_BY")
                        .HasColumnType("int");

                    b.Property<DateTime>("CTG_CREATED_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("CTG_NAME")
                        .HasColumnType("varchar(250)");

                    b.HasKey("CTG");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoreWepAPI.Model.District", b =>
                {
                    b.Property<int>("DST_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DST_CREATEDBY")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("DST_CREATEDDATE")
                        .HasColumnType("Datetime");

                    b.Property<string>("DST_DISTICT")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("DST_STATEID")
                        .HasColumnType("int");

                    b.HasKey("DST_Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("CoreWepAPI.Model.State", b =>
                {
                    b.Property<int>("STD_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("STD_CREATEDBY")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("STD_CREATEDDATE")
                        .HasColumnType("Datetime");

                    b.Property<string>("STD_NAME")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("STD_ID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("CoreWepAPI.Model.StudentClass", b =>
                {
                    b.Property<int>("STC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("STC_CREATED_BY")
                        .HasColumnType("int");

                    b.Property<DateTime>("STC_CREATED_DATE")
                        .HasColumnType("datetime");

                    b.Property<string>("STC_NAME")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("STC");

                    b.ToTable("studentClasses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CoreWepAPI.Model.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(200)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
