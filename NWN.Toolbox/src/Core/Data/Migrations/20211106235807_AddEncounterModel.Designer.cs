﻿// <auto-generated />
using System;
using Jorteck.Toolbox;
using Jorteck.Toolbox.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jorteck.Toolbox.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20211106235807_AddEncounterModel")]
    partial class AddEncounterModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Jorteck.Toolbox.BlueprintModel", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("BlueprintData")
                        .HasColumnType("BLOB");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Type", "Name");

                    b.ToTable("BlueprintPresets");
                });

            modelBuilder.Entity("Jorteck.Toolbox.EncounterModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("EncounterPresets");
                });

            modelBuilder.Entity("Jorteck.Toolbox.EncounterModel", b =>
                {
                    b.OwnsMany("Jorteck.Toolbox.EncounterModel+EncounterSpawn", "Creatures", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<byte[]>("CreatureData")
                                .HasColumnType("BLOB");

                            b1.Property<string>("EncounterName")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<float>("LocalOffsetX")
                                .HasColumnType("REAL");

                            b1.Property<float>("LocalOffsetY")
                                .HasColumnType("REAL");

                            b1.Property<float>("LocalOffsetZ")
                                .HasColumnType("REAL");

                            b1.Property<float>("RotationX")
                                .HasColumnType("REAL");

                            b1.Property<float>("RotationY")
                                .HasColumnType("REAL");

                            b1.Property<float>("RotationZ")
                                .HasColumnType("REAL");

                            b1.HasKey("Id");

                            b1.HasIndex("EncounterName");

                            b1.ToTable("EncounterSpawn");

                            b1.WithOwner("Encounter")
                                .HasForeignKey("EncounterName");

                            b1.Navigation("Encounter");
                        });

                    b.Navigation("Creatures");
                });
#pragma warning restore 612, 618
        }
    }
}
