using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistence.EntityConfigirations.EntryComment
{
    public class EntryCommendFavouriteEntityConfigiration : BaseEntityConfigiration<EntryCommentFavourite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavourite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", BlazorSozlukContext.DEFAULT_SCHEMA);


            builder.HasOne(i => i.EntryComment)
                .WithMany(i => i.EntryCommentFavourites)
                .HasForeignKey(i => i.EntryCommentId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryCommentFavourites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
