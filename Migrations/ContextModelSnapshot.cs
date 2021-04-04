﻿// <auto-generated />
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookApi.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("AuthorId")
                        .HasColumnName("authorid")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sinopsis")
                        .HasColumnName("sinopsis")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookApi.Models.Book", b =>
                {
                    b.HasOne("BookApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
