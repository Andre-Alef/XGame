using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext: DbContext
    {
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Remove a pluralização dos nomes de tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            //Remove a exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Usar Varchar ao inves de Nvarvhar

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Tamanha default = 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));


            //Mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new JogadorMap());


            //Adicionar entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);


            base.OnModelCreating(modelBuilder);
        }
    }
}
