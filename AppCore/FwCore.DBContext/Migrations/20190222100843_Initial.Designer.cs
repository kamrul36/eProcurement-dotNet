﻿// <auto-generated />
using System;
using FwCore.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FwCore.DBContext.Migrations
{
    [DbContext(typeof(AppDataDbContext))]
    [Migration("20190222100843_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FwCore.DBContext.Model.ProductList", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discription")
                        .IsRequired();

                    b.Property<string>("ProductCategory")
                        .IsRequired();

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<string>("ProductTitle")
                        .IsRequired();

                    b.Property<double>("Quentity");

                    b.Property<int?>("SubmissionSId");

                    b.Property<int?>("SubmitId");

                    b.Property<int>("TenderID");

                    b.HasKey("ProductId");

                    b.HasIndex("SubmissionSId");

                    b.HasIndex("SubmitId");

                    b.HasIndex("TenderID");

                    b.ToTable("ProductLists");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CompanyCategory")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProductSpecification")
                        .IsRequired();

                    b.Property<string>("TradeLicenseNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusType")
                        .IsRequired();

                    b.HasKey("StatusID");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Submission", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("TenderID");

                    b.Property<double>("quentity");

                    b.HasKey("SId");

                    b.HasIndex("TenderID");

                    b.ToTable("submissions");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Submit", b =>
                {
                    b.Property<int>("SubmitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GoodsName")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("TenderID");

                    b.Property<double>("quentity");

                    b.HasKey("SubmitId");

                    b.HasIndex("TenderID")
                        .IsUnique();

                    b.ToTable("Submit");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.TenderCategory", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryType")
                        .IsRequired();

                    b.HasKey("CatId");

                    b.ToTable("tenderCategories");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.TenderType", b =>
                {
                    b.Property<int>("ProcurementId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProcurementType")
                        .IsRequired();

                    b.HasKey("ProcurementId");

                    b.ToTable("tenderTypes");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Tenders", b =>
                {
                    b.Property<int>("TenderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowReSubmission");

                    b.Property<DateTime>("BeginDate");

                    b.Property<DateTime>("BidClosingDate");

                    b.Property<DateTime>("BidOpeningDate");

                    b.Property<int>("CatId");

                    b.Property<string>("ContactType")
                        .IsRequired();

                    b.Property<string>("DocumentUpdload")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("PaymentType");

                    b.Property<int?>("ProcurementId");

                    b.Property<int?>("StatusID");

                    b.Property<string>("TenderRefNumber")
                        .IsRequired();

                    b.Property<string>("TenderTitle")
                        .IsRequired();

                    b.HasKey("TenderID");

                    b.HasIndex("CatId")
                        .IsUnique();

                    b.HasIndex("ProcurementId")
                        .IsUnique()
                        .HasFilter("[ProcurementId] IS NOT NULL");

                    b.HasIndex("StatusID")
                        .IsUnique()
                        .HasFilter("[StatusID] IS NOT NULL");

                    b.ToTable("tenders");
                });

            modelBuilder.Entity("FwCore.DBContext.Model.ProductList", b =>
                {
                    b.HasOne("FwCore.DBContext.Model.Submission", "Submission")
                        .WithMany("productList")
                        .HasForeignKey("SubmissionSId");

                    b.HasOne("FwCore.DBContext.Model.Submit")
                        .WithMany("productList")
                        .HasForeignKey("SubmitId");

                    b.HasOne("FwCore.DBContext.Model.Tenders", "Tender")
                        .WithMany("productList")
                        .HasForeignKey("TenderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Submission", b =>
                {
                    b.HasOne("FwCore.DBContext.Model.Tenders", "tender")
                        .WithMany()
                        .HasForeignKey("TenderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Submit", b =>
                {
                    b.HasOne("FwCore.DBContext.Model.Tenders", "tender")
                        .WithOne("Submit")
                        .HasForeignKey("FwCore.DBContext.Model.Submit", "TenderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FwCore.DBContext.Model.Tenders", b =>
                {
                    b.HasOne("FwCore.DBContext.Model.TenderCategory", "tenderCategory")
                        .WithOne("tender")
                        .HasForeignKey("FwCore.DBContext.Model.Tenders", "CatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FwCore.DBContext.Model.TenderType", "tenderType")
                        .WithOne("tender")
                        .HasForeignKey("FwCore.DBContext.Model.Tenders", "ProcurementId");

                    b.HasOne("FwCore.DBContext.Model.Status", "status")
                        .WithOne("tender")
                        .HasForeignKey("FwCore.DBContext.Model.Tenders", "StatusID");
                });
#pragma warning restore 612, 618
        }
    }
}
