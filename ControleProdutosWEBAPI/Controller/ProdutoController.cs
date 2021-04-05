/**
 * Copyright 2021 Sandro Mendes
 * 
 * This file is part of ControleEstoqueBackEnd.
 * 
 * ControleEstoqueBackEnd is free software: you can redistribute it and/or modify it under the terms 
 * of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * 
 * ControleEstoqueBackEnd is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * 
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with Foobar. 
 * 
 * If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.Collections.Generic;
using ControleProdutosWEBAPI.Domain.Command;
using ControleProdutosWEBAPI.Domain.Query;
using ControleProdutosWEBAPI.Model;
using ControleProdutosWEBAPI.Repository;
using MediatR;
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
            try
            {
                var listagem = _repository.GetProdutos();

                if (listagem == null)
                {
                    return NotFound();
                }
                
                return Ok(listagem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Produto))]
        [ProducesResponseType(404)]
        public ActionResult<Produto> GetProduto(int id)
        {
            try
            {
                var produto = _repository.GetProduto(id);
                
                if(produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("category/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Produto> GetProdutosByCategoriaId(int id)
        {
            try
            {
                var listagem = _repository.GetProdutoByCategoriaId(id);

                if (listagem == null)
                {
                    return NotFound();
                }
                
                return Ok(listagem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("report")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<FindProdutoReportResponse>> GetProdutoReportId(
            [FromServices] IMediator mediator, [FromQuery] FindProdutoReportRequest request)
        {
            try
            {
                var response = mediator.Send(request);

                return Ok(response.Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Produto> AddProduto([FromServices] IMediator mediator, [FromQuery] CreateProdutoRequest command)
        {
            try
            {
                var response = mediator.Send(command);
            
                return Ok(response.Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Produto> UpdateProduto(int id, Produto produto)
        {
            try
            {
                _repository.UpdateProduto(id, produto);
                return Ok(produto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteProduto(int id)
        {
            try
            {
                _repository.DeleteProduto(id);
                return Ok("Produto deletado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
