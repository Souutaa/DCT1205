﻿// <auto-generated />
using System;
using DCT1205.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DCT1205.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DCT1205.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalInsuranceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudentLoan")
                        .HasColumnType("int");

                    b.Property<int>("UnionMember")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("DCT1205.Entity.PaymentRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ContractualEarnings")
                        .HasColumnType("money");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("HourlyRated")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HourlyWorked")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("NIC")
                        .HasColumnType("money");

                    b.Property<decimal>("NetPayment")
                        .HasColumnType("money");

                    b.Property<string>("NiNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OvertimeEarnings")
                        .HasColumnType("money");

                    b.Property<decimal>("OvertimeHours")
                        .HasColumnType("money");

                    b.Property<DateTime>("PayDated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PayMonth")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SLC")
                        .HasColumnType("money");

                    b.Property<decimal>("Tax")
                        .HasColumnType("money");

                    b.Property<string>("TaxCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxYearId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalsDeductions")
                        .HasColumnType("money");

                    b.Property<decimal>("TotalsEarnings")
                        .HasColumnType("money");

                    b.Property<decimal>("UnionFees")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TaxYearId");

                    b.ToTable("PaymentRecord");
                });

            modelBuilder.Entity("DCT1205.Entity.TaxYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("YearOfTax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaxYear");
                });

            modelBuilder.Entity("DCT1205.Entity.PaymentRecord", b =>
                {
                    b.HasOne("DCT1205.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DCT1205.Entity.TaxYear", "TaxYear")
                        .WithMany()
                        .HasForeignKey("TaxYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TaxYear");
                });
#pragma warning restore 612, 618
        }
    }
}
