using FwCore.DBContext.Model;
using FwCore.DBContext.Submits;
using Microsoft.EntityFrameworkCore;
using System;



namespace FwCore.DBContext
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> Options) : base(Options) { }

        // All DbSet...
        //public DbSet<Category> Category { get; set; }

        public DbSet<Tenders> tenders { get; set; }

        public DbSet<ProductList> ProductLists { get; set; }

        public DbSet<Submission> submissions { get; set; }

        public DbSet<Status> statuses { get; set; }

        public DbSet<TenderType> tenderTypes { get; set; }

        public DbSet<TenderCategory> tenderCategories { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Submit> submits { get; set; }

        public DbSet<Goods> goods { get; set; }

        public DbSet<TenderProduct> tenderProducts { get; set; }

        public DbSet<NewGood> newGoods { get; set; }

        public DbSet<SubmitGood> submitGoods { get; set; }

        public DbSet<TenderFile> TenderFiles { get; set; }


    }

 

}
