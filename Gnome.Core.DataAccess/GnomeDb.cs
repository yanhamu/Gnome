using Gnome.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gnome.Core.DataAccess
{
    public class GnomeDb : DbContext
    {
        public GnomeDb(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapUser(modelBuilder.Entity<User>());
            MapFioAccount(modelBuilder.Entity<FioAccount>());
            MapCategory(modelBuilder.Entity<Category>());
            MapCategoryTransaction(modelBuilder.Entity<CategoryTransaction>());
            MapTransaction(modelBuilder.Entity<Transaction>());

            base.OnModelCreating(modelBuilder);
        }

        private void MapTransaction(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");
            builder.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AccountId).HasColumnName("account_id");
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Data).IsRequired();
        }

        private void MapUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
        }

        private void MapCategoryTransaction(EntityTypeBuilder<CategoryTransaction> builder)
        {
            builder.HasKey(k => new { k.CategoryId, k.TransactionId });

            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.TransactionId).HasColumnName("transaction_id");

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).IsRequired();
            builder.HasOne(x => x.Transaction).WithMany().HasForeignKey(x => x.TransactionId).IsRequired();
        }

        private void MapCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.ParentId).HasColumnName("parent_id");
            builder.Property(x => x.IsSystem).HasColumnName("is_system");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).IsRequired(false);
        }
        
        private void MapFioAccount(EntityTypeBuilder<FioAccount> builder)
        {
            builder.ToTable("fio_account");
            builder.HasKey(k => k.Id);
            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .IsRequired();
        }

        public DbSet<FioAccount> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTransaction> CategoryTransactions { get; set; }
    }
}
