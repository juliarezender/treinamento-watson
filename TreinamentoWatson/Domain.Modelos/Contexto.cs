using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Modelos
{
    public class Contexto
    {
        public string IdUsuario { get; set; }
        public dynamic System { get; set; }
        public int? Contador { get; set; }
        public string SessionId { get; set; }
    }
}
