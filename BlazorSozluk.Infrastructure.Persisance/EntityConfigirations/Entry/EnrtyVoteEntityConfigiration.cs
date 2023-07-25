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
    public class EnrtyVoteEntityConfigiration:BaseEntityConfigiration<Api.Domain.Models.EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);
            builder.ToTable("entryvotes", BlazorSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry)
                   .WithMany(i => i.EntryVotes)
                   .HasForeignKey(i => i.EntryId);
        }
    }
}
