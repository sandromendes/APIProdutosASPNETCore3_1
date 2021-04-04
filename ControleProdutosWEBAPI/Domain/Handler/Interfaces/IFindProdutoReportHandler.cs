using ControleProdutosWEBAPI.Domain.Query;
using System.Collections.Generic;

namespace ControleProdutosWEBAPI.Domain.Handler.Interfaces
{
    public interface IFindProdutoReportHandler
    {
        IList<FindProdutoReportResponse> Handle(FindProdutoReportRequest request);
    }
}
