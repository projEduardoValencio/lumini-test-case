﻿using Lumini.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumini.Infrastructure.DataAccess.EntityConfiguration;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("Routes");
        builder.HasKey(r => new { r.Origin, r.Destination });
        builder.Property(r => r.Origin)
            .IsRequired()
            .HasMaxLength(4);

        builder.Property(r => r.Destination)
            .IsRequired()
            .HasMaxLength(4);

        builder.Property(r => r.Value)
            .IsRequired();
    }
}