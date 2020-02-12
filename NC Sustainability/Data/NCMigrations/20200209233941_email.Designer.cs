﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NCSustainability.Data;

namespace NCSustainability.Data.NCMigrations
{
    [DbContext(typeof(NCDbContext))]
    [Migration("20200209233941_email")]
    partial class email
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NCSustainability.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Edate");

                    b.Property<int>("EventCategoryID");

                    b.Property<string>("EventDescription");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("EventCategoryID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("NCSustainability.Models.EventCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventCategoryName");

                    b.HasKey("ID");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("NCSustainability.Models.Subscriber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("subscribers");
                });

            modelBuilder.Entity("NCSustainability.ViewModels.AssignedOptionVM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Assigned");

                    b.Property<string>("DisplayText");

                    b.HasKey("ID");

                    b.ToTable("AssignedOptionVM");
                });

            modelBuilder.Entity("NCSustainability.Models.Event", b =>
                {
                    b.HasOne("NCSustainability.Models.EventCategory", "EventCategory")
                        .WithMany("Events")
                        .HasForeignKey("EventCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
