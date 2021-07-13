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
using MediatR;
using Microsoft.Extensions.Logging;
using ProductControlAPI.Domain.Query.Category;
using System.Threading;
using System.Threading.Tasks;

namespace ProductControlAPI.Business.Handler.Query
{
    public class CategoryQueryHandler : 
        IRequestHandler<FindCategoryQuery, FindCategoryReponse>,
        IRequestHandler<FindAllCategoryQuery, FindAllCategoryResponse>
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<CategoryQueryHandler> _logger;

        public CategoryQueryHandler(ApplicationContext context, ILogger<CategoryQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<FindCategoryReponse> Handle(FindCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<FindAllCategoryResponse> Handle(FindAllCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
