/*
 * Copyright 2021 Sandro Mendes
 * 
 * This file is part of ControleEstoqueBackEnd.
 * 
 * ControleEstoqueBackEnd is free software: you can redistribute it and/or modify it under the terms 
 * of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * 
 * ControleEstoqueBackEnd is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * 
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with Foobar. 
 * 
 * If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.Collections.Generic;
using ControleProdutosWEBAPI.Domain.Command.Products;
using ControleProdutosWEBAPI.Domain.DTO;
using ControleProdutosWEBAPI.Domain.Query.Product;
using ControleProdutosWEBAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleProdutosWEBAPI.Controller
{
    [ApiController]
    [Route("{version}/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FindProductResponse>> FindProduct([FromQuery] FindProductQuery request)
        {
            try
            {
                var response = _mediator.Send(request);

                return Ok(response.Result);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductDTO>> ListarProdutos() 
        {
            try
            {
                var query = new FindAllProductsQuery();

                var listagem = _mediator.Send(query);

                if (listagem == null)
                    return NotFound();
                
                return Ok(listagem);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Product> AddProduct([FromQuery] CreateProductCommand command)
        {
            try
            {
                var response = _mediator.Send(command);
            
                return Ok(response.Result);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateProductResponse> UpdateProduct(Guid id, Product product)
        {
            try
            {
                var command = new UpdateProductCommand { Id = id, Product = product};
                var response = _mediator.Send(command);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteProductResponse> DeleteProduct(Guid id)
        {
            try
            {
                var command = new DeleteProductCommand { Id = id };
                var response = _mediator.Send(command);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
