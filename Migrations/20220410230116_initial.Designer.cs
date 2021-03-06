// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Data;

#nullable disable

namespace Platform45_MarsRoverChallenge_Michal_Malujlo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220410230116_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Platform45_MarsRoverChallenge_Michal_Malujlo.Models.RoverModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Bearing")
                        .HasColumnType("int");

                    b.Property<string>("RoverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X_Position")
                        .HasColumnType("int");

                    b.Property<int>("Y_Position")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rovers");
                });
#pragma warning restore 612, 618
        }
    }
}
