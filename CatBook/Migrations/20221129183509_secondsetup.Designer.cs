﻿// <auto-generated />
using System;
using CatBook.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatBook.Migrations
{
    [DbContext(typeof(catBookDbContext))]
    [Migration("20221129183509_secondsetup")]
    partial class secondsetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CatBook.Areas.Identity.Data.CatBookUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CatBookUser");
                });

            modelBuilder.Entity("catbook.Models.cat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("about")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("neutered")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("vaccinated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vaccinationbook")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("cats");
                });

            modelBuilder.Entity("catbook.Models.catTrait", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("catId")
                        .HasColumnType("int");

                    b.Property<int>("traitId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("catId");

                    b.HasIndex("traitId");

                    b.ToTable("catTraits");
                });

            modelBuilder.Entity("catbook.Models.request", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("catId")
                        .HasColumnType("int");

                    b.Property<string>("contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("catId");

                    b.HasIndex("senderUserId");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("catbook.Models.trait", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("traits");
                });

            modelBuilder.Entity("catbook.Models.cat", b =>
                {
                    b.HasOne("CatBook.Areas.Identity.Data.CatBookUser", "CatBookUser")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("CatBookUser");
                });

            modelBuilder.Entity("catbook.Models.catTrait", b =>
                {
                    b.HasOne("catbook.Models.cat", "cat")
                        .WithMany("catTtraits")
                        .HasForeignKey("catId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("catbook.Models.trait", "trait")
                        .WithMany()
                        .HasForeignKey("traitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cat");

                    b.Navigation("trait");
                });

            modelBuilder.Entity("catbook.Models.request", b =>
                {
                    b.HasOne("catbook.Models.cat", "requestedCat")
                        .WithMany("receivedRequests")
                        .HasForeignKey("catId")
                        .IsRequired();

                    b.HasOne("CatBook.Areas.Identity.Data.CatBookUser", "senderUser")
                        .WithMany()
                        .HasForeignKey("senderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("requestedCat");

                    b.Navigation("senderUser");
                });

            modelBuilder.Entity("catbook.Models.cat", b =>
                {
                    b.Navigation("catTtraits");

                    b.Navigation("receivedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
