using System.Collections;
using Prova.ModuloCompartilhado;

namespace Prova.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        static private int id = 0;

        public string Nome { get; set; }

        public double ValorUnidade { get; set; }

        public Produto()
        {
            ObterId(ref id);
        }

        public Produto(int id)
        {
            Id = id;
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, "R$: " + (Math.Round(ValorUnidade, 2) + "")};
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Produto produto = (Produto)entidade;
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

        public override Produto ObterNovaInstancia()
        {
            return new Produto(Id);
        }
    }
}