using System.Collections;
using System.Globalization;
using Prova.ModuloCompartilhado;

namespace Prova.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public List<Conta> ListaFechada { get; set; }

        public RepositorioConta()
        {
            this.ListaFechada = new List<Conta>();
        }

        public override Conta EncontrarRegistro(int id)
        {
            return base.EncontrarRegistro(id);
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

        public List<Conta> ObterFaturamentoDia(DateTime data)
        {

            List<Conta> listaFaturamento = new List<Conta>();
            foreach (Conta conta in ListaFechada)
            {
                if (
                    data == conta.DataFechamento
                )
                {
                    listaFaturamento.Add(conta);
                }
            }
            return listaFaturamento;
        }
    }
}
