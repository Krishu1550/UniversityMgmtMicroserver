﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseAPI.Migrations
{
    [DbContext(typeof(CourseDbContext))]
    [Migration("20230516033719_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassRoomId"));

                    b.Property<string>("ClassroomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.HasKey("ClassRoomId");

                    b.HasIndex("DayId");

                    b.ToTable("ClassRooms");

                    b.HasData(
                        new
                        {
                            ClassRoomId = 1,
                            ClassroomName = "A101",
                            DayId = 1
                        },
                        new
                        {
                            ClassRoomId = 2,
                            ClassroomName = "A102",
                            DayId = 1
                        },
                        new
                        {
                            ClassRoomId = 3,
                            ClassroomName = "A101",
                            DayId = 2
                        },
                        new
                        {
                            ClassRoomId = 4,
                            ClassroomName = "A102",
                            DayId = 2
                        },
                        new
                        {
                            ClassRoomId = 5,
                            ClassroomName = "A101",
                            DayId = 3
                        },
                        new
                        {
                            ClassRoomId = 6,
                            ClassroomName = "A102",
                            DayId = 3
                        },
                        new
                        {
                            ClassRoomId = 7,
                            ClassroomName = "A101",
                            DayId = 4
                        },
                        new
                        {
                            ClassRoomId = 8,
                            ClassroomName = "A102",
                            DayId = 4
                        },
                        new
                        {
                            ClassRoomId = 9,
                            ClassroomName = "A101",
                            DayId = 5
                        },
                        new
                        {
                            ClassRoomId = 10,
                            ClassroomName = "A102",
                            DayId = 5
                        });
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("AssigmentFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfClassPerWeek")
                        .HasColumnType("int");

                    b.Property<int>("NumOfSlot")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayId"));

                    b.Property<int>("DayNum")
                        .HasColumnType("int");

                    b.Property<int>("TimeTableId")
                        .HasColumnType("int");

                    b.HasKey("DayId");

                    b.HasIndex("TimeTableId");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            DayId = 1,
                            DayNum = 1,
                            TimeTableId = 1
                        },
                        new
                        {
                            DayId = 2,
                            DayNum = 2,
                            TimeTableId = 1
                        },
                        new
                        {
                            DayId = 3,
                            DayNum = 3,
                            TimeTableId = 1
                        },
                        new
                        {
                            DayId = 4,
                            DayNum = 4,
                            TimeTableId = 1
                        },
                        new
                        {
                            DayId = 5,
                            DayNum = 5,
                            TimeTableId = 1
                        });
                });

            modelBuilder.Entity("Slot", b =>
                {
                    b.Property<int>("SlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotID"));

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("SlotNum")
                        .HasColumnType("int");

                    b.HasKey("SlotID");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("CourseId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TimeTable", b =>
                {
                    b.Property<int>("TimeTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeTableId"));

                    b.Property<string>("TimeTableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeTableId");

                    b.ToTable("TimeTables");

                    b.HasData(
                        new
                        {
                            TimeTableId = 1,
                            TimeTableName = "1st semester"
                        });
                });

            modelBuilder.Entity("ClassRoom", b =>
                {
                    b.HasOne("Day", "Day")
                        .WithMany("ClassRooms")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.HasOne("Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Day", b =>
                {
                    b.HasOne("TimeTable", "TimeTable")
                        .WithMany("Days")
                        .HasForeignKey("TimeTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeTable");
                });

            modelBuilder.Entity("Slot", b =>
                {
                    b.HasOne("ClassRoom", "ClassRoom")
                        .WithMany("Slots")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Course", "Courses")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ClassRoom", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("Day", b =>
                {
                    b.Navigation("ClassRooms");
                });

            modelBuilder.Entity("Teacher", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("TimeTable", b =>
                {
                    b.Navigation("Days");
                });
#pragma warning restore 612, 618
        }
    }
}