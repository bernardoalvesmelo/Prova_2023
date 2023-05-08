using Prova.ModuloGarcom;
using Prova.ModuloMesa;

namespace Prova.ModuloConta
{
    public class Conta : EntidadeBase<Conta>
    {

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

        public double TotalConta
        {
            get
            {
                return PedidosLista.Sum(p => p.ValorTotal);
            }
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""),  Enum.GetName(typeof(TipoConta), Tipo), ContaGarcom.Nome,
                ("Mesa: " + ContaMesa.Numero), "R$: " + (Math.Round(TotalConta, 2) + ""),
                DataFechamento == DateTime.MinValue ? "Em Aberto": DataFechamento.ToString("dd/MM/yyyy")};
            return atributos;
        }

        public override void Atualizar(Conta conta)
        {
            Tipo = conta.Tipo;
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
    }
}