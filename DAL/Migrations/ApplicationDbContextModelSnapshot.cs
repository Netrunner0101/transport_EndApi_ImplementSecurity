﻿// <auto-generated />
using System;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerModelDalDeliveryModelDal", b =>
                {
                    b.Property<int>("customersid_customer")
                        .HasColumnType("int");

                    b.Property<int>("deliveriesid_delivery")
                        .HasColumnType("int");

                    b.HasKey("customersid_customer", "deliveriesid_delivery");

                    b.HasIndex("deliveriesid_delivery");

                    b.ToTable("CustomerModelDalDeliveryModelDal");
                });

            modelBuilder.Entity("DAL.models.CustomerModelDal", b =>
                {
                    b.Property<int>("id_customer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_customer"), 1L, 1);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_customer");

                    b.ToTable("customer");

                    b.HasData(
                        new
                        {
                            id_customer = 1,
                            adress = "rue de Tatoinne",
                            email = "obi@gmail.com",
                            name = "obiwan",
                            phoneNumber = "045823232",
                            vat = "68793"
                        },
                        new
                        {
                            id_customer = 2,
                            adress = "rue de Coruscant",
                            email = "anakin@gmail.com",
                            name = "anaki",
                            phoneNumber = "04598382832",
                            vat = "943249"
                        });
                });

            modelBuilder.Entity("DAL.models.DeliveryModelDal", b =>
                {
                    b.Property<int>("id_delivery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_delivery"), 1L, 1);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dateDelivery")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dateTransfert")
                        .HasColumnType("datetime2");

                    b.Property<string>("numeroDelivery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("weight")
                        .HasColumnType("int");

                    b.HasKey("id_delivery");

                    b.ToTable("delivery");

                    b.HasData(
                        new
                        {
                            id_delivery = 1,
                            adress = "Rue des amazon",
                            dateDelivery = new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dateTransfert = new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            numeroDelivery = "ZIH313213",
                            remarks = "have the customs",
                            weight = 968
                        },
                        new
                        {
                            id_delivery = 2,
                            adress = "Rue des BPOST",
                            dateDelivery = new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dateTransfert = new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            numeroDelivery = "FEDEX02133",
                            remarks = "All are packet",
                            weight = 563
                        });
                });

            modelBuilder.Entity("DAL.models.DriverModelDal", b =>
                {
                    b.Property<int>("id_drive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_drive"), 1L, 1);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_drive");

                    b.ToTable("driver");

                    b.HasData(
                        new
                        {
                            id_drive = 1,
                            email = "alphonso@sctrans.com",
                            name = "Alphonso",
                            phoneNumber = "06323156"
                        },
                        new
                        {
                            id_drive = 2,
                            email = "Karl@gemini.com",
                            name = "Karl",
                            phoneNumber = "09283921"
                        });
                });

            modelBuilder.Entity("DAL.models.TransporterModelDal", b =>
                {
                    b.Property<int>("id_transporter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_transporter"), 1L, 1);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_transporter");

                    b.ToTable("transporter");

                    b.HasData(
                        new
                        {
                            id_transporter = 1,
                            adress = "rue des alouettes ",
                            email = "info@sctrans.com",
                            name = "sctrans",
                            phoneNumber = "06273321"
                        },
                        new
                        {
                            id_transporter = 2,
                            adress = "rue des avions ",
                            email = "info@geminitransport.com",
                            name = "geminitransport",
                            phoneNumber = "06982313"
                        });
                });

            modelBuilder.Entity("DAL.models.UserDal", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUser");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DeliveryModelDalTransporterModelDal", b =>
                {
                    b.Property<int>("deliveriesid_delivery")
                        .HasColumnType("int");

                    b.Property<int>("transportersid_transporter")
                        .HasColumnType("int");

                    b.HasKey("deliveriesid_delivery", "transportersid_transporter");

                    b.HasIndex("transportersid_transporter");

                    b.ToTable("DeliveryModelDalTransporterModelDal");
                });

            modelBuilder.Entity("DriverModelDalTransporterModelDal", b =>
                {
                    b.Property<int>("driversid_drive")
                        .HasColumnType("int");

                    b.Property<int>("transportersid_transporter")
                        .HasColumnType("int");

                    b.HasKey("driversid_drive", "transportersid_transporter");

                    b.HasIndex("transportersid_transporter");

                    b.ToTable("DriverModelDalTransporterModelDal");
                });

            modelBuilder.Entity("CustomerModelDalDeliveryModelDal", b =>
                {
                    b.HasOne("DAL.models.CustomerModelDal", null)
                        .WithMany()
                        .HasForeignKey("customersid_customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.models.DeliveryModelDal", null)
                        .WithMany()
                        .HasForeignKey("deliveriesid_delivery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryModelDalTransporterModelDal", b =>
                {
                    b.HasOne("DAL.models.DeliveryModelDal", null)
                        .WithMany()
                        .HasForeignKey("deliveriesid_delivery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.models.TransporterModelDal", null)
                        .WithMany()
                        .HasForeignKey("transportersid_transporter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DriverModelDalTransporterModelDal", b =>
                {
                    b.HasOne("DAL.models.DriverModelDal", null)
                        .WithMany()
                        .HasForeignKey("driversid_drive")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.models.TransporterModelDal", null)
                        .WithMany()
                        .HasForeignKey("transportersid_transporter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
