using System.Collections.Generic;
using ControleProdutosWEBAPI.Domain.Query;
using ControleProdutosWEBAPI.Model;
using ControleProdutosWEBAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleProdutosWEBAPI.Controller
{
    [Route("{version}/api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProdutoRepository _repository;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoRepository service)
        {
            _logger = logger;
            _repository = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Produto>> GetProdutos() 
        {
            if (!_repository.GetProdutos(out var listagem))
                return NotFound();

            return Ok(listagem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Produto))]
        [ProducesResponseType(404)]
        public ActionResult<Produto> GetProduto(int id)
        {
            if (!_repository.GetProduto(id, out var produto))
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("category/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Produto> GetProdutosByCategoriaId(int id)
        {
            if(!_repository.GetProdutoByCategoriaId(id, out var listagem))
                return NotFound();
        
            return Ok(listagem);
        }

        [HttpGet("report")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<FindProdutoReportResponse>> GetProdutoReportId(
            [FromBody] FindProdutoReportRequest request)
        {
            if (!_repository.GetProdutoReport(out var listagem, request))
                return NotFound();

            return Ok(listagem);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Produto> AddProduto(Produto produto)
        {
            if (!_repository.AddProduto(produto))
                return BadRequest();
            
            return Ok(produto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Produto> UpdateProduto(int id, Produto produto)
        {
            if(_repository.UpdateProduto(id, produto))
            {
                return Ok(produto);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduto(int id)
        {
            if (_repository.DeleteProduto(id))
                return Ok("Produto deletado com sucesso.");

            return BadRequest();
        }
    }
}
