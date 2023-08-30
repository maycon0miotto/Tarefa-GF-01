﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MRV.Modas
{

    public class ClientesUI
    {
        public void GerenciarClientes()
        {
            bool continuar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Listar clientes");
                Console.WriteLine("2 - Cadastrar cliente");
                Console.WriteLine("3 - Alterar cliente");
                Console.WriteLine("4 - Excluir cliente");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarClientes();
                        break;
                    case "2":
                        CadastrarCliente();
                        break;
                    case "3":
                        AlterarCliente();
                        break;
                    case "4":
                        ExcluirCliente();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (continuar);
        }

        private void ListarClientes()
        {
            Console.Clear();

            try
            {
                if (ClienteModel.clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Lista de clientes:");
            foreach (var cliente in ClienteModel.clientes)
            {
                Console.WriteLine($"ID: {cliente.ClienteID} | Nome Completo: {cliente.NomeCompleto} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        private void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de cliente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            var proximoID = ClienteModel.clientes.Max((e) => e.ClienteID) + 1;

            ClienteModel cliente = new ClienteModel
            {
                ClienteID = proximoID ?? 1,
                ClienteIDGUID = Guid.NewGuid(),
                Nome = nome,
                Sobrenome = sobrenome,
                Endereco = endereco,
                Telefone = telefone
            };
            ClienteModel.clientes.Add(cliente);
            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        private void AlterarCliente()
        {
            Console.Clear();

            try
            {
                if (ClienteModel.clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Alterar cliente");

            long id;

            while (true)
            {
                Console.Write("ID do cliente: ");
                try
                {
                    id = long.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ID inválido. Digite um valor numérico válido.");
                }
            }

            ClienteModel cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);

            while (cliente == null)
            {
                Console.Write("\nCliente não encontrada!\nDigite novamente o código do cliente: ");
                id = long.Parse(Console.ReadLine());
                cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);
            }

            Console.Write($"Digite o novo nome ({cliente.Nome}): ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o novo sobrenome ({cliente.Sobrenome}): ");
            string sobrenome = Console.ReadLine();

            Console.Write($"Digite o novo endereço({cliente.Endereco}): ");
            string endereco = Console.ReadLine();

            Console.Write($"Digite o novo telefone ({cliente.Telefone}): ");
            string telefone = Console.ReadLine();

            cliente.Nome = nome;
            cliente.Sobrenome = sobrenome;
            cliente.Endereco = endereco;
            cliente.Telefone = telefone;
            Console.WriteLine("Cliente alterado com sucesso!");
        }

        private void ExcluirCliente()
        {
            Console.Clear();

            try
            {
                if (ClienteModel.clientes.Count == 0)
                {
                    throw new Exception("Não há nenhum cliente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Excluir cliente");

            long id;

            while (true)
            {
                Console.Write("ID do cliente: ");
                try
                {
                    id = long.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ID inválido. Digite um valor numérico válido.");
                }
            }

            ClienteModel cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);

            while (cliente == null)
            {
                Console.Write("\nCliente não encontrado!\nDigite novamente o código do cliente: ");
                id = long.Parse(Console.ReadLine());
                cliente = ClienteModel.clientes.Find(c => c.ClienteID == id);
            }

            ClienteModel.clientes.Remove(cliente);
        }

    }
}