using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistemavenda
{
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
        public float Valor { get; set; }
    }

    class Venda
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public List<int> l_CodigoProdutos { get; set; }
        public float ValorVenda { get; set; }
    }

    // Programa/Main
    internal class Sistema
    {
        // Declaração de lista das classes de acordo com o tipo
        static List<Cliente> l_clientes = new List<Cliente>();
        static List<Produto> l_produtos = new List<Produto>();
        static List<Venda> l_vendas = new List<Venda>();

        // Valor de incrementação de vendas
        static int CodigoVenda = 0;

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

                int escolha = Sequestro();

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
                        ListaClientes();
                        break;
                    case 4:
                        AdeusCliente();
                        break;

                    // Produto
                    case 5:
                        CadastroProduto();
                        break;
                    case 6:
                        BuscaProduto();
                        break;
                    case 7:
                        ListaProduto();
                        break;
                    case 8:
                        AdeusProduto();
                        break;

                    // Vendas
                    case 9:
                        CadastroVenda();
                        break;
                    case 10:
                        BuscaVenda();
                        break;
                    case 11:
                        ListarVenda();
                        break;
                    case 12:
                        TotalVendas(0);
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
        static int Sequestro() //Função Trycatch (evitar ter que escrever mil vezes)
        {
            int Refem;
            while(true) // Repete o processo até que o valor compatível é inserido.
            {
                try
                {
                    Refem = int.Parse(Console.ReadLine()); 
                    /// Executa parse int, se o usuário insere algo inválido aqui
                    /// o código dá erro, não executa o break, exibe a mensagem de erro
                    /// e volta a tentar "sequestrar" valores o até que o tipo exigido
                    /// seja inserido.
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // Exibe a mensagem de erro
                }
            }
            return Refem; // Retorna o valor, que todas as vezes vai ser do tipo requisisitado
        }

        static float SequestroFloat() //Função Sequestro mas para tipo floar.
        {
            float Refem;
            while (true)
            {
                try
                {
                    Refem = float.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return Refem;
        }


        // Cliente ============================================================
        static void CadastroCliente()
        {
            Console.Clear();
            Cliente cliente = new Cliente();

            // Recebe nova instância de cliente
            Console.Write("Código do Cliente: ");
            cliente.Codigo = Sequestro();

            Console.Write("Nome do Cliente: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Idade do Cliente: ");
            cliente.Idade = Sequestro();

            Console.Write("CPF do Cliente: ");
            cliente.CPF = Console.ReadLine();

            // Instancia o novo cliente recebido e o adiciona à lista de clientes existentes
            Console.Clear();
            l_clientes.Add(cliente);
            Console.WriteLine("Cliente Cadastrado com SUCESSO!\n");
            Console.WriteLine("Deseja inserir novo cliente? (1 para sim): ");
            if(Sequestro() == 1)
            {
                CadastroCliente();
            }
        }
        static void BuscaCliente()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Cliente: ");
            int c_cliente = Sequestro();

            // Busca o cliente na lista
            Cliente cliente = l_clientes.Find(x => x.Codigo == c_cliente); // Busca na lista qualquer cliente com o código sequestrado

            // Exibe info do cliente se existente
            if (cliente != null)
            {
                Console.WriteLine($"\nCódigo: {cliente.Codigo}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Idade: {cliente.Idade} anos");
                Console.WriteLine($"CPF: {cliente.CPF}");
            }
            else
            {
                Console.WriteLine("\nCliente não encontrado.");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Deseja buscar outro cliente? (1 para sim): ");
            if (Sequestro() == 1)
            {
                BuscaCliente();
            }
        }
        static void ListaClientes()
        {
            Console.Clear();
            foreach (var cliente in l_clientes)
            {
                Console.WriteLine($"{cliente.Codigo} - {cliente.Nome}");
            }
            Console.WriteLine("\n");
        }

        //Verificação da existência do cliente em alguma venda
        static bool ClienteCompra(int c_cliente)
        {
            return l_vendas.Exists(x => x.CodigoCliente == c_cliente);
        }
        static void AdeusCliente()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Cliente: ");
            int c_cliente = Sequestro();

            // Busca o cliente na lista
            Cliente cliente = l_clientes.Find(x => x.Codigo == c_cliente); // Busca na lista qualquer cliente com o código sequestrado
            
            if(cliente != null)
            {
                if (!ClienteCompra(c_cliente))
                {
                    l_clientes.Remove(cliente);
                    Console.WriteLine("\nCliente Removido.\n");
                }
                else
                {
                    Console.WriteLine("\nNão é possível remover o cliente.\n");

                }
            }
            else
            {
                Console.WriteLine("\nCliente não encontrado.\n");
            }
        }

        // Produto ===========================================================
        static void CadastroProduto()
        { 
            Console.Clear();
            Produto produto = new Produto();

            // Recebe nova instância de cliente
            Console.Write("Código do Produto: ");
            produto.Codigo = Sequestro();

            Console.Write("Marca do Produto: ");
            produto.Marca = Console.ReadLine();

            Console.Write("Modelo do Produto: ");
            produto.Modelo = Console.ReadLine();

            Console.Write("Descrição do Produto: ");
            produto.Descricao = Console.ReadLine();

            Console.Write("Valor do Produto: ");
            produto.Valor = SequestroFloat();

            // Instancia o novo cliente recebido
            Console.Clear();
            l_produtos.Add(produto);
            Console.WriteLine("Produto Cadastrado com SUCESSO!\n");
            Console.WriteLine("Deseja inserir novo produto? (1 para sim): ");
            if (Sequestro() == 1)
            {
                CadastroProduto();
            }

        }
        static void BuscaProduto()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Produto: ");
            int c_produto = Sequestro();

            // Busca o produto na lista
            Produto produto = l_produtos.Find(x => x.Codigo == c_produto); // Busca na lista qualquer produto com o código sequestrado

            // Exibe info do produto se existente
            if (produto != null)
            {
                Console.WriteLine($"\nCódigo: {produto.Codigo}");
                Console.WriteLine($"Marca: {produto.Marca}");
                Console.WriteLine($"Modelo: {produto.Modelo}");
                Console.WriteLine($"Descrição: {produto.Descricao}");
                Console.WriteLine($"Valor: R${produto.Valor}");
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado.");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Deseja buscar outro produto? (1 para sim): ");
            if (Sequestro() == 1)
            {
                BuscaProduto();
            }
        }
        static void ListaProduto()
        {
            Console.Clear();
            foreach (var produto in l_produtos)
            {
                Console.WriteLine($"{produto.Codigo} - {produto.Modelo}({produto.Marca}) R${produto.Valor}");
            }
            Console.WriteLine("\n");
        }

        //Verificação da existência do produto em alguma venda
        static bool ProdutoCompra(int c_produto)
        {
            return l_vendas.Exists(x => x.l_CodigoProdutos.Contains(c_produto));
        }
        static void AdeusProduto()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Produto: ");
            int c_produto = Sequestro();

            // Busca o produto na lista
            Produto produto = l_produtos.Find(x => x.Codigo == c_produto); // Busca na lista qualquer produto com o código sequestrado

            if (produto != null)
            {
                if (!ProdutoCompra(c_produto))
                {
                    l_produtos.Remove(produto);
                    Console.WriteLine("\nProduto Removido.\n");
                }
                else
                {
                    Console.WriteLine("\nNão é possível remover o produto.\n");

                }
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado.\n");
            }
        }

        // Vendas ==============================================================
        static void CadastroVenda()
        {
            Venda venda = new Venda(); // Instancia novavenda

            venda.Codigo = CodigoVenda; // Recebe código da venda da variável global
            CodigoVenda++; // Incrementa a bendita da variável global (Não me mata Dourado)

            Console.Write("Código do Cliente: ");
            venda.CodigoCliente = Sequestro();

            // Recepção da lista de produtos dessa venda instanciada
            venda.l_CodigoProdutos = new List<int>();

            while (true)
            {
                ///Recepção
                Console.WriteLine("Insira o código do produto (0 para encerrar): ");
                int temp_Produto = Sequestro();

                //Saída
                if (temp_Produto == 0)
                    break;

                if (l_produtos.Exists(x => x.Codigo == temp_Produto))   // Verificação 
                {
                    venda.l_CodigoProdutos.Add(temp_Produto);   // Adição do valor à lista (referência linha 387 e 393)
                }
                else
                {
                    Console.WriteLine("\nProduto não encontrado.\n");
                }
            }

            // Calculo de valor total da venda
            foreach (var c_produto in venda.l_CodigoProdutos)
            {
                Produto produto = l_produtos.Find(x => x.Codigo == c_produto);
                venda.ValorVenda += produto.Valor;
            }
            Console.WriteLine($"Valor total da venda: R$ {venda.ValorVenda}\n");

            // Adiciona a nova venda à lista de vendas
            l_vendas.Add(venda);
            Console.WriteLine("Venda cadastrada.\n");
        }
        static void BuscaVenda()
        {
            Console.Clear();
            Console.WriteLine("Informe o código do Produto: ");
            int c_venda = Sequestro();

            // Busca o cliente na lista
            Venda venda = l_vendas.Find(x => x.Codigo == c_venda); // Busca na lista qualquer venda com o código sequestrado
            // Exibe info da venda se existente
            if (venda != null)
            {
                Cliente cliente = l_clientes.Find(x => x.Codigo == venda.CodigoCliente); // Encontra o cliente

                Console.WriteLine($"\nCódigo Da Venda: {venda.Codigo}");
                Console.WriteLine($"Cliente: {cliente.Nome}");
                Console.WriteLine("Produtos vendidos nessa venda:");

                foreach(var c_produto in venda.l_CodigoProdutos)
                {
                    Produto produto = l_produtos.Find(x => x.Codigo == c_produto); // Encontra o cliente
                    Console.WriteLine($"{produto.Codigo} - {produto.Modelo} ({produto.Marca}) R$ {produto.Valor}");
                }
            }
            else
            {
                Console.WriteLine("\nProduto não encontrado.");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Deseja buscar outra venda? (1 para sim): ");
            if (Sequestro() == 1)
            {
                BuscaProduto();
            }
        }
        static void ListarVenda()
        {
            Console.Clear();
            Console.WriteLine("Lista de vendas realizadas até o momento: ");
            foreach (var venda in l_vendas)
            {
                Console.WriteLine($"{venda.Codigo} - R$ {venda.ValorVenda}");
            }
        }
        static void TotalVendas(float Vtotal)
        {
            foreach(var venda in l_vendas){
                Vtotal += venda.ValorVenda;
            }
        Console.WriteLine($"Valor total das vendas: R$ {Vtotal}\n");
        }
    }
}
