﻿// <auto-generated />
using System;
using DemoDbMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DemoDbMigrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("myapp")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DemoDbMigrations.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("students", "myapp");
                });

            modelBuilder.Entity("DemoDbMigrations.Models.StudentSubject", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("subject_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("last_modified_date");

                    b.Property<float>("Mark")
                        .HasColumnType("real")
                        .HasColumnName("mark");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("student_subjects", "myapp");
                });

            modelBuilder.Entity("DemoDbMigrations.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("subjects", "myapp");
                });

            modelBuilder.Entity("DemoDbMigrations.Models.StudentSubject", b =>
                {
                    b.HasOne("DemoDbMigrations.Models.Student", "Student")
                        .WithMany("Subjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoDbMigrations.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DemoDbMigrations.Models.Student", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
