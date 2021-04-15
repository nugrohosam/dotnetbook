﻿// <auto-generated />
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210414065038_BookAPIMigration02")]
    partial class BookAPIMigration02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookApi.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookApi.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("Authorid")
                        .HasColumnName("authorid")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sinopsis")
                        .HasColumnName("sinopsis")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Authorid");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookApi.Models.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("BookApi.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("BookApi.Models.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("Permissionid")
                        .HasColumnName("permissionid")
                        .HasColumnType("bigint");

                    b.Property<long>("Roleid")
                        .HasColumnName("roleid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Permissionid");

                    b.HasIndex("Roleid");

                    b.ToTable("role_permission");
                });

            modelBuilder.Entity("BookApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BookApi.Models.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("Roleid")
                        .HasColumnName("roleid")
                        .HasColumnType("bigint");

                    b.Property<long>("Userid")
                        .HasColumnName("userid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Roleid");

                    b.HasIndex("Userid");

                    b.ToTable("user_role");
                });

            modelBuilder.Entity("BookApi.Models.Book", b =>
                {
                    b.HasOne("BookApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("Authorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApi.Models.RolePermission", b =>
                {
                    b.HasOne("BookApi.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("Permissionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApi.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApi.Models.UserRole", b =>
                {
                    b.HasOne("BookApi.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApi.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}