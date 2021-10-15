﻿// <auto-generated />
using System;
using AutoHub.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoHub.DAL.Migrations
{
    [DbContext(typeof(AutoHubContext))]
    partial class AutoHubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoHub.DAL.Entities.Bid", b =>
                {
                    b.Property<int>("BidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BidTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("BidValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BidId");

                    b.HasIndex("LotId");

                    b.HasIndex("UserId");

                    b.ToTable("Bid");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CarColorId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int>("CarStatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("CarColorId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarStatusId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarBrand", b =>
                {
                    b.Property<int>("CarBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarBrandId");

                    b.ToTable("CarBrand");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarColor", b =>
                {
                    b.Property<int>("CarColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarColorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarColorId");

                    b.ToTable("CarColor");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelId");

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarStatus", b =>
                {
                    b.Property<int>("CarStatusId")
                        .HasColumnType("int");

                    b.Property<string>("CarStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarStatusId");

                    b.ToTable("CarStatus");

                    b.HasData(
                        new
                        {
                            CarStatusId = 1,
                            CarStatusName = "New"
                        },
                        new
                        {
                            CarStatusId = 2,
                            CarStatusName = "OnHold"
                        },
                        new
                        {
                            CarStatusId = 3,
                            CarStatusName = "ReadyForSale"
                        },
                        new
                        {
                            CarStatusId = 4,
                            CarStatusName = "UnderRepair"
                        },
                        new
                        {
                            CarStatusId = 5,
                            CarStatusName = "OnSale"
                        },
                        new
                        {
                            CarStatusId = 6,
                            CarStatusName = "Sold"
                        });
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Lot", b =>
                {
                    b.Property<int>("LotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LastBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LotStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("LotId");

                    b.HasIndex("CarId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LotStatusId");

                    b.HasIndex("WinnerId")
                        .IsUnique();

                    b.ToTable("Lot");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.LotStatus", b =>
                {
                    b.Property<int>("LotStatusId")
                        .HasColumnType("int");

                    b.Property<string>("LotStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LotStatusId");

                    b.ToTable("LotStatus");

                    b.HasData(
                        new
                        {
                            LotStatusId = 1,
                            LotStatusName = "NotStarted"
                        },
                        new
                        {
                            LotStatusId = 2,
                            LotStatusName = "InProgress"
                        },
                        new
                        {
                            LotStatusId = 3,
                            LotStatusName = "EndedUp"
                        });
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "reshetnik.nikita@gmail.com",
                            FirstName = "Nikita",
                            LastName = "Reshetnik",
                            Password = "75K3eLr+dx6JJFuJ7LwIpEpOFmwGZZkRiB84PURz6U8=",
                            Phone = "+380698632559",
                            RegistrationTime = new DateTime(2021, 10, 13, 20, 33, 32, 7, DateTimeKind.Utc).AddTicks(6162),
                            UserRoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            Email = "julia.clifford@hotmail.com",
                            FirstName = "Julia",
                            LastName = "Clifford",
                            Password = "gGm/YLoNuYebABCXGzuvBeXKptnMGFfobCfPXBgsTRU=",
                            Phone = "+380501449999",
                            RegistrationTime = new DateTime(2021, 10, 13, 20, 33, 32, 7, DateTimeKind.Utc).AddTicks(9940),
                            UserRoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            Email = "emusk@paypal.com",
                            FirstName = "Elon",
                            LastName = "Musk",
                            Password = "ZwSQald1A8FIwjNFQ8xhsITfYxHkPomsLFKFa448oWI=",
                            Phone = "+380991449999",
                            RegistrationTime = new DateTime(2021, 10, 13, 20, 33, 32, 8, DateTimeKind.Utc).AddTicks(132),
                            UserRoleId = 2
                        });
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserRoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserRoleId = 1,
                            UserRoleName = "Guest"
                        },
                        new
                        {
                            UserRoleId = 2,
                            UserRoleName = "Regular"
                        },
                        new
                        {
                            UserRoleId = 3,
                            UserRoleName = "Administrator"
                        });
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Bid", b =>
                {
                    b.HasOne("AutoHub.DAL.Entities.Lot", "Lot")
                        .WithMany("Bids")
                        .HasForeignKey("LotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.User", "User")
                        .WithMany("UserBids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Car", b =>
                {
                    b.HasOne("AutoHub.DAL.Entities.CarBrand", "CarBrand")
                        .WithMany("Cars")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.CarColor", "CarColor")
                        .WithMany("Cars")
                        .HasForeignKey("CarColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.CarStatus", "CarStatus")
                        .WithMany("Cars")
                        .HasForeignKey("CarStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");

                    b.Navigation("CarColor");

                    b.Navigation("CarModel");

                    b.Navigation("CarStatus");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Lot", b =>
                {
                    b.HasOne("AutoHub.DAL.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.User", "Creator")
                        .WithMany("UserLots")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.LotStatus", "LotStatus")
                        .WithMany("Lots")
                        .HasForeignKey("LotStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.DAL.Entities.User", "Winner")
                        .WithOne()
                        .HasForeignKey("AutoHub.DAL.Entities.Lot", "WinnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Creator");

                    b.Navigation("LotStatus");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.User", b =>
                {
                    b.HasOne("AutoHub.DAL.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarBrand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarColor", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.CarStatus", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.Lot", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.LotStatus", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.User", b =>
                {
                    b.Navigation("UserBids");

                    b.Navigation("UserLots");
                });

            modelBuilder.Entity("AutoHub.DAL.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
