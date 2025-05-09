﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBlog.Data;

#nullable disable

namespace PersonalBlog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250205090110_fillTheTables")]
    partial class fillTheTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalBlog.Models.ArticleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorModelId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorModelId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is my first article",
                            PublishDate = "2/5/2025",
                            Title = "My First Article"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Models.AuthorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonModelId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonModelId")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Password = "1234",
                            PersonModelId = 1,
                            Username = "benianus"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = "2/5/2025",
                            FirstName = "Mohamed",
                            LastName = "BENIANE"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Models.ArticleModel", b =>
                {
                    b.HasOne("PersonalBlog.Models.AuthorModel", null)
                        .WithMany("Articles")
                        .HasForeignKey("AuthorModelId");
                });

            modelBuilder.Entity("PersonalBlog.Models.AuthorModel", b =>
                {
                    b.HasOne("PersonalBlog.Models.PersonModel", null)
                        .WithOne("Authors")
                        .HasForeignKey("PersonalBlog.Models.AuthorModel", "PersonModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBlog.Models.AuthorModel", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("PersonalBlog.Models.PersonModel", b =>
                {
                    b.Navigation("Authors")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
