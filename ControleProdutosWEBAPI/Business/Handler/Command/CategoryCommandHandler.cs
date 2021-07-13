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

using ControleProdutosWEBAPI.Infra.UnitOfWork.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductControlAPI.Domain.Command.Category;
using System.Threading;
using System.Threading.Tasks;

namespace ProductControlAPI.Business.Handler.Command
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, CreateCategoryReponse>,
        IRequestHandler<UpdateCategoryCommand, UpdateCategoryReponse>,
        IRequestHandler<DeleteCategoryCommand, DeleteCategoryReponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CategoryCommandHandler> _logger;

        public CategoryCommandHandler(IUnitOfWork uow, ILogger<CategoryCommandHandler> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public Task<CreateCategoryReponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<UpdateCategoryReponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<DeleteCategoryReponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
