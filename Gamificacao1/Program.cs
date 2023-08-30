using System;
using System.Collections.Generic;
using MRV.Modas;

namespace MRV.Modas
{
    public class Program
    {

        static void Main(string[] args)
        {
            
                    case "3":
                        ClientesUI clienteUI = new();
                        clienteUI.GerenciarClientes();
                        break;
                    case "4":
                        VendaUI vendaUI = new();
                        vendaUI.RealizarVenda();
                        break;
                    case "5":
                        RelatorioUI relatorioUI = new();
                        relatorioUI.MostrarRelatorioVendas();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }




    }
}