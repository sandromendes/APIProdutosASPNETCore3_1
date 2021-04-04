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

using ControleProdutosWEBAPI.Context;
using ControleProdutosWEBAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleProdutosWEBAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public ApplicationDbContext _context;

        public ProdutoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool GetProdutos(out List<Produto> listagem)
        {
            listagem = _context.Produto.ToList();

            if (listagem.Any())
                return true;

            return false;
        }

        public bool GetProduto(int id, out Produto produto)
        {
            try
            {
                produto = _context.Produto
                    .Where(p => p.Produto_id == id)
                    .Include(p => p.Categoria)
                    .Single();

                return true;
            }
            catch (Exception)
            {
                produto = new Produto();
                return false;
            }
        }

        public bool GetProdutoByCategoriaId(int id, out List<Produto> listagem)
        {
            listagem = _context.Produto
                .Where(p => p.CategoriaFK == id)
                .ToList();

            if(listagem.Any())
                return true;

            return false;
        }

        public void AddProduto(Produto produto)
        {
            try
            {
                _context.Produto.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateProduto(int id, Produto produto)
        {
            try
            {
                Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);
                _context.Attach(produtoBase);

                produtoBase.Nome = produto.Nome;
                produtoBase.Descricao = produto.Descricao;
                produtoBase.Preco = produto.Preco;
                
                _context.Produto.Update(produtoBase);
                _context.SaveChanges();

                produto.Produto_id = produtoBase.Produto_id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteProduto(int id)
        {
            try
            {
                Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);

                if (produtoBase != null)
                {
                    _context.Produto.Remove(produtoBase);
                    _context.SaveChanges();
                } 
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
