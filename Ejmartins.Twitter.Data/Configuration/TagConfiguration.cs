using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Configuration
{
    public class TagConfiguration : EntityTypeConfiguration<TagEntity>, IConfiguration
    {
        public TagConfiguration()
        {
            ToTable("Tag");
            HasKey(_ => _.Id);
        }
    }
}
