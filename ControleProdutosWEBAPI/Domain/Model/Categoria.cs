using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleProdutosWEBAPI.Model
{
    public class Categoria
    {
        [Key]
        public int Categoria_Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
