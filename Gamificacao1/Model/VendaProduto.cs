using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRV.Modas
{
    public class VendaProdutoModel
    {
        public long? VendaProdutoID { get; set; }
        public ProdutoModel Produto { get; set; }
        public double Quantidade { get; set; }
        public double PrecoUnitario { get; set; }

        public double Subtotal
        {
            get { return Quantidade * PrecoUnitario; }
        }
    }
}