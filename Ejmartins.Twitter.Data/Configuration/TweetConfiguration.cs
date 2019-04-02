using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Ejmartins.Twitter.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace Ejmartins.Twitter.Data.Configuration
{
    public class TweetConfiguration : EntityTypeConfiguration<TweetEntity>, IConfiguration
    {
        public TweetConfiguration()
        {
            ToTable("Tweet");
            HasKey(_ => _.Id);
            HasMany(a => a.Tags2)
                .WithMany()
                .Map(t => t.MapLeftKey("IdTweet").MapRightKey("IdTag").ToTable("TweetTag"));
            
        }
    }
}
