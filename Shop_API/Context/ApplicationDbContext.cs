using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop_API.Entities;

namespace Shop_API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Staff>? Staffs { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<GroupStaff>? GroupStaffs { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Function>? Functions { get; set; }
        public DbSet<Color>? Colors { get; set; }
        public DbSet<StorageCapacities>? StorageCapacities { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<OrderHdr>? OrderHdrs { get; set; }
        public DbSet<OrderDtl>? OrderDtls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(CharEquals), new[] { typeof(string), typeof(string) }))
                .HasName("charEquals");
        }


        [DbFunction("charEquals", "dbo")]
        public bool CharEquals(string value1, string value2) => throw new NotSupportedException("This method is for mapping only.");
        public override int SaveChanges()
        {
            //UpdateAuditEntities();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
