using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace IndexWordsInTexts
{
    public partial class SearcherContext : DbContext
    {
        public SearcherContext()
            : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.Connection.ConnectionString =
                "<add name=\"DefaultConnection\" connectionString=\"Server=tcp:searcherdb.database.windows.net,1433;" +
                "Initial Catalog=SearcherDB;Persist Security Info=False;User ID=searcherdb;Password=Admin1234!;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" +
                "\" providerName=\"System.Data.SqlClient\" />";
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
