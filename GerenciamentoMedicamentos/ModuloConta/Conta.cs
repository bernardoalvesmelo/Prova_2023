using System.Collections;
using Prova.ModuloCompartilhado;
using Prova.ModuloGarcom;
using Prova.ModuloMesa;

namespace Prova.ModuloConta
{
    public class Conta : EntidadeBase
    {
        static private int id = 0;

        public enum TipoConta
        {
            ESPECIAL, 
            COMUM,
        }

        public TipoConta Tipo { get; set; }

        public Garcom ContaGarcom { get; set; }

        public Mesa ContaMesa { get; set; }

        public List<Pedido> PedidosLista { get; set; }

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
            string[] atributos = { (Id + ""),  Enum.GetName(typeof(TipoConta), Tipo), ContaGarcom.Nome, 
                ("Mesa: " + ContaMesa.Numero), "R$: " + (Math.Round(TotalConta, 2) + ""), 
                DataFechamento == DateTime.MinValue ? "Em Aberto": DataFechamento.ToString("dd/MM/yyyy")};
            return atributos;
        }

        public override void Atualizar(EntidadeBase entidade)
        {
            Conta conta = (Conta)entidade;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

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