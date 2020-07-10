using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
   public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entidade)
        {
            return new AdicionarJogadorResponse()
            {
                Id = entidade.Id,
                Mensagem = "Retorn Ok"

            };
        }
    }
}
