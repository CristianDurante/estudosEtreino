using estudos_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace estudos_api.Controllers
{
    public class PessoasController : ApiController
    {
        static List<Pessoa> listaPessoas = new List<Pessoa>();
        static int ContadorId = 1;
        
        
        public PessoasController() { }

        // GET: api/Pessoas
        public IHttpActionResult Get()
        {
            return Ok(listaPessoas);
        }

        // GET: api/Pessoas/5
        public IHttpActionResult Get(int id)
        {
            foreach (var pessoa in listaPessoas)
            {
                if (pessoa.Id == id)
                {
                    return Ok(pessoa);
                }
            }
            return NotFound();
        }

        private int GetContador()
        {
            return ContadorId++;
        }

        // POST: api/Pessoas
        public IHttpActionResult Post(Models.Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Os dados da pessoa nao foram enviado corretamente.");
            }

            pessoa.Id = GetContador();
            listaPessoas.Add(pessoa);
            return Ok(pessoa);
        }

        [Route("api/Pessoas/listapessoas")]
        public IHttpActionResult Post(List<Models.Pessoa> listaDePessoas)
        {
            if (listaDePessoas == null)
                return BadRequest("Os dados da pessoa esta incorreto.");

            foreach (var pessoas in listaDePessoas)
            {
                pessoas.Id = GetContador();
                listaPessoas.Add(pessoas);
            }
            return Ok();
            
        }

        // PUT: api/Pessoas/5
        public IHttpActionResult Put(int id, [FromBody]Models.Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest("Os dados da pessoa nao foram enviado corretamente.");
            }

            foreach (var pessoas in listaPessoas)
            {
                pessoas.Nome = pessoa.Nome;
                pessoas.Idade = pessoa.Idade;
                return Ok(pessoas);
            }
            return NotFound();
        }

        // DELETE: api/Pessoas/5
        public IHttpActionResult Delete(int id)
        {
            foreach (var pessoa in listaPessoas)
            {
                if (pessoa.Id == id)
                    return Ok(listaPessoas.Remove(pessoa));
            }
            return NotFound();
        }
    }
}
