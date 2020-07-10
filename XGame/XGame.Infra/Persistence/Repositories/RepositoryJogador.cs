using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using System.Data.Entity;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
   public class RepositoryJogador :RepositoryBase<Jogador,Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }

        //public Jogador AdicionarJogador(Jogador jogador)
        //{
        //    _context.Jogadores.Add(jogador);
        //    _context.SaveChanges();

        //    return jogador;
        //}

        //public Jogador AlterarJogador(Jogador jogador)
        //{
        //    throw new NotImplementedException();
        //}

        //public Jogador AutenticarJogador(string email, string senha)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Jogador> ListarJogadores()
        //{
        //    return _context.Jogadores.ToList();
        //}

        //public Jogador ObterJogadorPorId(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}

        //Dicas
        public int CriarFiltros()
        {
            string nome = "alef";
            string ultimonome = "moura";

            //Montar a Query antes de pesquisar no banco, para fazer apenas uma requisição
            // AsNoTracking desabilita o mapeamento do comando, mapeamento que pode não ser necessário para 'Selects' por exemplo. A consulta ficara mais rapida.
            IQueryable<Jogador> jogadores = _context.Jogadores.AsNoTracking().AsQueryable();


            if (!string.IsNullOrEmpty(nome))
                jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(nome));

            if (!string.IsNullOrEmpty(ultimonome))
                jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.EndsWith(ultimonome));


            // A pesquisa no banco só acontece no momento do "ToList()"
            //As parallel permite o uso de mais de um processador ou mais de um nucleo do processador para consulta, não é inidicado para consultas simples
            return jogadores.AsParallel().ToList().Count();
        }
        
    }
}
