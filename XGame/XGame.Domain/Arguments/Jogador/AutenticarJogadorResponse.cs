namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entidate)
        {
            return new AutenticarJogadorResponse()
            {
                Email = entidate.Email.Endereco,
                PrimeiroNome = entidate.Nome.PrimeiroNome,
                Status = (int)entidate.Status
            };
        }
    }
}
