using MRV.Modas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MRV.Modas
{
    public class ProdutoModel
    {
        public long? ProdutoID { get; set; }
        public Guid ProdutoIDGUID { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public CategoriaModel? Categoria { get; set; }
        public static readonly List<ProdutoModel> produtos = new List<ProdutoModel>();
    }
}