using EstudoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstudoWebAPI.Controllers
{
    public class ProdutoController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto{Id = 1, Categoria = "Livro", Nome = "Abadia de northanger", price = 12.09M },
            new Produto{Id = 2, Categoria = "Acessório", Nome = "Carregador Portátil", price = 34.99M },
            new Produto{Id = 3, Categoria = "Eletrônico", Nome = "Celular", price = 612 }
        };

        public IEnumerable<Produto> GetAllProdutos()
        {
            return produtos;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var produto = produtos.FirstOrDefault((p) => p.Id == id);
            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        [AcceptVerbs ("POST")]
        public IList<Produto> httpAction(string name)
        {
            List<Produto> produto = new List<Produto>();
            foreach (var prod in produtos)
            {
                if (prod.Nome.Contains(name)) { 
                   produto.Add(prod);
                }
            }
            if(produto == null)
            {
                return null;
            }
            return produto;
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        public IList<Produto> httpAction(string name, string category)
        {
            List<Produto> produto = new List<Produto>();
            foreach (var prod in produtos)
            {
                if (prod.Nome.Contains(name))
                {
                    produto.Add(prod);
                }
            }
            if (produto == null)
            {
                return null;
            }
            return produto;
        }
    }
}
