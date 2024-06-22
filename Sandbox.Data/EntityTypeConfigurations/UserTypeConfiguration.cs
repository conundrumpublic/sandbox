using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sandbox.Data.Entities;

namespace Sandbox.Data.EntityTypeConfigurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("User");
        b.HasKey(e => e.Id);
        b.Property(e => e.First).HasMaxLength(100);
        b.Property(e => e.Last).HasMaxLength(100);
    }
}