using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando...");
            
            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do serviço");

            AutenticarJogadorRequest autenticarJogadorRequest = new AutenticarJogadorRequest();
            Console.WriteLine("Criei instancia do meu objeto request");

            autenticarJogadorRequest.Email = ("alwef@alef.com");
            autenticarJogadorRequest.Senha = "12345678";
            //var response = service.AutenticarJogador(autenticarJogadorRequest);
          //  if (service.IsInvalid())
            //    return response;

        


            var adicionarJogadorRequest = new AdicionarJogadorRequest()
            {
                Email = "alwef@alef.com",
                PrimeiroNome = "Andre",
                UltimoNome = "Alef",
                Senha = "12345678",
            };

            //   var response2 = service.AdicionarJogador(adicionarJogadorRequest);
            //var result = service.ListarJogadores();
            Console.WriteLine("Serviço é valido:" + service.IsValid());

            service.Notifications.ToList().ForEach(x => {
                Console.WriteLine(x.Message);
            });
            Console.ReadKey();
        }
    }
}
