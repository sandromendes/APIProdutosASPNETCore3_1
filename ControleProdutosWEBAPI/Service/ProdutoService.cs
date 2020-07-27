using ControleProdutosWEBAPI.Context;
using ControleProdutosWEBAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Service
{
    public class ProdutoService : IProdutoService
    {
        public ApplicationDbContext _context;

        public ProdutoService()
        {
            _context = new ApplicationDbContext();
        }
        public List<Produto> GetProdutos()
        {
            return _context.Produto.ToList<Produto>();
        }

        public void AddProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public void UpdateProduto(int id, Produto produto)
        {
            Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);

            if (produtoBase != null)
            {
                _context.Produto.Update(produto);
            }
        }

        public void DeleteProduto(int id)
        {
            Produto produtoBase = _context.Produto.Single(p => p.Produto_id == id);

            if (produtoBase != null)
            {
                _context.Produto.Remove(produtoBase);
            }
        }
    }
}
