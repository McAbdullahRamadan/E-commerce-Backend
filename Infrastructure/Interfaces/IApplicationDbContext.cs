using Domain.Entities.Product;
using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<ApplicationUser> Users { get; }
        public DbSet<ApplicationRole> Roles { get; }
        public DbSet<ApplicationUserRole> UserRoles { get; }
        public DbSet<ApplicationUserClaim> UserClaims { get; }
        public DbSet<ApplicationUserToken> UserTokens { get; }
        public DbSet<ApplicationUserLogin> UserLogins { get; }
        //E-commerce
        public DbSet<Category> Categories { get; }
        public DbSet<Product> Products { get; }

        public DbSet<Photo> Photos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
