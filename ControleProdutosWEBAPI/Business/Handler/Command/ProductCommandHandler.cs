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

using ControleProdutosWEBAPI.Domain.Command.Products;
using ControleProdutosWEBAPI.Domain.DTO;
using ControleProdutosWEBAPI.Domain.Enum;
using ControleProdutosWEBAPI.Infra.UnitOfWork.Interface;
using ControleProdutosWEBAPI.Model;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Business.Handler.Command
{
    public class ProductCommandHandler : 
        IRequestHandler<CreateProductCommand, CreatedProductResponse>,
        IRequestHandler<UpdateProductCommand, UpdateProductResponse>,
        IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<ProductCommandHandler> _logger;

        public ProductCommandHandler(IUnitOfWork uow, ILogger<ProductCommandHandler> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = new Product 
                { 
                    Id = Guid.NewGuid(),
                    CategoryFK = request.CategoryId,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Quantity = request.Quantity
                };

                _uow.Products.Add(produto);
            
                var dto = new ProductDTO
                { 
                    ProductID = produto.Id,
                    Category = produto.Category,
                    Name = produto.Name,
                    Description = produto.Description,
                    Price = produto.Price,
                    Quantity = produto.Quantity
                };

                var response = new CreatedProductResponse
                {
                    Response = dto,
                    Status = ResponseStatus.SUCCESS
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error!");
                return await Task.FromResult(new CreatedProductResponse { Status = ResponseStatus.ERROR } );
            }
        }

        public Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
