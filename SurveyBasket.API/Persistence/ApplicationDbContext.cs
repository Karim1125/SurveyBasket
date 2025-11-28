using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;

namespace SurveyBasket.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : 
    IdentityDbContext<ApplicationUser>(options)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedById = currentUserId; 
            }
            else if(entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedById = currentUserId; 
                entry.Entity.UpdatedOn = DateTime.UtcNow;
            }
        }


            return base.SaveChangesAsync(cancellationToken);
    }
}
