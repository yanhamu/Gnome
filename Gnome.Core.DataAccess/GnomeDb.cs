using Gnome.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gnome.Core.DataAccess
{
    public class GnomeDb : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var fioAccountBuilder = modelBuilder.Entity<FioAccount>();

            MapFioAccount(fioAccountBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void MapFioAccount(EntityTypeBuilder<FioAccount> fioAccountBuilder)
        {
            fioAccountBuilder.HasKey(k => k.Id);
            fioAccountBuilder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .IsRequired();
        }

        public DbSet<FioAccount> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
