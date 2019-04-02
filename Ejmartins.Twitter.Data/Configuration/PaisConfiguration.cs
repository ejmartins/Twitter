using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Configuration
{
    public class PaisConfiguration : EntityTypeConfiguration<PaisEntity>, IConfiguration
    {
        public PaisConfiguration()
        {
            ToTable("Pais");
            HasKey(_ => _.Id);
        }
    }
}
