﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wings.DataAccess;

namespace Wings.Migrations {
    [DbContext (typeof (WingsContext))]
    [Migration ("20190408164818_1554742091")]
    partial class _1554742091 {
        protected override void BuildTargetModel (ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation ("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation ("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity ("Wings.Base.RBAC.Entity.User", b => {
                b.Property<int> ("Id")
                    .ValueGeneratedOnAdd ()
                    .HasColumnName ("id")
                    .HasColumnType ("int(11)");

                b.Property<string> ("Name")
                    .HasColumnName ("name")
                    .HasColumnType ("varchar(45)");

                b.Property<DateTime?> ("createTime4")
                    .HasColumnType ("datetime");

                b.Property<DateTime?> ("createTime5")
                    .HasColumnType ("datetime");

                b.HasKey ("Id");

                b.ToTable ("user");
            });
#pragma warning restore 612, 618
        }
    }
}