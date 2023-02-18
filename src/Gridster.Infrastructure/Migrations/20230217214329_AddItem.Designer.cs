﻿// <auto-generated />
using System;
using Gridster.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gridster.Infrastructure.Migrations
{
    [DbContext(typeof(GridsterDbContext))]
    [Migration("20230217214329_AddItem")]
    partial class AddItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gridster.Core.AggregateModel.DashboardAggregate.Dashboard", b =>
                {
                    b.Property<Guid>("DashboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DashboardId");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Gridster.Core.AggregateModel.DashboardItemAggregate.DashboardItem", b =>
                {
                    b.Property<Guid>("DashboardItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DashboardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DashboardItemId");

                    b.HasIndex("DashboardId");

                    b.ToTable("DashboardItems");
                });

            modelBuilder.Entity("Gridster.Core.AggregateModel.ItemAggregate.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Gridster.Core.AggregateModel.DashboardItemAggregate.DashboardItem", b =>
                {
                    b.HasOne("Gridster.Core.AggregateModel.DashboardAggregate.Dashboard", null)
                        .WithMany("DashboardItems")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gridster.Core.AggregateModel.DashboardAggregate.Dashboard", b =>
                {
                    b.Navigation("DashboardItems");
                });
#pragma warning restore 612, 618
        }
    }
}
