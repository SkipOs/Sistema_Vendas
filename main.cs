using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemavenda { 
//Declaração de Classes (Cliente, Produto e Venda)
class Cliente
{
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
}

class Produto
{
        public int Codigo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
    }

class Venda
{
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public List<int> l_CodigoProdutos { get; set; }
    }

// Programa/Main
internal class Sistema
{
    // Declaração de lista das classes de acordo com o tipo
    static List<Cliente> l_clientes = new List<Cliente>();
    static List<Produto> l_produtos = new List<Produto>();
    static List<Venda> l_vendas = new List<Venda>();

    // Valor de incrementação de vendas
    int CodigoVenda = 0;

    static void Main(string[] args)
    {
        while (true)
        {

        //Menu aqui
        Console.WriteLine(@"====== MenuFácil ======
1 - Cadastrar Cliente
2 - Buscar Cliente
3 - Listar Cliente
4 - Deletar Cliente

5 - Cadastrar Produto
6 - Buscar Produto
7 - Listar Produto
8 - Deletar Produto

9 - Cadastrar Venda
10 - Buscar Venda
11 - Listar Vendas
12 - Total de Vendas

0 - Sair
Selecione uma opção: ");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                    // Cliente
                case 1:
                        CadastroCliente();
                    break;
                case 2:
                        BuscaCliente();
                    break;
                case 3:
                    break;
                case 4:
                    break;

                    // Produto
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;

                    // Vendas
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;

                    // Saídas anormais
                case 0:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção Inválida, verifique o valor inserido.\n");
                    break;
            }

        }
    }
        static void CadastroCliente()
        {
            Console.Clear();
            Cliente cliente = new Cliente();

            // Recebe nova instâncoa de cliente

            Console.Write("Código do Cliente: ");
            cliente.Codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome do Cliente: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Idade do Cliente: ");
            cliente.Idade = int.Parse(Console.ReadLine());

            Console.Write("CPF do Cliente: ");
            cliente.CPF = Console.ReadLine();

            // Instancia o novo cliente recebido
            Console.Clear();
            l_clientes.Add(cliente);
            Console.WriteLine("Cliente Cadastrado com SUCESSO!\n");
        }

        static void BuscaCliente()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Cliente: ");
            int c_cliente = int.Parse(Console.ReadLine());

            // Busca o cliente na lista
            Cliente cliente = l_clientes.Find(x => x.Codigo == c_cliente);

            // Exibe info do cliente se existente
            if (cliente != null)
            {
                Console.WriteLine($"Código: {cliente.Codigo}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Idade: {cliente.Idade} anos");
                Console.WriteLine($"CPF: {cliente.CPF}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.")
            }
        }

}
}
