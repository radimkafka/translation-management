﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationManagement.Api;
using TranslationManagement.Data;

namespace TranslationManagement.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TranslationManagement.Api.Controlers.TranslatorManagementController+TranslatorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("HourlyRate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("TranslationManagement.Api.Controllers.TranslationJobController+TranslationJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalContent")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedContent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TranslationJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
