﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.Seller.Api.Companies.Domain.Entities;

namespace WB.Seller.Api.Companies.Infrastructure.Database.EfConfigurations
{
    internal class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("subscribers");

            builder.HasKey(x => x.SubId);

            builder.Ignore(e => e.Id);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Note)
                .HasMaxLength(500);

            builder.HasMany(s => s.Companies)
                .WithMany(c => c.Subscribers)
                .UsingEntity<Subscription>(
                    j => j
                        .HasOne(x => x.Company)
                        .WithMany(x => x.Subscriptions)
                        .HasForeignKey(x => x.CompanyId),
                    j => j
                        .HasOne(s => s.Subscriber)
                        .WithMany(s => s.Subscriptions)
                        .HasForeignKey(s => s.SubscriberId));
        }
    }
}
