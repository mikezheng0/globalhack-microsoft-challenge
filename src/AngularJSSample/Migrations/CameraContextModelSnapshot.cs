using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AngularJSSample.Models;

namespace AngularJSSample.Migrations
{
    [DbContext(typeof(CameraContext))]
    partial class CameraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularJSSample.Models.Cordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Height");

                    b.Property<int>("InteractionId");

                    b.Property<int>("Weight");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId")
                        .IsUnique();

                    b.ToTable("Cordinates");
                });

            modelBuilder.Entity("AngularJSSample.Models.Emotions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Anger");

                    b.Property<float>("Contempt");

                    b.Property<float>("Disguest");

                    b.Property<float>("Fear");

                    b.Property<float>("Happiness");

                    b.Property<int>("InteractionId");

                    b.Property<float>("Nuetral");

                    b.Property<float>("Sadness");

                    b.Property<float>("Suprise");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId")
                        .IsUnique();

                    b.ToTable("Emotions");
                });

            modelBuilder.Entity("AngularJSSample.Models.Interaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<byte[]>("Image");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Interaction");
                });

            modelBuilder.Entity("AngularJSSample.Models.Cordinates", b =>
                {
                    b.HasOne("AngularJSSample.Models.Interaction", "Interaction")
                        .WithOne("Cordinates")
                        .HasForeignKey("AngularJSSample.Models.Cordinates", "InteractionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AngularJSSample.Models.Emotions", b =>
                {
                    b.HasOne("AngularJSSample.Models.Interaction", "Interaction")
                        .WithOne("Emotions")
                        .HasForeignKey("AngularJSSample.Models.Emotions", "InteractionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
