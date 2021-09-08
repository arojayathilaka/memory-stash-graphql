using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace memory_stash.Data.Models
{
    public class MemoryStashDbContext : DbContext
    {

        public MemoryStashDbContext(DbContextOptions<MemoryStashDbContext> options)
            : base(options)
        {
        }
            
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendImage> FriendImages { get; set; }
        public DbSet<Group_User> Groups_Users { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<MemoryImage> MemoryImages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group_User>()
                .HasOne(gu => gu.Group)
                .WithMany(gu => gu.Groups_Users)
                .HasForeignKey(gu => gu.GroupId);

            modelBuilder.Entity<Group_User>()
                .HasOne(gu => gu.User)
                .WithMany(gu => gu.Groups_Users)
                .HasForeignKey(gu => gu.UserId);
        }
    }
}
