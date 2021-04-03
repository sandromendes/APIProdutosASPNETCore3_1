using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Model
{
    public class Produto
    {
        [Key]
        public int Produto_id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Decimal Preco { get; set; }

        public int CategoriaFK {get; set;}
        public Categoria Categoria { get; set; }
    }
}
