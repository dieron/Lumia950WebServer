﻿// <auto-generated />
using System;
using MDGriphe.Experiments.Lumia950.WebHost.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MDGriphe.Experiments.Lumia950.WebHost.Migrations
{
    [DbContext(typeof(VisitorsDbContext))]
    partial class VisitorsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("MDGriphe.Experiments.Lumia950.WebHost.Core.Data.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Headers")
                        .HasColumnType("TEXT");

                    b.Property<string>("IP")
                        .HasColumnType("TEXT")
                        .HasMaxLength(15);

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("Query")
                        .HasColumnType("TEXT");

                    b.Property<string>("VisitorId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Created");

                    b.ToTable("Visit","dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
