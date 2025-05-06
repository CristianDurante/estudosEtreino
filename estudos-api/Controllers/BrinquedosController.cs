using estudos_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace estudos_api.Controllers
{
    public class BrinquedosController : ApiController
    {
        static List<BrinquedoEletrico> brinquedosEletrico = new List<BrinquedoEletrico>();
        static List<BrinquedoMecanico> brinquedosMecanico = new List<BrinquedoMecanico>();
        private static int IdEletrico = 1;
        private static int IdMecanico = 1;

        //GET: api/Brinquedos
        public IHttpActionResult Get()
        {
            return Ok();
        }


        // GET: api/Brinquedos/5
        [HttpGet]
        [Route("api/brinquedos/{tipo}/{id}")]
        public IHttpActionResult Get(string tipo, int id)
        {
            Brinquedo brinquedo = null;

            switch (tipo.ToLower())
            {
                case "eletrico":
                    brinquedo = brinquedosEletrico.FirstOrDefault(b => b.Id == id);
                    break;
                case "mecanico":
                    brinquedo = brinquedosMecanico.FirstOrDefault(b => b.Id == id);
                    break;
                default:
                    return BadRequest("Tipo de brinquedo não encontrado.");
            }

            if(brinquedo != null)
                return Ok(brinquedo);

            return NotFound();
        }

        private static int getIdEletrico()
        {
            return IdEletrico++;
        }

        private static int getIdMecanico()
        {
            return IdMecanico++;
        }


        // POST: api/Brinquedos
        public IHttpActionResult Post([FromBody]Brinquedo brinquedo)
        {
            if (brinquedo.Tipo == null)
                return BadRequest("Tipo de brinquedo invalido.");

            switch (brinquedo.Tipo.ToLower())
            {
                case "eletrico":
                    var brinquedoEletrico = new BrinquedoEletrico
                    {
                        Nome = brinquedo.Nome,
                        IdadeMinima = brinquedo.IdadeMinima,
                        Tipo = brinquedo.Tipo,
                        Id = getIdMecanico()
                    };
                    brinquedosEletrico.Add(brinquedoEletrico);
                    break;
                case "mecanico":
                    var brinquedoMecanico = new BrinquedoMecanico
                    {
                        Nome = brinquedo.Nome,
                        IdadeMinima = brinquedo.IdadeMinima,
                        Tipo = brinquedo.Tipo,
                        Id = getIdMecanico()
                    };
                    brinquedosMecanico.Add(brinquedoMecanico);
                    break;

                default:
                    return BadRequest("Tipo de brinquedo inválido.");
            }
            return Ok();

        }

        // PUT: api/Brinquedos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brinquedos/5
        public void Delete(int id)
        {
        }
    }
}
