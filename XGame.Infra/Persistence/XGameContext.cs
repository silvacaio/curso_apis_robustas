using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Jogo> Jogos { get; set; }
        public IDbSet<Plataforma> Plataformas { get; set; }
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização no nome das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //remove a exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //setar para usar varchar ao invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //caso esqueca de informar o tamanho da string, o tamanho será 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            #region Adiconar entidades mapeadas - automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
