﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using clinic.Model;

#nullable disable

namespace clinic.Migrations
{
    [DbContext(typeof(MedicalClinicContext))]
    [Migration("20230423170418_EmployeeAndClientEdit")]
    partial class EmployeeAndClientEdit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("clinic.Model.Tables.Analysiscategory", b =>
                {
                    b.Property<int>("Categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("categoryid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Categoryid"));

                    b.Property<string>("Categoryname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("categoryname");

                    b.HasKey("Categoryid")
                        .HasName("analysiscategory_pkey");

                    b.ToTable("analysiscategory", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysispopularuty", b =>
                {
                    b.Property<int>("Analysispopularityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("analysispopularityid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Analysispopularityid"));

                    b.Property<int>("Analysisname")
                        .HasColumnType("integer")
                        .HasColumnName("analysisname");

                    b.Property<int>("Purchasescount")
                        .HasColumnType("integer")
                        .HasColumnName("purchasescount");

                    b.HasKey("Analysispopularityid")
                        .HasName("analysispopularuty_pkey");

                    b.HasIndex("Analysisname");

                    b.ToTable("analysispopularuty", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysisresult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Analysisresult1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("analysisresult");

                    b.Property<int>("Analysistype")
                        .HasColumnType("integer")
                        .HasColumnName("analysistype");

                    b.Property<int>("Client")
                        .HasColumnType("integer")
                        .HasColumnName("client");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time without time zone")
                        .HasColumnName("time");

                    b.HasKey("Id")
                        .HasName("analysisresult_pkey");

                    b.HasIndex("Analysistype");

                    b.HasIndex("Client");

                    b.ToTable("analysisresult", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysistype", b =>
                {
                    b.Property<int>("Analysisid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("analysisid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Analysisid"));

                    b.Property<string>("Analysistitle")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("analysistitle");

                    b.Property<int>("Category")
                        .HasColumnType("integer")
                        .HasColumnName("category");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("duration");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("Analysisid")
                        .HasName("analysistypes_pkey");

                    b.HasIndex("Category");

                    b.ToTable("analysistypes", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Client", b =>
                {
                    b.Property<int>("Clientid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("clientid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Clientid"));

                    b.Property<string>("Clientaddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("clientaddress");

                    b.Property<string>("Clientname")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)")
                        .HasColumnName("clientname");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Passwordhash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("passwordhash");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("phonenumber");

                    b.HasKey("Clientid")
                        .HasName("clients_pkey");

                    b.HasIndex(new[] { "Phonenumber" }, "clients_phonenumber_key")
                        .IsUnique();

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeName")
                        .HasColumnType("integer");

                    b.Property<int>("Office")
                        .HasColumnType("integer")
                        .HasColumnName("office");

                    b.Property<string>("Passwordhash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("passwordhash");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("phonenumber");

                    b.HasKey("Id")
                        .HasName("employees_pkey");

                    b.HasIndex("Office");

                    b.HasIndex(new[] { "Phonenumber" }, "employees_phonenumber_key")
                        .IsUnique();

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Office", b =>
                {
                    b.Property<int>("Officeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("officeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Officeid"));

                    b.Property<string>("Officeaddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("officeaddress");

                    b.HasKey("Officeid")
                        .HasName("offices_pkey");

                    b.ToTable("offices", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Analysistype")
                        .HasColumnType("integer")
                        .HasColumnName("analysistype");

                    b.Property<int>("Client")
                        .HasColumnType("integer")
                        .HasColumnName("client");

                    b.Property<int>("Office")
                        .HasColumnType("integer")
                        .HasColumnName("office");

                    b.Property<DateOnly>("Receptiondate")
                        .HasColumnType("date")
                        .HasColumnName("receptiondate");

                    b.HasKey("Id")
                        .HasName("requests_pkey");

                    b.HasIndex("Analysistype");

                    b.HasIndex("Client");

                    b.HasIndex("Office");

                    b.ToTable("requests", (string)null);
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysispopularuty", b =>
                {
                    b.HasOne("clinic.Model.Tables.Analysistype", "AnalysisnameNavigation")
                        .WithMany("Analysispopularuties")
                        .HasForeignKey("Analysisname")
                        .IsRequired()
                        .HasConstraintName("analysispopularuty_analysisname_fkey");

                    b.Navigation("AnalysisnameNavigation");
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysisresult", b =>
                {
                    b.HasOne("clinic.Model.Tables.Analysistype", "AnalysistypeNavigation")
                        .WithMany("Analysisresults")
                        .HasForeignKey("Analysistype")
                        .IsRequired()
                        .HasConstraintName("analysisresult_analysistype_fkey");

                    b.HasOne("clinic.Model.Tables.Client", "ClientNavigation")
                        .WithMany("Analysisresults")
                        .HasForeignKey("Client")
                        .IsRequired()
                        .HasConstraintName("analysisresult_client_fkey");

                    b.Navigation("AnalysistypeNavigation");

                    b.Navigation("ClientNavigation");
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysistype", b =>
                {
                    b.HasOne("clinic.Model.Tables.Analysiscategory", "CategoryNavigation")
                        .WithMany("Analysistypes")
                        .HasForeignKey("Category")
                        .IsRequired()
                        .HasConstraintName("analysistypes_category_fkey");

                    b.Navigation("CategoryNavigation");
                });

            modelBuilder.Entity("clinic.Model.Tables.Employee", b =>
                {
                    b.HasOne("clinic.Model.Tables.Office", "OfficeNavigation")
                        .WithMany("Employees")
                        .HasForeignKey("Office")
                        .IsRequired()
                        .HasConstraintName("employees_office_fkey");

                    b.Navigation("OfficeNavigation");
                });

            modelBuilder.Entity("clinic.Model.Tables.Request", b =>
                {
                    b.HasOne("clinic.Model.Tables.Analysistype", "AnalysistypeNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("Analysistype")
                        .IsRequired()
                        .HasConstraintName("requests_analysistype_fkey");

                    b.HasOne("clinic.Model.Tables.Client", "ClientNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("Client")
                        .IsRequired()
                        .HasConstraintName("requests_client_fkey");

                    b.HasOne("clinic.Model.Tables.Office", "OfficeNavigation")
                        .WithMany("Requests")
                        .HasForeignKey("Office")
                        .IsRequired()
                        .HasConstraintName("requests_office_fkey");

                    b.Navigation("AnalysistypeNavigation");

                    b.Navigation("ClientNavigation");

                    b.Navigation("OfficeNavigation");
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysiscategory", b =>
                {
                    b.Navigation("Analysistypes");
                });

            modelBuilder.Entity("clinic.Model.Tables.Analysistype", b =>
                {
                    b.Navigation("Analysispopularuties");

                    b.Navigation("Analysisresults");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("clinic.Model.Tables.Client", b =>
                {
                    b.Navigation("Analysisresults");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("clinic.Model.Tables.Office", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
