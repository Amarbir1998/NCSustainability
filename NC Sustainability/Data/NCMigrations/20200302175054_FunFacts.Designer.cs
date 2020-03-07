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
    [Migration("20200302175054_FunFacts")]
    partial class FunFacts
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

                    b.Property<string>("EventDescription")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<byte[]>("imageContent");

                    b.Property<string>("imageFileName")
                        .HasMaxLength(100);

                    b.Property<string>("imageMimeType")
                        .HasMaxLength(256);

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

                    b.ToTable("FunFact");
                });

            modelBuilder.Entity("NCSustainability.Models.EventSubscriber", b =>
                {
                    b.Property<int>("EventCategoryID");

                    b.Property<int>("SubscriberID");

                    b.HasKey("EventCategoryID", "SubscriberID");

                    b.HasIndex("SubscriberID");

                    b.ToTable("EventSubscribers");
                });

            modelBuilder.Entity("NCSustainability.Models.FunFact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FunFactDescription")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("FunFacts");
                });

            modelBuilder.Entity("NCSustainability.Models.LikedFunfact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("FunfactID");

                    b.Property<string>("LName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FunfactID");

                    b.ToTable("LikedFunfacts");
                });

            modelBuilder.Entity("NCSustainability.Models.Subscriber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

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

            modelBuilder.Entity("NCSustainability.Models.EventSubscriber", b =>
                {
                    b.HasOne("NCSustainability.Models.EventCategory", "EventCategory")
                        .WithMany("eventSubscribers")
                        .HasForeignKey("EventCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NCSustainability.Models.Subscriber", "Subscriber")
                        .WithMany("EventSubscribers")
                        .HasForeignKey("SubscriberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NCSustainability.Models.LikedFunfact", b =>
                {
                    b.HasOne("NCSustainability.Models.FunFact", "FunFact")
                        .WithMany("LikedFunfacts")
                        .HasForeignKey("FunfactID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}