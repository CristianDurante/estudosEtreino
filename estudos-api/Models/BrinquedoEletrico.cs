using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudos_api.Models
{
    public class BrinquedoEletrico : Brinquedo
    {
        public BrinquedoEletrico()
        {
        }

        public BrinquedoEletrico(string nome, string tipo) : base(nome, tipo)
        {
        }
    }
}