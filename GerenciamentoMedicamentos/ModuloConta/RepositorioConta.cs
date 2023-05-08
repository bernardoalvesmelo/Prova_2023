using Prova.ModuloCompartilhado;

namespace Prova.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public List<Conta> ListaFechada { get; set; }
        private int contadorPedidos;

        public RepositorioConta()
        {
            this.ListaFechada = new List<Conta>();
            this.contadorPedidos = 0;
        }
        public void FecharConta(Conta conta)
        {
            ListaFechada.Add(conta);
            Lista.Remove(conta);
        }

        public void InserirContaPedido(Conta conta, Pedido pedido)
        {
            contadorPedidos++;
            pedido.Id = contadorPedidos;
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
            return ListaFechada.FindAll(conta => data == conta.DataFechamento);
        }
    }
}
