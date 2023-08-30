using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MRV.Modas
{
    public class RelatorioUI
    {
        public void MostrarRelatorioVendas()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Vendas:");

            try
            {
                if (VendaModel.vendas.Count == 0)
                {
                    throw new Exception("Não há nenhuma venda registrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            double totalVendas = 0;

            foreach (var venda in VendaModel.vendas)
            {
                Console.WriteLine($"ID da venda: {venda.VendaID} | Data: {venda.Data} | Cliente: {venda.Cliente.Nome}");

                foreach (var itemVenda in venda.produtos)
                {
                    Console.WriteLine($"   - Produto: {itemVenda.Produto.Nome} | Quantidade: {itemVenda.Quantidade} | Preço unitário: {itemVenda.PrecoUnitario:C2} | Subtotal: {itemVenda.Subtotal:C2}");
                }

                Console.WriteLine($"   Total da venda: {venda.Total:C2}");
                Console.WriteLine();

                totalVendas += venda.Total;
            }

            Console.WriteLine($"Total de vendas: {VendaModel.vendas.Count} | Valor total das vendas: {totalVendas:C2}");

        }
    }

}
