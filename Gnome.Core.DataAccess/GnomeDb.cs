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

            base.OnModelCreating(modelBuilder);
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
