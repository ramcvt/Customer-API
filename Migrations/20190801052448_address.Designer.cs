﻿// <auto-generated />
using CustomerIdentityAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerIdentityAPI.Migrations
{
    [DbContext(typeof(CustomerInfoContext))]
    [Migration("20190801052448_address")]
    partial class address
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerIdentityAPI.Models.CustomerAddress", b =>
                {
                    b.Property<string>("Phonenumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Pincode");

                    b.HasKey("Phonenumber");

                    b.ToTable("custaddress");
                });

            modelBuilder.Entity("CustomerIdentityAPI.Models.CustomerInfo", b =>
                {
                    b.Property<string>("Phonenumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Phonenumber");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
