using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudos_api.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }

        public Carro() { }
    }
}