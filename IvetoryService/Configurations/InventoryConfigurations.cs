using InventoryService.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Configurations
{
    public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Application)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Environment)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.HostName)
                .IsRequired()
                .HasMaxLength(50);

            //builder.Property(e => e.IpAddress)
            //    .IsRequired()
            //    .HasMaxLength(50);

            builder.OwnsOne(m => m.IpAddress, b =>
            {
               b.Property(d => d.Value)
                .HasMaxLength(50)
                .IsRequired();
            });

            builder.Property(e => e.OperatingSystem)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.DatabaseVersion)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.DatabaseName)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.InstanceName)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.TNS)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.SysNSystCred)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.OraCred)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(e => e.DbAdCred)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(e => e.Remark)
             .IsRequired(false)
             .HasMaxLength(100);
        }
    }
}
