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

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductControlAPI.Domain.Query.Category;
using System;

namespace ProductControlAPI.Controller
{
    [ApiController]
    [Route("{version}/api/products")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/category")]
        public ActionResult<FindAllCategoryResponse> FindAllCategory(int page, int size)
        {
            try
            {
                var query = new FindAllCategoryQuery { CurrentPage = page, PageSize = size };

                var response = _mediator.Send(query);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/category")]
        public ActionResult<string> FindCategory([FromQuery] int categoryId)
        {
            try
            {
                var query = new FindCategoryQuery { Id = categoryId};

                var response = _mediator.Send(query);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/category")]
        public ActionResult<string> AddCategory([FromQuery] string request)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/category/{id}")]
        public ActionResult<string> UpdateCategory([FromQuery] string request, int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("/category/{id}")]
        public ActionResult<string> DeleteCategory([FromQuery] int id)
        {
            throw new NotImplementedException();
        }
    }
}