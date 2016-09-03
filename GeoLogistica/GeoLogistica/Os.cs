using System;
using System.Collections.Generic;
using System.Web;

namespace GeoLogistica
{
    public class Os
    {
        public int IdOS { get; set; }
        public int IdCliente { get; set; }
        public int IdTecnico { get; set; }
        public string DataAtendimento { get; set; }
        public int HoraAtendimento { get; set; }
        public string Status { get; set; }
        public string Endereco { get; set; }
        public int Num { get; set; }

    }
}