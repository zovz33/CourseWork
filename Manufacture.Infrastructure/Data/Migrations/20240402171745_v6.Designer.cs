﻿// <auto-generated />
using System;
using Manufacture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Manufacture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402171745_v6")]
    partial class v6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int?>("UpdatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDateTime")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfileImage")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<int?>("UpdatedBy")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductToOrderId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductToOrderId")
                        .IsUnique();

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("ProductToOrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.ProductToOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ProductToOrder", (string)null);
                });

            modelBuilder.Entity("Manufacture.Core.Entities.RawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("RawMaterials", (string)null);
                });

            modelBuilder.Entity("ProductToOrderRawMaterial", b =>
                {
                    b.Property<int>("ProductMaterialId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductMaterialId1")
                        .HasColumnType("integer");

                    b.HasKey("ProductMaterialId", "ProductMaterialId1");

                    b.HasIndex("ProductMaterialId1");

                    b.ToTable("ProductToOrderRawMaterial");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.Identity.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.Identity.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manufacture.Core.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.Identity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Order", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.ProductToOrder", "ProductToOrder")
                        .WithOne("Order")
                        .HasForeignKey("Manufacture.Core.Entities.Order", "ProductToOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductToOrder");
                });

            modelBuilder.Entity("ProductToOrderRawMaterial", b =>
                {
                    b.HasOne("Manufacture.Core.Entities.RawMaterial", null)
                        .WithMany()
                        .HasForeignKey("ProductMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manufacture.Core.Entities.ProductToOrder", null)
                        .WithMany()
                        .HasForeignKey("ProductMaterialId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.Role", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.Identity.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Logins");

                    b.Navigation("Tokens");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Manufacture.Core.Entities.ProductToOrder", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
