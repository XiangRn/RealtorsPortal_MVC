namespace RealtorsPortalSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RealtorsPortal : DbContext
    {
        public RealtorsPortal()
            : base("name=RealtorsPortal")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<FeautureAdv> FeautureAdvs { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Mode> Modes { get; set; }
        public virtual DbSet<PhotoDetail> PhotoDetails { get; set; }
        public virtual DbSet<PrivateSeller> PrivateSellers { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<LastedNew> LastedNews { get; set; }
        public virtual DbSet<UserAdvDetail> UserAdvDetails { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Admin>()
        //        .Property(e => e.AdminAcount)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Admin>()
        //        .Property(e => e.AdminPass)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Header)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Content)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Address)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Street)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.District)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Ward)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.CityProvince)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.Photothumbnail)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.AgentAcount)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Advertisement>()
        //        .Property(e => e.SellAcount)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentAcount)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentPassword)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentAddress)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentPhone)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.AgentEmail)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Agent>()
        //        .Property(e => e.TaxCode)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Category>()
        //        .Property(e => e.CateName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<City>()
        //        .Property(e => e.CityName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<District>()
        //        .Property(e => e.DistrictName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<FeautureAdv>()
        //        .Property(e => e.Content)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<FeautureAdv>()
        //        .Property(e => e.Header)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Feedback>()
        //        .Property(e => e.Title)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Feedback>()
        //        .Property(e => e.Content)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Mode>()
        //        .Property(e => e.ModeName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PhotoDetail>()
        //        .Property(e => e.Image)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SeLLAcount)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SellPassword)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SellFullname)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SellAddress)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SellPhone)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<PrivateSeller>()
        //        .Property(e => e.SellEmail)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Street>()
        //        .Property(e => e.StreetName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.UserName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Ward>()
        //        .Property(e => e.WardName)
        //        .IsUnicode(false);
        //}
    }
}
