using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {
      
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 e 32 caracteres");
            if (!IsInvalid())
                Senha = senha.ConverterMd5();
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6, 32);
            
            if(IsValid())
            Senha = senha.ConverterMd5();

            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {

            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this).IfFalse(Status == EnumSituacaoJogador.Ativo, "Jogado não está ativo");
            AddNotifications(nome, email);
        }

     
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
    }
}
