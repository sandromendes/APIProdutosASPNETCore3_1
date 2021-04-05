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

using ControleProdutosWEBAPI.Domain.Command;
using ControleProdutosWEBAPI.Model;
using ControleProdutosWEBAPI.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Domain.Handler
{
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoRequest, CreateProdutoResponse>
    {
        private readonly IProdutoRepository _repository;

        public CreateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateProdutoResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = new Produto { 
                    CategoriaFK = request.CategoriaFK,
                    Descricao = request.Descricao,
                    Nome = request.Nome,
                    Preco = request.Preco,
                    Quantidade = request.Quantidade
                };

                _repository.AddProduto(produto);
            
                var response = new CreateProdutoResponse { 
                    ProdutoID = produto.Produto_id,
                    Categoria = produto.Categoria,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade
                };

                return Task.FromResult(response);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar o produto. Consulte o LOG para detalhes.");
            }
        }
    }
}
