using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DAL.RDS;
using MicroPOS.DAL.RDS;
using Microsoft.EntityFrameworkCore;

namespace MicroPOS.DAL
{
   public class MicroPOSDbContext : DbContext
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="MicroPOSDbContext"/> class.
      /// </summary>
      public MicroPOSDbContext() : base("name=MicroPOS")
      {
      }

      public virtual DbSet<ProductGroup> ProductGroups { get; set; }
      public virtual DbSet<Store> Stores { get; set; }
      public virtual DbSet<Product> Products { get; set; }

      public override int SaveChanges()
      {
         AddTimestamps();
         return base.SaveChanges();
      }
      private void AddTimestamps()
      {
         var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));
         foreach (var entity in entities)
         {
            if (entity.State == EntityState.Added)
            {
               ((Base)entity.Entity).CreatedDate = DateTime.UtcNow;
            }
         }
      }

      protected override void OnModelCreating(DbModelBuilder modelBuilder) => modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
   }
}
