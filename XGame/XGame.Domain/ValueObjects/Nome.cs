using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resources;

namespace XGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        protected Nome()
        {
                
        }
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this).IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 50, Message.X0__INVALIDO.ToFormat("Primeiro nome "))
                .IfNullOrInvalidLength(x => x.UltimoNome, 3, 50, Message.X0__INVALIDO.ToFormat("Ultimo nome "));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
    }
}
