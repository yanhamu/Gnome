using Gnome.Core.Model.Database;
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
            MapAccount(modelBuilder.Entity<Account>());
            MapCategory(modelBuilder.Entity<Category>());
            MapCategoryTransaction(modelBuilder.Entity<CategoryTransaction>());
            MapTransaction(modelBuilder.Entity<Transaction>());
            MapExpression(modelBuilder.Entity<Expression>());
            MapQuery(modelBuilder.Entity<Query>());
            MapReport(modelBuilder.Entity<Report>());
            MapRule(modelBuilder.Entity<Rule>());

            base.OnModelCreating(modelBuilder);
        }

        private void MapRule(EntityTypeBuilder<Rule> builder)
        {
            builder.ToTable("rule");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ExpressionId).HasColumnName("expression_id");
            builder.Property(p => p.UserId).HasColumnName("user_id");

            builder.HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Expression).WithMany().HasForeignKey(b => b.ExpressionId);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.ActionType).HasColumnName("action_type").IsRequired();
            builder.Property(p => p.ActionData).HasColumnName("action_data").IsRequired();
        }

        private void MapReport(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("report");
            builder.HasKey(k => k.Id);
            builder.HasOne(b => b.User).WithMany().HasForeignKey(b => b.UserId);
            builder.HasOne(b => b.Query).WithMany().HasForeignKey(b => b.QueryId);
        }

        private void MapQuery(EntityTypeBuilder<Query> builder)
        {
            builder.ToTable("query");
            builder.HasKey(q => q.Id);
            builder.HasOne(b => b.User).WithMany().HasForeignKey(f => f.UserId);
        }

        private void MapExpression(EntityTypeBuilder<Expression> builder)
        {
            builder.ToTable("expression");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.ExpressionString).IsRequired();
            builder.Property(f => f.Name).IsRequired();
            builder.Property(f => f.UserId).HasColumnName("user_id").IsRequired();
            builder.HasOne(u => u.User).WithMany().HasForeignKey(f => f.UserId);

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
            builder.Property(x => x.CategoryData).IsRequired().HasColumnName("category_data");
        }

        private void MapUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
        }

        private void MapCategoryTransaction(EntityTypeBuilder<CategoryTransaction> builder)
        {
            builder.ToTable("category_transaction");
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
            builder.Property(x => x.Color).HasColumnName("color");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).IsRequired(false);
        }

        private void MapAccount(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.UserId).HasColumnName("user_id");

            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .IsRequired();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTransaction> CategoryTransactions { get; set; }

    }
}
