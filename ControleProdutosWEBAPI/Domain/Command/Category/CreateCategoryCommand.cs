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
using ProductControlAPI.Domain.Common;
using ProductControlAPI.Domain.DTO;

namespace ProductControlAPI.Domain.Command.Category
{
    public class CreateCategoryCommand : IRequest<CreateCategoryReponse>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryReponse : ResponseBase
    {
        public CategoryDTO Response { get; set; }
    }
}
