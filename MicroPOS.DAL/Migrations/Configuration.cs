using System.Collections.Generic;
using MicroPOS.DAL.RDS;

namespace MicroPOS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MicroPOSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MicroPOSDbContext context)
        {
            
           var mainGroup1 = context.ProductGroups.Add(new ProductGroup { Name = "Phones", ParentId = null, CreatedDate = DateTime.Now });
           context.SaveChanges();

           context.ProductGroups.Add(new ProductGroup { Name = "Samsung", ParentId = mainGroup1.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "Iphone", ParentId = mainGroup1.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "Nokia", ParentId = mainGroup1.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "Siemens", ParentId = mainGroup1.Id, CreatedDate = DateTime.Now });

           var mainGroup2 = context.ProductGroups.Add(new ProductGroup { Name = "Laptops", ParentId = null, CreatedDate = DateTime.Now });
           context.SaveChanges();

           context.ProductGroups.Add(new ProductGroup { Name = "IBM", ParentId = mainGroup2.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "MSI", ParentId = mainGroup2.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "HP", ParentId = mainGroup2.Id, CreatedDate = DateTime.Now });
           context.ProductGroups.Add(new ProductGroup { Name = "DELL", ParentId = mainGroup2.Id, CreatedDate = DateTime.Now });


           var stores = new List<Store>
           {
              new Store {Name = "Apple Store"},
              new Store {Name = "LaptopId "},
              new Store {Name = "Electronics "},
           };

           context.Stores.AddRange(stores);

        }
   }
}
