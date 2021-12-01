﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammingChallenge.Infrastructure.Persistence;

#nullable disable

namespace ProgrammingChallenge.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.ChallengeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpectedStdOut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdIn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChallengeTasks");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.ExecutionInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CpuTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Script")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stdin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsedMemory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExecutionInfos");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChallengeTaskId")
                        .HasColumnType("int");

                    b.Property<int>("ExecutionInfoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeTaskId");

                    b.HasIndex("ExecutionInfoId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.Solution", b =>
                {
                    b.HasOne("ProgrammingChallenge.Domain.Entities.ChallengeTask", "ChallengeTask")
                        .WithMany("Solutions")
                        .HasForeignKey("ChallengeTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammingChallenge.Domain.Entities.ExecutionInfo", "ExecutionInfo")
                        .WithMany()
                        .HasForeignKey("ExecutionInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammingChallenge.Domain.Entities.Player", "Player")
                        .WithMany("Solutions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChallengeTask");

                    b.Navigation("ExecutionInfo");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.ChallengeTask", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("ProgrammingChallenge.Domain.Entities.Player", b =>
                {
                    b.Navigation("Solutions");
                });
#pragma warning restore 612, 618
        }
    }
}
