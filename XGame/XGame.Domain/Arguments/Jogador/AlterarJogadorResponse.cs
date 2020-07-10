using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

        public string Email { get; set; }
        public string Mensagem { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse()
            {
                Email = entidade.Email.Endereco,
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Mensagem = "Alterado com Sucesso!"
            };
        }
    }
}
