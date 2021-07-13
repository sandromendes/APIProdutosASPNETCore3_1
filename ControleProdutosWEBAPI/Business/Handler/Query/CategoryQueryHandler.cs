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

using ControleProdutosWEBAPI.Context;
using ControleProdutosWEBAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProductControlAPI.Domain.Common;
using ProductControlAPI.Domain.DTO;
using ProductControlAPI.Domain.Query.Category;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductControlAPI.Business.Handler.Query
{
    public class CategoryQueryHandler : 
        IRequestHandler<FindCategoryQuery, FindCategoryReponse>,
        IRequestHandler<FindAllCategoryQuery, FindAllCategoryResponse>
    {
        private readonly ReadContext _context;
        private readonly ILogger<CategoryQueryHandler> _logger;

        public CategoryQueryHandler(ReadContext context, ILogger<CategoryQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<FindCategoryReponse> Handle(FindCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _context
                    .Set<CategoryDTO>()
                    .Where(c => c.Id == request.Id)
                    .FirstOrDefault();

                return Task.FromResult(new FindCategoryReponse 
                { 
                    Response = data, 
                    Status = ResponseStatus.SUCCESS, 
                    StatusCode = StatusCodes.Status200OK 
                });
            }
            catch (Exception)
            {
                _logger.LogInformation(GetType().ToString() + ResponseStatus.ERROR.ToString());
                return Task.FromResult(new FindCategoryReponse { Status = ResponseStatus.ERROR, StatusCode = StatusCodes.Status400BadRequest});
            }
        }

        public Task<FindAllCategoryResponse> Handle(FindAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = _context
                    .Set<CategoryDTO>()
                    .AsQueryable();

                var response = PagedList<CategoryDTO>.ToPagedList(categories, request.CurrentPage, request.PageSize);

                return Task.FromResult(new FindAllCategoryResponse 
                { 
                    Response = response,
                    Status = ResponseStatus.SUCCESS,
                    StatusCode = StatusCodes.Status200OK
                });
            }
            catch (Exception)
            {
                _logger.LogInformation(GetType().ToString() + ResponseStatus.ERROR.ToString());
                return Task.FromResult(new FindAllCategoryResponse { Status = ResponseStatus.ERROR, StatusCode = StatusCodes.Status400BadRequest });
            }
        }
    }
}
