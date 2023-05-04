using System.Collections;
using Prova.ModuloProduto;
using Prova.ModuloCompartilhado;

namespace Prova.ModuloConta
{
    public class Pedido : EntidadeBase
    {
        static private int id = 0;

        public Produto PedidoProduto { get; set; }
        public string Nome { get; set; }

        public double ValorUnidade { get; set; }

        public double ValorTotal { get; set; }

        public int Quantidade { get; set; }

        public Pedido()
        {
            ObterId(ref id);
        }

        public Pedido(int id)
        {
            Id = id;
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, (Quantidade + ""), "R$: " + (Math.Round(ValorUnidade, 2) + ""), 
                "R$: " + (Math.Round(ValorTotal, 2) + "") };
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Pedido pedido = (Pedido)entidade;
            PedidoProduto = pedido.PedidoProduto;
            Nome = pedido.Nome;
            Quantidade = pedido.Quantidade;
            ValorUnidade = pedido.ValorUnidade;
            ValorTotal = pedido.ValorTotal;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                erros.Add("O campo nome é obrigatório");
            }

            if (Quantidade <= 0)
            {
                erros.Add("O campo quantidade não pode ser menor que zero");
            }

            if (ValorUnidade < 0)
            {
                erros.Add("O campo valorUnidade não pode ser negativo");
            }

            if (ValorTotal < 0)
            {
                erros.Add("O campo valorTotal não pode ser negativo");
            }

            return erros;
        }

        public override Pedido ObterNovaInstancia()
        {
            return new Pedido(Id);
        }

    }
}