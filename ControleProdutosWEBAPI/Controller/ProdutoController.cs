using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleProdutosWEBAPI.Model;
using ControleProdutosWEBAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleProdutosWEBAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ILogger _logger;
        private IProdutoService _service;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/api/produtos")]
        public ActionResult<List<Produto>> GetProdutos() 
        {
            return _service.GetProdutos();
        }

        [HttpPost("/api/produto")]
        public ActionResult<Produto> AddProduto(Produto produto)
        {
            _service.AddProduto(produto);
            return produto;
        }

        [HttpPut("/api/produtos/{id}")]
        public ActionResult<Produto> UpdateProduto(int id, Produto produto)
        {
            _service.UpdateProduto(id, produto);
            return produto;
        }

        [HttpDelete("/api/produtos/{id}")]
        public ActionResult<int> DeleteProduto(int id)
        {
            _service.DeleteProduto(id);
            return id;
        }
    }
}
