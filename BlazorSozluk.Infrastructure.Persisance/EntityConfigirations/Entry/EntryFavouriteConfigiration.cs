using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.EntityConfigirations.Entry
{
    public class EntryFavouriteConfigiration:BaseEntityConfigiration<Api.Domain.Models.EntryFavori>
    {
        public override void Configure(EntityTypeBuilder<EntryFavori> builder)
        {
            base.Configure(builder);
            builder.ToTable("entryfavourites", BlazorSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry)
              .WithMany(i => i.EntryFavourites)
              .HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryFavourites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
