﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorSozluk.Infrastructure.Persistence.Context
{
    public class BlazorSozlukContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public BlazorSozlukContext()
        {
            
        }
        public BlazorSozlukContext(DbContextOptions options):base(options) {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryFavori> EntryFavourites { get; set; }

        public DbSet<EntryCommentFavourite> EntryCommentFavourites { get; set; }

        public DbSet<EntryVote> EntryVotes { get; set; }

        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }

        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Migrationlar için
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=.;Database=BlazorSozlukDb;Trusted_Connection=True; TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connStr, opt => {
                    opt.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities) 
        {
            foreach (var entity in entities)
            {
                entity.CreatedTime = DateTime.Now;
            }
        
        
        }
    }
}
