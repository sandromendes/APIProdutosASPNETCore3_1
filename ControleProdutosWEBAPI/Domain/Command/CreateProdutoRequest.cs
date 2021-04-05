﻿/**
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

using MediatR;
using System;

namespace ControleProdutosWEBAPI.Domain.Command
{
    public class CreateProdutoRequest : IRequest<CreateProdutoResponse>
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Decimal Preco { get; set; }
        public int CategoriaFK { get; set; }
    }
}
