using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MRV.Modas
{
    public class VendaUI
    {
        public void RealizarVenda()
        {
            Console.Clear();

            try
            {
                if (ProdutoModel.produtos.Count == 0)
                {
                    throw new Exception("Não há nenhum produto cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Realizar venda:");

            // Seleciona um cliente existente ou cadastra um novo
            ClienteModel cliente = SelecionarCliente();

            // Cria uma nova venda
            VendaModel venda = new VendaModel();
            venda.VendaIDGUID = Guid.NewGuid();
            venda.Data = DateTime.Now;
            venda.Cliente = cliente;
            var proximoId = VendaModel.vendas.Max((v) => v.VendaID) + 1;
            venda.VendaID = proximoId ?? 1;

            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine($"Venda nº {venda.VendaID} - Cliente: {venda.Cliente.Nome}");
                Console.WriteLine();
                ProdutoUI.ListarProdutos();

                Console.WriteLine();
                Console.WriteLine("Digite o ID do produto que deseja comprar (0 para finalizar):");
                int idProduto = int.Parse(Console.ReadLine());

                if (idProduto == 0)
                {
                    // Finaliza a venda
                    VendaModel.vendas.Add(venda);
                    Console.WriteLine($"Venda finalizada. Total: R${venda.Total}");
                    continuar = false;
                }
                else
                {
                    // Seleciona o produto a ser comprado
                    ProdutoModel produto = ProdutoModel.produtos.Find(p => p.ProdutoID == idProduto);
                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado!");
                    }
                    else
                    {
                        // Pede a quantidade desejada
                        Console.WriteLine($"Digite a quantidade de {produto.Nome} que deseja comprar:");
                        int quantidade = int.Parse(Console.ReadLine());

                        // Adiciona o item à venda
                        var VendaId = venda.produtos.Max(i => i.VendaProdutoID) + 1;
                        VendaProdutoModel item = new VendaProdutoModel
                        {
                            VendaProdutoID = VendaId ?? 1,
                            Produto = produto,
                            Quantidade = quantidade,
                            PrecoUnitario = produto.Preco
                        };

                        venda.produtos.Add(item);

                        Console.WriteLine($"{quantidade}X {produto.Nome} adicionado(s) à venda!");

                    }
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        private ClienteModel SelecionarCliente()
        {
            Console.Clear();
            Console.WriteLine("Selecione o cliente:");

            foreach (var cliente in ClienteModel.clientes)
            {
                Console.WriteLine($"ID: {cliente.ClienteID} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
            }

            Console.Write("Digite o ID do cliente ou 0 para voltar: ");
            int idCliente;
            while (!int.TryParse(Console.ReadLine(), out idCliente) || (idCliente != 0 && !ClienteModel.clientes.Exists(c => c.ClienteID == idCliente)))
            {
                Console.WriteLine("ID inválido! Digite novamente...");
                Console.Write("Digite o ID do cliente ou 0 para voltar: ");
            }
            if (idCliente == 0)
            {
                return null;
            }
            else
            {
                return ClienteModel.clientes.Find(c => c.ClienteID == idCliente);
            }
        }
    }

}
