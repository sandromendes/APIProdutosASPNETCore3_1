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
using ControleProdutosWEBAPI.Domain.Handler.Interfaces;
using ControleProdutosWEBAPI.Model;
using ControleProdutosWEBAPI.Repository;
using System;

namespace ControleProdutosWEBAPI.Domain.Handler
{
    public class CreateProdutoHandler : ICreateProdutoHandler
    {
        private readonly IProdutoRepository _repository;

        public CreateProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public CreateProdutoResponse Handle(CreateProdutoRequest command)
        {
            try
            {
                var produto = new Produto { 
                    CategoriaFK = command.CategoriaFK,
                    Descricao = command.Descricao,
                    Nome = command.Nome,
                    Preco = command.Preco,
                    Quantidade = command.Quantidade
                };

                _repository.AddProduto(produto);
            
                return new CreateProdutoResponse { 
                    ProdutoID = produto.Produto_id,
                    Categoria = produto.Categoria,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade
                };
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar o produto. Consulte o LOG para detalhes.");
            }
        }
    }
}
