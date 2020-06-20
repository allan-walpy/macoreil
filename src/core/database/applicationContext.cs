using System;
using Microsoft.EntityFrameworkCore;

namespace Macoreil.Core.Database
{
    public sealed class ApplicationContext : DbContext
    {
        public const string AuthorTableName = "Author";
        public const string EntryTableName = "Entry";

        public static readonly string DefaultGuid = System.Guid.Empty.ToString();
        public static readonly int IdLength = DefaultGuid.Length;

        public const int AuthorLoginMaxLength = 15;

        public const int AuthorDisplayNameMaxLength = 31;

        //TODO:get fixed value;
        public static readonly int AuthorPublicKeyLength = 255;

        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<EntryModel> Entries { get; set; }


        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureAuthorsTable(modelBuilder);
            ConfigureEntriesTable(modelBuilder);

            ConfigureRelationships(modelBuilder);
        }

        private static void ConfigureAuthorsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>()
                .HasIndex(a => a.Id)
                .IsUnique();

            modelBuilder.Entity<AuthorModel>()
                .Property(a => a.Id)
                .IsRequired()
                .IsFixedLength(true)
                .HasMaxLength(IdLength)
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DefaultGuid);

            modelBuilder.Entity<AuthorModel>()
                .Property(a => a.Login)
                .IsRequired()
                .HasMaxLength(AuthorLoginMaxLength);

            modelBuilder.Entity<AuthorModel>()
                .Property(a => a.DisplayName)
                .HasMaxLength(AuthorDisplayNameMaxLength)
                .HasDefaultValue(String.Empty);

            modelBuilder.Entity<AuthorModel>()
                .Property(a => a.PublicKey)
                .IsRequired()
                .IsFixedLength(true)
                .HasMaxLength(AuthorPublicKeyLength);
        }

        private static void ConfigureEntriesTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntryModel>()
                .HasIndex(a => a.Id)
                .IsUnique();

            modelBuilder.Entity<EntryModel>()
                .Property(a => a.Id)
                .IsFixedLength(true)
                .HasMaxLength(IdLength)
                .HasDefaultValue(typeof(GuidGenerator))
                .ValueGeneratedOnAdd()
                .HasDefaultValue(DefaultGuid);

            modelBuilder.Entity<EntryModel>()
                .Property(a => a.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EntryModel>()
                .Property(a => a.EditedAt)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<EntryModel>();
        }

        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>()
                .HasMany(a => a.Entries)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .HasPrincipalKey(a => a.EntriesId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
