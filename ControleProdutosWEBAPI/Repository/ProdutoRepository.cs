using ControleProdutosWEBAPI.Context;
using ControleProdutosWEBAPI.Domain.Handler;
using ControleProdutosWEBAPI.Domain.Query;
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
            listagem = _context.Produto.ToList<Produto>();

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

        public bool GetProdutoReport(out IList<FindProdutoReportResponse> response,
            FindProdutoReportRequest request)
        {
            response = new FindProdutoReportHandler(request).Handle();

            if (response.Any())
                return true;

            return false;
        }

        public bool AddProduto(Produto produto)
        {
            try
            {
                _context.Produto.Add(produto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduto(int id, Produto produto)
        {
            try
            {
                Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);
                _context.Attach<Produto>(produtoBase);

                produtoBase.Nome = produto.Nome;
                produtoBase.Descricao = produto.Descricao;
                produtoBase.Preco = produto.Preco;
                
                _context.Produto.Update(produtoBase);
                _context.SaveChanges();

                produto.Produto_id = produtoBase.Produto_id;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduto(int id)
        {
            Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);

            if (produtoBase != null)
            {
                _context.Produto.Remove(produtoBase);
                _context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }

    }
}
