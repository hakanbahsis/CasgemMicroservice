﻿// <auto-generated />
using CasgemMicroservice.Services.Cargo.DataAccessLayer.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CasgemMicroservice.Services.Cargo.DataAccessLayer.Migrations
{
    [DbContext(typeof(CargoContext))]
    partial class CargoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.Property<int>("CargoDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoDetailId"), 1L, 1);

                    b.Property<int>("CargoStateId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CargoDetailId");

                    b.HasIndex("CargoStateId");

                    b.ToTable("CargoDetails");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.EntityLayer.Concrete.CargoState", b =>
                {
                    b.Property<int>("CargoStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoStateId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoStateId");

                    b.ToTable("CargoStates");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.EntityLayer.Concrete.CargoDetail", b =>
                {
                    b.HasOne("CasgemMicroservice.Services.Cargo.EntityLayer.Concrete.CargoState", "CargoState")
                        .WithMany("CargoDetails")
                        .HasForeignKey("CargoStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoState");
                });

            modelBuilder.Entity("CasgemMicroservice.Services.Cargo.EntityLayer.Concrete.CargoState", b =>
                {
                    b.Navigation("CargoDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
