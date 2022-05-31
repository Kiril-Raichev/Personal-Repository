﻿// <auto-generated />
using System;
using Forum1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220524200157_IformFile")]
    partial class IformFile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum1.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Forum1.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(8192)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Trip to Burgas",
                            Title = "Vacation",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Trip to Varna",
                            Title = "Vacation2",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "Trip to Sozopol",
                            Title = "Vacation3",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Forum1.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostReactions");
                });

            modelBuilder.Entity("Forum1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ivan_todorov@yahoo.com",
                            FirstName = "Ivan",
                            LastName = "Todorov",
                            Role = 0,
                            Username = "Ivancho"
                        },
                        new
                        {
                            Id = 2,
                            Email = "peter_shulev@yahoo.com",
                            FirstName = "Peter",
                            LastName = "Shulev",
                            Role = 1,
                            Username = "Petercho"
                        },
                        new
                        {
                            Id = 3,
                            Email = "stoimen_Petrov@google.com",
                            FirstName = "Stoimen",
                            LastName = "Petrov",
                            Role = 1,
                            Username = "Stoimencho"
                        },
                        new
                        {
                            Id = 4,
                            Email = "georgi_penev@yahoo.com",
                            FirstName = "Georgi",
                            LastName = "Penev",
                            Role = 0,
                            Username = "Gosheto"
                        },
                        new
                        {
                            Id = 5,
                            Email = "todor_dragunov@yahoo.com",
                            FirstName = "Todor",
                            LastName = "Dragunov",
                            Role = 1,
                            Username = "Tosheto"
                        },
                        new
                        {
                            Id = 6,
                            Email = "dancho_vazov@google.com",
                            FirstName = "Dancho",
                            LastName = "Vazov",
                            Role = 1,
                            Username = "Daneto"
                        });
                });

            modelBuilder.Entity("Forum1.Models.Comment", b =>
                {
                    b.HasOne("Forum1.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Forum1.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.Post", b =>
                {
                    b.HasOne("Forum1.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.Reaction", b =>
                {
                    b.HasOne("Forum1.Models.Comment", null)
                        .WithMany("PostReactions")
                        .HasForeignKey("CommentId");

                    b.HasOne("Forum1.Models.Post", "Post")
                        .WithMany("PostReactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Forum1.Models.User", "User")
                        .WithMany("PostReactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.Comment", b =>
                {
                    b.Navigation("PostReactions");
                });

            modelBuilder.Entity("Forum1.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostReactions");
                });

            modelBuilder.Entity("Forum1.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostReactions");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
