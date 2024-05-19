﻿// <auto-generated />
using System;
using API_projekt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_projekt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClassLibrary.Models.Appointment", b =>
                {
                    b.Property<int>("appointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("appointmentId"), 1L, 1);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.HasKey("appointmentId");

                    b.HasIndex("companyId");

                    b.HasIndex("customerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            appointmentId = 1,
                            EndTime = new DateTime(2024, 5, 21, 10, 15, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 21, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            companyId = 1,
                            customerId = 1
                        },
                        new
                        {
                            appointmentId = 2,
                            EndTime = new DateTime(2024, 5, 25, 12, 10, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 25, 11, 10, 0, 0, DateTimeKind.Unspecified),
                            companyId = 1,
                            customerId = 2
                        },
                        new
                        {
                            appointmentId = 3,
                            EndTime = new DateTime(2024, 5, 30, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 5, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            companyId = 2,
                            customerId = 3
                        },
                        new
                        {
                            appointmentId = 4,
                            EndTime = new DateTime(2024, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 5, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            companyId = 2,
                            customerId = 2
                        },
                        new
                        {
                            appointmentId = 5,
                            EndTime = new DateTime(2024, 6, 15, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2024, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            companyId = 2,
                            customerId = 1
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.AppointmentAudit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditId"), 1L, 1);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("appointmentId")
                        .HasColumnType("int");

                    b.Property<int?>("companyId")
                        .HasColumnType("int");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.HasKey("AuditId");

                    b.ToTable("AppointmentAudits");
                });

            modelBuilder.Entity("ClassLibrary.Models.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("companyId"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("Companys");

                    b.HasData(
                        new
                        {
                            companyId = 1,
                            Adress = "Frigatan 2",
                            Email = "Google@gmail.com",
                            Phone = "021312459",
                            companyName = "Google"
                        },
                        new
                        {
                            companyId = 2,
                            Adress = "Ängsgatan 4",
                            Email = "facebook@hotmail.com",
                            Phone = "02131249124",
                            companyName = "Facebook"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Customer", b =>
                {
                    b.Property<int>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customerId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            customerId = 1,
                            Address = "Solgatan 13",
                            Email = "anton@gmail.com",
                            FirstName = "Anton",
                            LastName = "Larsson",
                            Phone = "021302145921"
                        },
                        new
                        {
                            customerId = 2,
                            Address = "Mångatan 26",
                            Email = "alfred@gmail.com",
                            FirstName = "Alfred",
                            LastName = "Larsson",
                            Phone = "0713021421"
                        },
                        new
                        {
                            customerId = 3,
                            Address = "Storgatan 5",
                            Email = "anas@qlok.com",
                            FirstName = "Anas",
                            LastName = "Qlok",
                            Phone = "07231249213"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Appointment", b =>
                {
                    b.HasOne("ClassLibrary.Models.Company", "company")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("customer");
                });
#pragma warning restore 612, 618
        }
    }
}
