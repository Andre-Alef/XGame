using prmToolkit.NotificationPattern;
using XGame.Domain.Resources;
using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.ValueObjects;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;
        public ServiceJogador()
        {

        }
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);
            Jogador jogador = new Jogador(nome, email, request.Senha);


            AddNotifications(nome, email, jogador);

            if (this.IsInvalid()) return null;
            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogador;

        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorRequest", Message.X0_É_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", Message.X0__INVALIDO);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);


            jogador.AlterarJogador(nome, email, jogador.Status);


            AddNotifications(jogador);
            if (IsInvalid())
            {
                return null;
            }


            jogador = _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;

        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {


            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_É_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }
            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);


            AddNotifications(jogador);
            if (jogador.IsInvalid())
            {
                return null;
            }

            //    jogador = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);
            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco, x => x.Senha == jogador.Senha);
            return (AutenticarJogadorResponse)jogador;
        }



        public IEnumerable<JogadorResponse> ListarJogadores()
        {
            return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorResponse)jogador).ToList();
          //  return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorResponse)jogador).ToList();
        }


        public ResponseBase ExcluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", "Dados não encontrados");
                return null;

            }
            _repositoryJogador.Remover(jogador);

            return new ResponseBase();

        }
    }
}
