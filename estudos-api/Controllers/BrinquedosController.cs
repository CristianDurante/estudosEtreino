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
        [Route("api/brinquedos/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                switch (id)
                {
                    case 1:
                        return Ok(brinquedosEletrico);
                    case 2:
                        return Ok(brinquedosMecanico);
                    default:
                        return BadRequest("Tipo de brinquedo não encontrado.");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                        Id = getIdEletrico()
                    };
                    brinquedosEletrico.Add(brinquedoEletrico);
                    return Ok(brinquedoEletrico);
                case "mecanico":
                    var brinquedoMecanico = new BrinquedoMecanico
                    {
                        Nome = brinquedo.Nome,
                        IdadeMinima = brinquedo.IdadeMinima,
                        Tipo = brinquedo.Tipo,
                        Id = getIdMecanico()
                    };
                    brinquedosMecanico.Add(brinquedoMecanico);
                    return Ok(brinquedoMecanico);
                default:
                    return BadRequest("Tipo de brinquedo inválido.");
            }
        }

        // PUT: api/Brinquedos/5
        [Route("api/Brinquedos/{tipo}/{id}")]
        public IHttpActionResult Put(string tipo, int id, [FromBody]Models.Brinquedo brinquedo)
        {
            switch (tipo.ToLower())
            {
                case "eletrico":
                    foreach (var brinquedos in brinquedosEletrico)
                    {
                        if (brinquedos.Id == id)
                        {
                            brinquedos.Id = brinquedo.Id;
                            brinquedos.Nome = brinquedo.Nome;
                            brinquedos.IdadeMinima = brinquedo.IdadeMinima;
                            brinquedos.Tipo = brinquedo.Tipo;
                            
                            return Ok(brinquedos);
                        }
                    }
                    break;
                case "mecanico":
                    foreach (var brinquedos in brinquedosMecanico)
                    {
                        if (brinquedos.Id == id)
                        {
                            brinquedos.Id = brinquedo.Id;
                            brinquedos.Nome = brinquedo.Nome;
                            brinquedos.IdadeMinima = brinquedo.IdadeMinima;
                            brinquedos.Tipo = brinquedo.Tipo;

                            return Ok(brinquedos);
                        }
                    }
                    break;
                default:
                    return BadRequest("Tipo de brinquedo não encontrado.");
            }
            return NotFound();
        }

        // DELETE: api/Brinquedos/5
        [Route("api/brinquedos/{tipo}/{id}")]
        public IHttpActionResult Delete(string tipo, int id)
        {
            switch (tipo.ToLower())
            {
                case "eletrico":
                    foreach (var brinquedo in brinquedosEletrico)
                    {
                        if (brinquedo.Id == id)
                        {
                            brinquedosEletrico.Remove(brinquedo);
                            return Ok(brinquedo);
                        }
                    }
                    break;
                case "mecanico":
                    foreach (var brinquedo in brinquedosMecanico)
                    {
                        if (brinquedo.Id == id)
                        {
                            brinquedosMecanico.Remove(brinquedo);
                            return Ok(brinquedo);
                        }
                    }
                    break;
                default:
                    return BadRequest("Tipo de brinquedo não encontrado.");
            }
            return NotFound();
        }
    }
}
