using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AngularJSSample.Models;

namespace AngularJSSample.Migrations
{
    [DbContext(typeof(CameraContext))]
    [Migration("20170625080150_SurpriseMigration")]
    partial class SurpriseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AngularJSSample.Models.Interaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Anger");

                    b.Property<float>("Contempt");

                    b.Property<float>("Disguest");

                    b.Property<float>("Fear");

                    b.Property<float>("Happiness");

                    b.Property<int>("Height");

                    b.Property<byte[]>("Image");

                    b.Property<float>("Nuetral");

                    b.Property<float>("Sadness");

                    b.Property<float>("Surprise");

                    b.Property<DateTime>("Time");

                    b.Property<int>("Weight");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id");

                    b.ToTable("Interaction");
                });
        }
    }
}
