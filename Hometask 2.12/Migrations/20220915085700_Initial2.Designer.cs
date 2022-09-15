﻿// <auto-generated />
using Hometask_2._7;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hometask_2._12.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    [Migration("20220915085700_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hometask_2._7.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 25,
                            FullName = "Jorja Smith",
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 2,
                            Age = 33,
                            FullName = "Adele Adkins",
                            Gender = "Female"
                        },
                        new
                        {
                            Id = 3,
                            Age = 41,
                            FullName = "Phillip Anderson",
                            Gender = "Male"
                        });
                });

            modelBuilder.Entity("Hometask_2._7.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            ClientId = 1,
                            Date = "09/07/2022",
                            Price = 0,
                            Time = "09:30",
                            Topic = "Work Meeting"
                        },
                        new
                        {
                            Id = 10,
                            ClientId = 1,
                            Date = "09/07/2022",
                            Price = 0,
                            Time = "12:10",
                            Topic = "Talking"
                        },
                        new
                        {
                            Id = 11,
                            ClientId = 1,
                            Date = "09/07/2022",
                            Price = 0,
                            Time = "16:00",
                            Topic = "English Practice"
                        },
                        new
                        {
                            Id = 12,
                            ClientId = 1,
                            Date = "09/07/2022",
                            Price = 0,
                            Time = "20:00",
                            Topic = "Family Call"
                        },
                        new
                        {
                            Id = 13,
                            ClientId = 2,
                            Date = "10/01/2022",
                            Price = 0,
                            Time = "09:30",
                            Topic = "Rehearsal"
                        },
                        new
                        {
                            Id = 14,
                            ClientId = 2,
                            Date = "09/07/2022",
                            Price = 0,
                            Time = "12:10",
                            Topic = "Walking"
                        },
                        new
                        {
                            Id = 15,
                            ClientId = 2,
                            Date = "01/01/2022",
                            Price = 0,
                            Time = "21:00",
                            Topic = "Relax"
                        },
                        new
                        {
                            Id = 16,
                            ClientId = 3,
                            Date = "02/04/2022",
                            Price = 0,
                            Time = "13:50",
                            Topic = "Lecture Time"
                        },
                        new
                        {
                            Id = 17,
                            ClientId = 3,
                            Date = "04/09/2022",
                            Price = 0,
                            Time = "09:00",
                            Topic = "Vacation"
                        });
                });

            modelBuilder.Entity("Hometask_2._7.Entities.Schedule", b =>
                {
                    b.HasOne("Hometask_2._7.Entities.Client", "Client")
                        .WithMany("Schedules")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Hometask_2._7.Entities.Client", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}