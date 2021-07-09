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
using ControleProdutosWEBAPI.Domain.DTO;
using ControleProdutosWEBAPI.Domain.Enum;
using ControleProdutosWEBAPI.Domain.Query.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductControlAPI.Domain.Common;
using ProductControlAPI.Domain.Query.Product;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Business.Handler
{
    public class ProductQueryHandler : 
        IRequestHandler<FindProductQuery, FindProductResponse>,
        IRequestHandler<FindAllProductsQuery, FindAllProductsResponse>,
        IRequestHandler<FindProductByCategoryQuery, FindProductByCategoryResponse>
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ProductQueryHandler> _logger;

        public ProductQueryHandler(ApplicationContext context, ILogger<ProductQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<FindProductResponse> Handle(FindProductQuery request, CancellationToken cancellationToken)

        {
            try
            {
                var report = _context.Product
                            .Where(p => p.Id == request.ProductId)
                            .Select(p => new ProductDTO
                            {
                                ProductID = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Price = p.Price,
                                Quantity = p.Quantity,
                                Category = p.Category
                            }).FirstOrDefault();

                return Task.FromResult(new FindProductResponse { Response = report, Status = ResponseStatus.SUCCESS });
            }
            catch (Exception e)
            {
                _logger.LogInformation(this.GetType().ToString() + ResponseStatus.ERROR.ToString());
                return Task.FromResult(new FindProductResponse { Status = ResponseStatus.ERROR});
            }
        }

        public Task<FindAllProductsResponse> Handle(FindAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = _context.Product
                    .Select(a => new ProductDTO 
                    { 
                        ProductID = a.Id,
                        Category = a.Category,
                        Name = a.Name,
                        Description = a.Description,
                        Price = a.Price,
                        Quantity = a.Quantity
                    })
                    .AsQueryable();

                var response = PagedList<ProductDTO>.ToPagedList(products, request.CurrentPage, request.PageSize);

                return Task.FromResult(new FindAllProductsResponse { Response = response, Status = ResponseStatus.SUCCESS });
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return Task.FromResult(new FindAllProductsResponse { Status = ResponseStatus.ERROR });
            }
        }

        public Task<FindProductByCategoryResponse> Handle(FindProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = _context.Product
                    .Select(a => new ProductDTO
                    {
                        ProductID = a.Id,
                        Category = a.Category,
                        Name = a.Name,
                        Description = a.Description,
                        Price = a.Price,
                        Quantity = a.Quantity
                    })
                    .AsQueryable();

                var response = PagedList<ProductDTO>.ToPagedList(products, request.CurrentPage, request.PageSize);

                return Task.FromResult(new FindProductByCategoryResponse { Response = response, Status = ResponseStatus.SUCCESS });
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return Task.FromResult(new FindProductByCategoryResponse { Status = ResponseStatus.ERROR });
            }
        }
    }
}
