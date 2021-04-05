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
using ControleProdutosWEBAPI.Domain.Query;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Domain.Handler
{
    public class FindProdutoReportHandler : IRequestHandler<FindProdutoReportRequest, FindProdutoReportResponse>
    {
        private readonly ApplicationDbContext _context;

        public FindProdutoReportHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<FindProdutoReportResponse> Handle(FindProdutoReportRequest request, CancellationToken cancellationToken)

        {
            var report = (from p in _context.Produto
                          join c in _context.Categoria
                          on p.CategoriaFK equals c.Categoria_Id
                          where (c.Categoria_Id == request.CategoriaId)
                          select new ProdutoReportData
                          {
                              ProdutoID = p.Produto_id,
                              NomeCategoria = c.Nome,
                              NomeProduto = p.Nome,
                              Descricao = p.Descricao,
                              Valor = p.Preco
                          }).ToList();

            return Task.FromResult(new FindProdutoReportResponse { Response = report });
        }
    }
}
