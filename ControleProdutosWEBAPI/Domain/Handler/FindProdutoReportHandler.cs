using ControleProdutosWEBAPI.Context;
using ControleProdutosWEBAPI.Domain.Query;
using System.Collections.Generic;
using System.Linq;

namespace ControleProdutosWEBAPI.Domain.Handler
{
    public class FindProdutoReportHandler
    {
        public ApplicationDbContext _context;
        private readonly FindProdutoReportRequest _request;

        public FindProdutoReportHandler(FindProdutoReportRequest request)
        {
            _context = new ApplicationDbContext();
            _request = request;
        }

        public IList<FindProdutoReportResponse> Handle()
        {
            var report = (from p in _context.Produto
                          join c in _context.Categoria
                          on p.CategoriaFK equals c.Categoria_Id
                          where (c.Categoria_Id == _request.CategoriaId)
                          select new FindProdutoReportResponse
                          {
                              ProdutoID = p.Produto_id,
                              NomeCategoria = c.Nome,
                              NomeProduto = p.Nome,
                              Descricao = p.Descricao,
                              Valor = p.Preco
                          }).ToList();


            return report;
        }
    }
}
