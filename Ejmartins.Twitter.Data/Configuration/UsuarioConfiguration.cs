using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data.Configuration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<UsuarioEntity>, IConfiguration
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            HasKey(_ => _.Id);
        }
    }
}
