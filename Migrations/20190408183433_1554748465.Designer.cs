﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wings.DataAccess;

namespace Wings.Migrations
{
    [DbContext(typeof(WingsContext))]
    [Migration("20190408183433_1554748465")]
    partial class _1554748465
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Wings.Base.Common.Entity.OrderNo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("id");

                    b.ToTable("order_no");
                });

            modelBuilder.Entity("Wings.Base.Common.Entity.OssFile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.ToTable("OssFile");
                });

            modelBuilder.Entity("Wings.Base.RBAC.Entity.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("createTime4")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("createTime5")
                        .HasColumnType("datetime");

                    b.Property<int?>("headImageid");

                    b.Property<string>("name")
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("orderNoid");

                    b.HasKey("userId");

                    b.HasIndex("headImageid");

                    b.HasIndex("orderNoid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Wings.Base.RBAC.Entity.User", b =>
                {
                    b.HasOne("Wings.Base.Common.Entity.OssFile", "headImage")
                        .WithMany()
                        .HasForeignKey("headImageid");

                    b.HasOne("Wings.Base.Common.Entity.OrderNo", "orderNo")
                        .WithMany()
                        .HasForeignKey("orderNoid");
                });
#pragma warning restore 612, 618
        }
    }
}
