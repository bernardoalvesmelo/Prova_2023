using Prova.ModuloConta;
using Prova.ModuloMesa;
using Prova.ModuloGarcom;
using Prova.ModuloProduto;

namespace Prova
{
    internal class Program
    {

        static public void Main(string[] args)
        {
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom();
            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);
            RepositorioMesa repositorioMesa = new RepositorioMesa();
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            RepositorioConta repositorioConta = new RepositorioConta();
            RepositorioProduto repositorioProduto = new RepositorioProduto();
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta,
                telaGarcom,
                telaMesa,
                telaProduto);
            bool continuar = true;
            InserirRegistrosIniciais(repositorioGarcom, repositorioMesa, repositorioConta, repositorioProduto);
            while (continuar)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        continuar = false;
                        break;
                    case "1":
                        telaGarcom.Opcoes();
                        break;
                    case "2":
                        telaMesa.Opcoes();
                        break;
                    case "3":
                        telaProduto.Opcoes();
                        break;
                    case "4":
                        telaConta.Opcoes();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        continue;
                }
            }
        }

        private static void InserirRegistrosIniciais(RepositorioGarcom repositorioGarcom, RepositorioMesa repositorioMesa, RepositorioConta repositorioConta, RepositorioProduto repositorioProduto)
        {
            Garcom garcom = new Garcom();
            garcom.Nome = "Jack";
            garcom.Idade = 22;
            repositorioGarcom.InserirRegistro(garcom);

            Mesa mesa = new Mesa();
            mesa.Numero = 321;
            mesa.Tipo = "Madeira";
            repositorioMesa.InserirRegistro(mesa);

            Produto produto = new Produto();
            produto.ValorUnidade = 2;
            produto.Nome = "Bolacha";
            repositorioProduto.InserirRegistro(produto);

            Conta conta = new Conta();
            conta.ContaGarcom = garcom;
            conta.ContaMesa = mesa;
            conta.Tipo = (Conta.TipoConta)Enum.Parse(typeof(Conta.TipoConta), "ESPECIAL");
            conta.PedidosLista = new List<Pedido>();
            repositorioConta.InserirRegistro(conta);

            Pedido pedido = new Pedido();
            pedido.Nome = produto.Nome;
            pedido.Quantidade = 3;
            pedido.ValorUnidade = produto.ValorUnidade;
            pedido.ValorTotal = pedido.ValorUnidade * pedido.Quantidade;
            repositorioConta.InserirContaPedido(conta, pedido);
        }

        static void MostrarMenu()
        {
            string[] menu =
            {
            "Gerenciamento de Bar",
            "0-Sair",
            "1-Cadastrar Garçom",
            "2-Cadastrar Mesa",
            "3-Cadastrar Produto",
            "4-Cadastrar Conta",
        };
            Console.Clear();
            foreach (string opcao in menu)
            {
                Console.WriteLine(opcao);
            }

            Console.Write("Digite a opção desejada: ");
        }
    }
}