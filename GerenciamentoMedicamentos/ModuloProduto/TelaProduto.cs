using Prova.ModuloCompartilhado;

namespace Prova.ModuloProduto
{

    public class TelaProduto : TelaBase<Produto>
    {


        public TelaProduto(RepositorioProduto repositorio) : base(repositorio)
        {
            titulo = "Produtos";
            nomeEntidade = "Produto";
            string[] cabecalho = { "Id:", "Nome:", "Valor:" };
            Cabecalho = cabecalho;
        }

        public override Produto RegistrarEntidade()
        {
            Produto produto = new Produto();
            PreencherAtributos(produto);
            return produto;
        }

        public override void PreencherAtributos(Produto produto)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
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
