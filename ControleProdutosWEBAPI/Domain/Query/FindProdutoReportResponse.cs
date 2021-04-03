using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Domain.Query
{
    public class FindProdutoReportResponse
    {
        public int ProdutoID { get; set; }
        public String NomeCategoria { get; set; }
        public String NomeProduto { get; set; }
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
