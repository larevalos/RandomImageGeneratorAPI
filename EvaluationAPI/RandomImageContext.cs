using System;
using EvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EvaluationAPI
{
    public class RandomImageContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {

        public RandomImageContext(DbContextOptions options)
            : base(options) {  }

        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<HistoryEntity> LikesHistory { get; set; }

        //check
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<ImageEntity>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(250);
            });*/
        }

    }
}
