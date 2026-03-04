using Application.Common.interfaces;
using Domain.Common;
using Domain.Entities.Product;
using Domain.Entities.System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // Identity & System
        public override DbSet<ApplicationUser> Users => Set<ApplicationUser>();
        public override DbSet<ApplicationRole> Roles => Set<ApplicationRole>();
        public override DbSet<ApplicationUserRole> UserRoles => Set<ApplicationUserRole>();
        public override DbSet<ApplicationUserClaim> UserClaims => Set<ApplicationUserClaim>();
        public override DbSet<ApplicationUserToken> UserTokens => Set<ApplicationUserToken>();
        public override DbSet<ApplicationUserLogin> UserLogins => Set<ApplicationUserLogin>();
        public DbSet<ApplicationUserPasswordHistory> UserPasswordHistories => Set<ApplicationUserPasswordHistory>();
        public override DbSet<ApplicationRoleClaim> RoleClaims => Set<ApplicationRoleClaim>();
        // E-Commerce 
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<WishlistItem> WishlistItems { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseAuditableEntity<Guid>).IsAssignableFrom(e.ClrType)))
            {
                var entity = modelBuilder.Entity(entityType.ClrType);

                if (entityType.ClrType.GetProperty("CreatedByUser") != null)
                    entity.Ignore("CreatedByUser");

                if (entityType.ClrType.GetProperty("LastModifiedByUser") != null)
                    entity.Ignore("LastModifiedByUser");
            }

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
                userRole.HasOne(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ApplicationUserClaim>(userClaim =>
            {
                userClaim.HasOne(uc => uc.User)
                    .WithMany(u => u.Claims)
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ApplicationRoleClaim>(roleClaim =>
            {
                roleClaim.HasOne(rc => rc.Role)
                    .WithMany(r => r.RoleClaims)
                    .HasForeignKey(rc => rc.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ApplicationUserLogin>(userLogin =>
            {
                userLogin.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                userLogin.HasOne(l => l.User)
                    .WithMany(u => u.Logins)
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ApplicationUserToken>(userToken =>
            {
                userToken.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                userToken.HasOne(t => t.User)
                    .WithMany(u => u.Tokens)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Photos)
                .WithOne(ph => ph.Product)
                .HasForeignKey(ph => ph.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>()
                .HasIndex(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.User)
                .WithMany(u => u.WishlistItems)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishlistItem>()
                .HasIndex(w => new { w.UserId, w.ProductId })
                .IsUnique();

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasIndex(r => new { r.UserId, r.ProductId })
                .IsUnique();

            modelBuilder.Entity<Review>()
                .HasIndex(r => r.ProductId);


            modelBuilder.Entity<ApplicationRole>()
                .Ignore(r => r.Translations);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }

    }
}
