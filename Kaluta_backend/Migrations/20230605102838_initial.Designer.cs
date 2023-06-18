﻿// <auto-generated />
using Kaluta_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kaluta_backend.Migrations
{
    [DbContext(typeof(universityContext))]
    [Migration("20230605102838_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Kaluta_backend.Models.group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("universityid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("universityid");

                    b.ToTable("group");
                });

            modelBuilder.Entity("Kaluta_backend.Models.student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("groupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("groupId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("Kaluta_backend.Models.university", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("university");
                });

            modelBuilder.Entity("Kaluta_backend.Models.group", b =>
                {
                    b.HasOne("Kaluta_backend.Models.university", "university")
                        .WithMany("group")
                        .HasForeignKey("universityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("university");
                });

            modelBuilder.Entity("Kaluta_backend.Models.student", b =>
                {
                    b.HasOne("Kaluta_backend.Models.group", "group")
                        .WithMany("students")
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group");
                });

            modelBuilder.Entity("Kaluta_backend.Models.group", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("Kaluta_backend.Models.university", b =>
                {
                    b.Navigation("group");
                });
#pragma warning restore 612, 618
        }
    }
}
