﻿// <auto-generated />
using System;
using AplicationTestMacroPay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicationTestMacroPay.Migrations
{
    [DbContext(typeof(testContext))]
    [Migration("20220719044204_addKeyBooks")]
    partial class addKeyBooks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("AplicationTestMacroPay.Models.Book", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Author")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("author");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("title");

                    b.Property<int?>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("books");
                });

            modelBuilder.Entity("AplicationTestMacroPay.Models.Rating", b =>
                {
                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int?>("Rating1")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<DateTime?>("RatingDate")
                        .HasColumnType("date")
                        .HasColumnName("rating_date");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int")
                        .HasColumnName("reviewer_id");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("AplicationTestMacroPay.Models.Reviewer", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.ToTable("reviewers");
                });
#pragma warning restore 612, 618
        }
    }
}
