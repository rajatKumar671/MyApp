﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student.Data;

namespace Student.Data.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20180810121436_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Student.Domain.Standard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName");

                    b.HasKey("Id");

                    b.ToTable("Standard");
                });

            modelBuilder.Entity("Student.Domain.StudentInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Branch");

                    b.Property<string>("DOB");

                    b.Property<string>("Name");

                    b.Property<int>("RollNo");

                    b.Property<int?>("StandardId");

                    b.HasKey("Id");

                    b.HasIndex("StandardId");

                    b.ToTable("studentInfos");
                });

            modelBuilder.Entity("Student.Domain.StudentInfo", b =>
                {
                    b.HasOne("Student.Domain.Standard", "Standard")
                        .WithMany()
                        .HasForeignKey("StandardId");
                });
#pragma warning restore 612, 618
        }
    }
}