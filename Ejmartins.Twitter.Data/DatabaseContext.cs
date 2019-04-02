using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Ejmartins.Twitter.Data.Configuration;
using Ejmartins.Twitter.Domain.Entities;

namespace Ejmartins.Twitter.Data
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base("EjmartinsTwitter")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("EjmartinsTwitter");
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PaisConfiguration());
            modelBuilder.Configurations.Add(new IdiomaConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new TweetConfiguration());

        }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<TweetEntity> Tweets { get; set; }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        private DbSet<PaisEntity> Pais { get; set; }

        private DbSet<IdiomaEntity> Idiomas { get; set; }


    }

}
