using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using WordIndexer.Entites;

namespace WordIndexer
{
    public partial class SearcherContext : DbContext
    {
        public SearcherContext()
            : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<SearchWords> SearchWords { get; set; }
        public virtual DbSet<Texts> Texts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchWords>().Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Texts>().Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<SearchWords>()
                .HasMany(e => e.Texts)
                .WithMany(e => e.SearchWords)
                .Map(m => m.ToTable("SearchWords_Texts"));
        }
    }
}
