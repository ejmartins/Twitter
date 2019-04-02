using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejmartins.Twitter.Domain.Fatos;

namespace Ejmartins.Twitter.Data
{
    public class DatabaseContextDW : DbContext, IDatabaseContextDw
    {
        public DatabaseContextDW() : base("EjmartinsTwitter")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EjmartinsTwitterDW");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public DbSet<PostagemPorDiaFato> PostagemPorDiaFato { get; set; }

        public DbSet<PostagemPorHashTagFato> PostagemPorHashTag { get; set; }

        public DbSet<Top5UsuarioFato> Top5Usuario { get; set; }

    }
}
