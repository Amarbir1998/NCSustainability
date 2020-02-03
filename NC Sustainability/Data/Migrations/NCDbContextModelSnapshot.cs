﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NC_Sustainability.Data;

namespace NC_Sustainability.Migrations
{
    [DbContext(typeof(NCDbContext))]
    partial class NCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NC_Sustainability.Models.Event", b =>
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

            modelBuilder.Entity("NC_Sustainability.Models.EventCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventCategoryName");

                    b.HasKey("ID");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("NC_Sustainability.Models.Event", b =>
                {
                    b.HasOne("NC_Sustainability.Models.EventCategory", "EventCategory")
                        .WithMany("Events")
                        .HasForeignKey("EventCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}