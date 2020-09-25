﻿// <auto-generated />
using System;
using AligatorApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AligatorApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200925020647_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AligatorApi.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("AligatorApi.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("AligatorApi.Models.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("AligatorApi.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<int?>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("IdHouse")
                        .HasColumnType("int");

                    b.Property<bool>("IsManager")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("AligatorApi.Models.PersonBill", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "BillId");

                    b.HasIndex("BillId");

                    b.ToTable("PersonBills");
                });

            modelBuilder.Entity("AligatorApi.Models.PersonTask", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("PersonTasks");
                });

            modelBuilder.Entity("AligatorApi.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<bool>("Done")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("AligatorApi.Models.Notice", b =>
                {
                    b.HasOne("AligatorApi.Models.Person", "Person")
                        .WithMany("Notices")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AligatorApi.Models.Person", b =>
                {
                    b.HasOne("AligatorApi.Models.House", "House")
                        .WithMany("People")
                        .HasForeignKey("HouseId");
                });

            modelBuilder.Entity("AligatorApi.Models.PersonBill", b =>
                {
                    b.HasOne("AligatorApi.Models.Bill", "Bill")
                        .WithMany("PersonBills")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AligatorApi.Models.Person", "Person")
                        .WithMany("PersonBills")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AligatorApi.Models.PersonTask", b =>
                {
                    b.HasOne("AligatorApi.Models.Person", "Person")
                        .WithMany("PersonTasks")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AligatorApi.Models.Task", "Task")
                        .WithMany("PersonTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}