using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace estudos_api.Controllers
{
    public class CarrosController : ApiController
    {
        static List<Models.Carro> listaDeCarros = new List<Models.Carro>();
        private static int ContadorId = 1;

        public CarrosController() { }
        // GET: api/Carros
        public IHttpActionResult Get()
        {
            return Ok(listaDeCarros);
        }

        // GET: api/Carros/5
        public IHttpActionResult Get(int id)
        {
            foreach (var carros in listaDeCarros)
            {
                if (carros.Id == id)
                {
                    return Ok(carros);
                }
            }
            return NotFound();
        }

        private static int getContadorId()
        {
            return ContadorId++;
        }

        // POST: api/Carros
        public IHttpActionResult Post([FromBody]Models.Carro carro)
        {
            if (carro == null)
                return BadRequest("Os dados do carro esta incorreto.");

            carro.Id = getContadorId();
            listaDeCarros.Add(carro);
            return Ok(carro);
        }
        [Route("api/Carros/batch")]
        public IHttpActionResult Post(List<Models.Carro> listaCarros)
        {
            if (listaCarros == null)
                return BadRequest("Os dados do carro esta incorreto.");

            foreach (var carro in listaCarros)
            {
                carro.Id = getContadorId();
                listaDeCarros.Add(carro);
            }
            return Ok();
        }

        // PUT: api/Carros/5
        public IHttpActionResult Put(int id, Models.Carro carro)
        {
            foreach (var carroP in listaDeCarros)
            {
                if (carroP.Id == id)
                {
                    carroP.Nome = carro.Nome;
                    carroP.Ano = carro.Ano;
                    carroP.Preco = carro.Preco;
                    return Ok(carro);
                }
            }
            return NotFound();
        }

        // DELETE: api/Carros/5
        public IHttpActionResult Delete(int id)
        {
            foreach (var carro in listaDeCarros)
            {
                if (carro.Id == id)
                {
                    listaDeCarros.Remove(carro);
                    return Ok(carro);
                }
            }
            return NotFound();
        }
    }
}
