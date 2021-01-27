using System.Collections.Generic;

namespace Domain.Modelos.Watson
{
    public class MensagemSaida
    {
        public List<string> Textos { get; set; }

        public MensagemSaida(Mensagem mensagem)
        {
            Textos = mensagem.Textos;
        }
    }
}
