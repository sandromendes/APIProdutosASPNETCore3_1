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

using System;
using System.Collections.Generic;

namespace ControleProdutosWEBAPI.Domain.Query
{
    public class FindProdutoReportResponse
    {
        public IList<ProdutoReportData> Response { get; set; }
    }

    public class ProdutoReportData
    {
        public int ProdutoID { get; set; }
        public String NomeCategoria { get; set; }
        public String NomeProduto { get; set; }
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
