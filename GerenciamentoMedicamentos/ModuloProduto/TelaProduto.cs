using Prova.ModuloCompartilhado;
using Prova.ModuloConta;

namespace Prova.ModuloProduto
{

    public class TelaProduto : TelaBase
    {


        public TelaProduto(RepositorioBase repositorio) : base(repositorio)
        {
            titulo = "Produtos";
            nomeEntidade = "Produto";
            string[] cabecalho = { "Id:", "Nome:", "Valor:" };
            Cabecalho = cabecalho;
        }

        public void Opcoes()
        {
            while (true)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Produto registrado!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe produtos registrados no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        AtualizarEntidade();
                        Console.WriteLine("Produto atualizado!");
                        Console.ReadLine();
                        break;
                    case "4":
                        if (repositorio.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe produtos registradas no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        RemoverEntidade();
                        Console.WriteLine("Produto removido!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public override EntidadeBase RegistrarEntidade()
        {
            Produto produto = new Produto();
            PreencherAtributos(produto);
            return produto;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Produto produto = (Produto)entidade;
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                produto.Nome = nome;
                double valorUnidade = ValidarDouble("Digite o valor da unidade: ");
                produto.ValorUnidade = valorUnidade;
                entidadeValida = ValidarEntidade(produto);
            } 
        }
    }
}
