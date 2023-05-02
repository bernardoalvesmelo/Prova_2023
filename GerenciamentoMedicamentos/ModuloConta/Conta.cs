using System.Collections;
using Prova.ModuloCompartilhado;
using Prova.ModuloGarcom;
using Prova.ModuloMesa;

namespace Prova.ModuloConta
{
    public class Conta : EntidadeBase
    {
        static private int id = 0;

        public string Tipo;

        public Garcom ContaGarcom { get; set; }

        public Mesa ContaMesa { get; set; }

        public ArrayList PedidosLista { get; set; }

        public DateTime DataFechamento { get; set; }

        public double TotalConta { get
            {
                double soma = 0;
                foreach(Pedido pedido in PedidosLista)
                {
                    soma += pedido.ValorTotal;
                }
                return soma;
            } 
            }

        public Conta()
        {
            ObterId(ref id);
        }

        public Conta(int id)
        {
            Id = id;
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Tipo, ContaGarcom.Nome, ("Mesa: " + ContaMesa.Numero), 
                "R$: " + (Math.Round(TotalConta, 2) + ""), 
                DataFechamento.Year == 1 ? "Em Aberto": DataFechamento.ToString("dd/mm/yyyy")};
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Conta conta = (Conta)entidade;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Tipo.Trim()))
            {
                erros.Add("O campo tipo é obrigatório");
            }

            DateTime hoje = DateTime.Now.Date;

            if (DataFechamento > hoje)
            {
                erros.Add("O campo dataFechamento não pode ser maior que a data atual");
            }

            return erros;
        }

        public override Conta ObterNovaInstancia()
        {
            return new Conta(Id);
        }

    }
}