using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCar.Areas.Identity.Data;
using WebCar.Models;

namespace WebCar.Data;

public class WebCarDbContext : IdentityDbContext<WebCarUser>
{
    public DbSet<ChatUserModel> ChatUsers { get; set; }
    public WebCarDbContext(DbContextOptions<WebCarDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ChatUserModel>().HasKey(c => c.ChatUserId);

        builder.Entity<ChatUserModel>()
            .HasOne(w => w.WebCarUser1)
            .WithMany(c => c.ChatUserModels1)
            .HasForeignKey(i => i.ChatUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ChatUserModel>()
            .HasOne(c => c.WebCarUser2)
            .WithOne(c => c.ChatUserModel2)
            .HasPrincipalKey<WebCarUser>(c => c.UserName)
            .HasForeignKey<ChatUserModel>(c => c.UserNameActualChatUser)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
