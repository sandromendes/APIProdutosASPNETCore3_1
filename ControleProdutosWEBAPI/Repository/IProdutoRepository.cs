using ControleProdutosWEBAPI.Domain.Query;
using ControleProdutosWEBAPI.Model;
using System.Collections.Generic;

namespace ControleProdutosWEBAPI.Repository
{
    public interface IProdutoRepository
    {
        public bool GetProdutos(out List<Produto> listagem);
        public bool GetProduto(int id, out Produto produto);
        public bool GetProdutoByCategoriaId(int id, out List<Produto> listagem);
        public bool GetProdutoReport(out IList<FindProdutoReportResponse> response, FindProdutoReportRequest request);
        public bool AddProduto(Produto produto);
        public bool UpdateProduto(int id, Produto produto);
        public bool DeleteProduto(int id);
    }
}
