using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRV.Modas
{
    public class VendaModel
    {
        public long? VendaID { get; set; }
        public Guid VendaIDGUID { get; set; }
        public DateTime Data { get; set; }
        public ClienteModel? Cliente { get; set; }
        public List<VendaProdutoModel> produtos { get; set; } = new List<VendaProdutoModel>();
        public static readonly List<VendaModel> vendas = new List<VendaModel>();
        public double Total
        {
            get
            {
                try
                {
                    return produtos!.Sum(p => p.Subtotal);
                }
                catch (NullReferenceException nrfe)
                {
                    throw new Exception($"Nota sem venda: {nrfe.Message}");
                }
            }
        }
    }
}
