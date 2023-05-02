
using System.Collections;

using Prova.ModuloCompartilhado;
using Prova.ModuloGarcom;
using Prova.ModuloMesa;

namespace Prova.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private TelaGarcom telaGarcom;
        private TelaMesa telaMesa;
        private RepositorioConta repositorioConta;

        public TelaConta(RepositorioConta repositorio, TelaGarcom telaGarcom, TelaMesa telaMesa) : base(repositorio)
        {
            repositorioConta = repositorio;
            titulo = "Contas";
            nomeEntidade = "Conta";
            string[] cabecalho = { "Id:", "Tipo:", "Garçom", "Número", "Total Conta R$: " };
            Cabecalho = cabecalho;
            this.telaGarcom = telaGarcom;
            this.telaMesa = telaMesa;
        }

        public void Opcoes()
        {
            while (true)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        if (telaGarcom.Quantidade <= 0)
                        {
                            Console.WriteLine("Não existe garçons registrados no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        repositorioConta.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Conta registrada!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorioConta.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe contas registradas no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        FecharConta();
                        Console.WriteLine("Conta fechada!");
                        Console.ReadLine();
                        break;
                    case "4":
                        if (repositorioConta.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe contas registradas no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        InserirPedido();
                        Console.WriteLine("Pedido registrado!");
                        Console.ReadLine();
                        break;
                    case "5":
                        if (repositorioConta.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe contas registradas no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        RemoverPedido();
                        Console.ReadLine();
                        break;
                    case "6":
                        if (repositorioConta.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe contas registradas no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        VerFaturamento();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void FecharConta()
        {

            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Conta conta = (Conta)ValidarId();
                conta.DataFechamento = ValidarData("Digite a data de fechamento");
                repositorioConta.FecharConta(conta);
                entidadeValida = ValidarEntidade(conta);
            }
        }

        private void InserirPedido()
        {

            bool entidadeValida = false;
            Pedido pedido = PreencherAtributosPedido();
            while (!entidadeValida)
            {
                Conta conta = (Conta)ValidarId();
                repositorioConta.InserirContaPedido(conta, pedido);
                entidadeValida = ValidarEntidade(conta);
            }
        }

        private void RemoverPedido()
        {

            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Conta conta = (Conta)ValidarId();
                if (conta.PedidosLista.Count < 0)
                {
                    Console.WriteLine("A conta escolhida não possui pedidos!");
                    return;
                }
                Pedido pedido = (Pedido)ValidarIdPedido(conta.PedidosLista);
                repositorioConta.RemoverContaPedido(conta, pedido);
                entidadeValida = ValidarEntidade(conta);
                Console.WriteLine("Pedido removido!");
            }
        }

        public virtual void AtualizarPedido()
        {
            Conta conta = (Conta)ValidarId();
            if (conta.PedidosLista.Count < 0)
            {
                Console.WriteLine("A conta escolhida não possui pedidos!");
                return;
            }
            Pedido pedido = (Pedido)ValidarIdPedido(conta.PedidosLista);
            int id = pedido.Id;
            Pedido pedidoAtualizado = pedido.ObterNovaInstancia();
            pedidoAtualizado = EditarAtributosPedido(pedidoAtualizado);
            repositorioConta.EditarPedido(pedido, pedidoAtualizado);
        }

        public void VerFaturamento()
        {
            DateTime data = ValidarData("Digite o dia: ");
            double faturamento = repositorioConta.ObterFaturamentoDia(data);
            Console.WriteLine($"Faturamento de {data.ToString("dd/yy/MMMM")}: R${Math.Round(faturamento, 2)}");
        }

        public override EntidadeBase RegistrarEntidade()
        {
            Pedido veiculo = new Pedido();
            PreencherAtributos(veiculo);
            return veiculo;
        }

        public override void PreencherAtributos(EntidadeBase entidade)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Conta conta = (Conta)entidade;
                Garcom garcom = (Garcom)telaGarcom.ValidarId();
                conta.ContaGarcom = garcom;
                Mesa mesa = (Mesa)telaMesa.ValidarId();
                conta.ContaMesa = mesa;
                Console.Write("Digite o tipo da conta: ");
                string tipo = Console.ReadLine();
                conta.Tipo = tipo;
                conta.PedidosLista = new ArrayList();
                entidadeValida = ValidarEntidade(conta);
            }
        }

        public Pedido PreencherAtributosPedido()
        {
            bool entidadeValida = false;
            Pedido pedido = new Pedido();
            while (!entidadeValida)
            {
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                pedido.Nome = nome;
                int quantidade = ValidarInt("Digite a quantidade do produto");
                pedido.Quantidade = quantidade;
                double valorUnidade = ValidarDouble("Digite o valor da unidade: ");
                pedido.ValorUnidade = valorUnidade;
                pedido.ValorTotal = pedido.ValorUnidade * pedido.Quantidade;
                entidadeValida = ValidarEntidade(pedido);
            }
            return pedido;
        }

        public Pedido EditarAtributosPedido(Pedido pedido)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                pedido.Nome = nome;
                int quantidade = ValidarInt("Digite a quantidade do produto");
                pedido.Quantidade = quantidade;
                double valorUnidade = ValidarDouble("Digite o valor da unidade: ");
                pedido.ValorUnidade = valorUnidade;
                pedido.ValorTotal = pedido.ValorUnidade * pedido.Quantidade;
                entidadeValida = ValidarEntidade(pedido);
            }
            return pedido;
        }

        public virtual EntidadeBase ValidarIdPedido(ArrayList lista)
        {
            EntidadeBase entidade;
            while (true)
            {
                MostrarPedidos(lista);
                int indice = ValidarInt("Digite o id: ");
                entidade = repositorio.EncontrarRegistro(indice, lista);
                if (entidade == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return entidade;
            }
        }

        public void MostrarPedidos(ArrayList lista)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string[] cabecalhoPedido = { "Id:", "Nome:", "Quantidade", "Valor Unidade: ", "Valor Total:" };
            string cabecalho = "";
            foreach (string atributo in cabecalhoPedido)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (EntidadeBase entidade in lista)
            {
                foreach (string atributo in entidade.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        protected virtual string[] ObterOpcoes()
        {
            string[] opcoes =
            {
            "Tela Aquisição",
            "0-Sair",
            $"1-Registrar {this.nomeEntidade}",
            $"2-Mostrar {this.titulo}",
            $"3-Fechar {this.nomeEntidade}",
            $"4-Inserir Pedido",
            $"5-Remover Pedido",
            $"6-Ver Faturamento",
            };
            return opcoes;
        }
    }
}