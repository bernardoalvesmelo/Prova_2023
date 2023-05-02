using System.Collections;
using System.Globalization;
using Prova.ModuloCompartilhado;

namespace Prova.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public ArrayList ListaFechada { get; set; }

        public RepositorioConta()
        {
            this.ListaFechada = new ArrayList();
        }

        public override Conta EncontrarRegistro(int id)
        {
            return (Conta)base.EncontrarRegistro(id);
        }

        public void FecharConta(Conta conta)
        {
            ListaFechada.Add(conta);
            Lista.Remove(conta);
        }

        public void InserirContaPedido(Conta conta, Pedido pedido)
        {
            conta.PedidosLista.Add(pedido);
        }

        public void RemoverContaPedido(Conta conta, Pedido pedido)
        {
            conta.PedidosLista.Remove(pedido);
        }

        public  void EditarPedido(
           Pedido pedido, Pedido pedidoAtualizado
       )
        {
            pedido.Atualizar(pedidoAtualizado);
        }

        public double ObterFaturamentoDia(DateTime data)
        {
            double soma = 0;
            string dataString = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime hoje = data;
            foreach (Conta conta in ListaFechada)
            {
                if (
                    hoje == conta.DataFechamento
                )
                {
                    soma += conta.TotalConta;
                }
            }
            return soma;
        }
    }
}
