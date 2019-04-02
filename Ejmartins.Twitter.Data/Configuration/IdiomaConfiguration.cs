using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Configuration
{
    public class IdiomaConfiguration : EntityTypeConfiguration<IdiomaEntity>, IConfiguration
    {
        public IdiomaConfiguration()
        {
            ToTable("Idioma");
            HasKey(_ => _.Id);
        }
    }
}
