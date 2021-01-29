using System.Collections.Generic;

namespace Domain.Modelos.Watson
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public List<string> Textos { get; set; }

        public Mensagem(Modelos.MensagemEntrada mensagemEntrada)
        {
            Texto = mensagemEntrada.Texto;
        }
        public Mensagem(Mensagem mensagem, OutputConversaWatson outputConversaWatson)
        {
            Textos = new List<string>();
            foreach (var input in outputConversaWatson?.Output.Generic) { Textos.Add(input?.Textos); };
        }

    }
}
