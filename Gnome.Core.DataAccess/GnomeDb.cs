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
            MapFioAccount(modelBuilder.Entity<FioAccount>());
            MapFioTransaction(modelBuilder.Entity<FioTransaction>());
            MapCategory(modelBuilder.Entity<Category>());
            MapCategoryTransaction(modelBuilder.Entity<CategoryTransaction>());

            base.OnModelCreating(modelBuilder);
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

        private void MapFioTransaction(EntityTypeBuilder<FioTransaction> builder)
        {
            builder.ToTable("fio_transaction");

            builder.HasKey(k => k.Id);
            builder.HasOne(t => t.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId)
                .IsRequired();
            builder.Property(x => x.AccountId).HasColumnName("account_id");
            builder.Property(x => x.FioId).HasColumnName("fio_id");
            builder.Property(x => x.Date);
            builder.Property(x => x.Amount);
            builder.Property(x => x.Currency);
            builder.Property(x => x.CounterpartAccount).HasColumnName("counter_account");
            builder.Property(x => x.CounterpartAccountName).HasColumnName("counter_account_name");
            builder.Property(x => x.CounterpartBankCode).HasColumnName("counter_bank_code");
            builder.Property(x => x.CounterpartBankName).HasColumnName("counter_bank_name");
            builder.Property(x => x.ConstantSymbol).HasColumnName("constant_symbol");
            builder.Property(x => x.VariableSymbol).HasColumnName("variable_symbol");
            builder.Property(x => x.SpefificSymbol).HasColumnName("specific_symbol");
            builder.Property(x => x.Identification).HasColumnName("identification");
            builder.Property(x => x.MessageForReceipient).HasColumnName("message");
            builder.Property(x => x.Type).HasColumnName("type");
            builder.Property(x => x.Accountant).HasColumnName("accountant");
            builder.Property(x => x.Comment).HasColumnName("comment");
            builder.Property(x => x.Bic).HasColumnName("bank_identification_number");
            builder.Property(x => x.InstructionId).HasColumnName("instruction_id");
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
        public DbSet<FioTransaction> FioTransactions { get; set; }
    }
}
