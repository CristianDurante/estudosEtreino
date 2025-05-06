using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudos_api.Models
{
    public class Brinquedo : IBrinquedo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public string Tipo { get; set; }

        public Brinquedo() { }

        public Brinquedo(string nome, string tipo)
        {
            this.Nome = nome;
            this.Tipo = tipo;
        }
    }
}