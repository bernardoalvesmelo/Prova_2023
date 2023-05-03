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