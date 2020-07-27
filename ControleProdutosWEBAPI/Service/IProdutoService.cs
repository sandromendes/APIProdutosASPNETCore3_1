using ControleProdutosWEBAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Service
{
    public interface IProdutoService
    {
        public List<Produto> GetProdutos();
        public void AddProduto(Produto produto);
        public void UpdateProduto(int id, Produto produto);
        public void DeleteProduto(int id);
    }
}
