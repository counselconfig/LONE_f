﻿// <auto-generated />
using System;
using LONE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LONE.Migrations
{
    [DbContext(typeof(LONEDbContext))]
    partial class LONEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LONE.Entities.Payment", b =>
                {
                    b.Property<string>("enquiry_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("amount_received")
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("finished")
                        .HasColumnType("bit");

                    b.Property<string>("payment_reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("request_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("session_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("transaction_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transaction_id"));

                    b.HasKey("enquiry_id");

                    b.HasIndex("request_id")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("LONE.Entities.Request", b =>
                {
                    b.Property<Guid>("request_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("agent_address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_contact_address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_contact_address_county")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("agent_town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birth_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address_county")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address_postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_address_town_city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_email2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country_of_birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("death_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("other_forename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("other_surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("requestor_agent")
                        .HasColumnType("bit");

                    b.Property<string>("subject_forename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject_surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("request_id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("LONE.Entities.Payment", b =>
                {
                    b.HasOne("LONE.Entities.Request", "Request")
                        .WithOne("Payment")
                        .HasForeignKey("LONE.Entities.Payment", "request_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("LONE.Entities.Request", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}