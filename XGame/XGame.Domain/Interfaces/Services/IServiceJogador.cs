using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services.Base;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador : IServiceBase
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);

        AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> ListarJogadores();

        ResponseBase ExcluirJogador(Guid id);

    }
}
