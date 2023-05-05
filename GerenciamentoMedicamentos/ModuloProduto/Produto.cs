using System.Collections;
using Prova.ModuloCompartilhado;

namespace Prova.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {

        public string Nome { get; set; }

        public double ValorUnidade { get; set; }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, "R$: " + (Math.Round(ValorUnidade, 2) + "")};
            return atributos;
        }

        public override void Atualizar(Produto produto)
        {
            Nome = produto.Nome;
            ValorUnidade = produto.ValorUnidade;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                erros.Add("O campo nome é obrigatório");
            }

            if (ValorUnidade < 0)
            {
                erros.Add("O campo valorUnidade não pode ser negativo");
            }

            return erros;
        }

    }
}