// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserServiceApiV2.Data;

#nullable disable

namespace UserServiceApiV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220206013254_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserServiceApiV2.Entities.AccessRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Permission")
                        .HasColumnType("bit");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessRules");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessRuleId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccessRuleId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.Admin", b =>
                {
                    b.HasBaseType("UserServiceApiV2.Entities.Person");

                    b.Property<string>("Privilage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.User", b =>
                {
                    b.HasBaseType("UserServiceApiV2.Entities.Person");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasIndex("UserGroupId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.UserGroup", b =>
                {
                    b.HasOne("UserServiceApiV2.Entities.AccessRule", "AccessRule")
                        .WithMany()
                        .HasForeignKey("AccessRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessRule");
                });

            modelBuilder.Entity("UserServiceApiV2.Entities.User", b =>
                {
                    b.HasOne("UserServiceApiV2.Entities.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
