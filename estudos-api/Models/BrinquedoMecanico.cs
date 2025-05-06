using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudos_api.Models
{
    public class BrinquedoMecanico : Brinquedo
    {
        public BrinquedoMecanico()
        {
        }

        public BrinquedoMecanico(string nome, string tipo) : base(nome, tipo)
        {
        }
    }
}