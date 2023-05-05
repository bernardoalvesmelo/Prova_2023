using Prova.ModuloCompartilhado;
using Prova.ModuloGarcom;
using Prova.ModuloMesa;
using Prova.ModuloProduto;

namespace Prova.ModuloConta
{
    public class TelaConta : TelaBase<Conta>
    {
        private TelaGarcom telaGarcom;
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;
        private RepositorioConta repositorioConta;

        public TelaConta(RepositorioConta repositorio, 
            TelaGarcom telaGarcom,
            TelaMesa telaMesa,
            TelaProduto telaProduto) : base(repositorio)
        {
            repositorioConta = repositorio;
            titulo = "Contas";
            nomeEntidade = "Conta";
            string[] cabecalho = { "Id:", "Tipo:", "Garçom", "Número", "Total Conta R$: ", "Data Fechamento:" };
            Cabecalho = cabecalho;
            this.telaGarcom = telaGarcom;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;
        }

        public override void Opcoes()
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
                        if (telaMesa.Quantidade <= 0)
                        {
                            Console.WriteLine("Não existe mesas registradas no sistema!");
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
                        if(telaProduto.Quantidade <= 0)
                        {
                            Console.WriteLine("Não existe produtos registrados no sistema!");
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
            Conta conta = ValidarId();
            while (!entidadeValida)
            {
                conta.DataFechamento = ValidarData("Digite a data de fechamento: ");
                entidadeValida = ValidarEntidade(conta);
            }
            repositorioConta.FecharConta(conta);
        }

        private void InserirPedido()
        {

            bool entidadeValida = false;
            Pedido pedido = PreencherAtributosPedido();
            while (!entidadeValida)
            {
                Conta conta = ValidarId();
                repositorioConta.InserirContaPedido(conta, pedido);
                entidadeValida = ValidarEntidade(conta);
            }
        }

        private void RemoverPedido()
        {

            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Conta conta = ValidarId();
                if (conta.PedidosLista.Count <= 0)
                {
                    Console.WriteLine("A conta escolhida não possui pedidos!");
                    return;
                }
                Pedido pedido = ValidarIdPedido(conta.PedidosLista);
                repositorioConta.RemoverContaPedido(conta, pedido);
                entidadeValida = ValidarEntidade(conta);
                Console.WriteLine("Pedido removido!");
            }
        }

        

        public void VerFaturamento()
        {
            DateTime data = ValidarData("Digite a data: ");
            double faturamento = 0;
            foreach (Conta conta in repositorioConta.ObterFaturamentoDia(data))
            {
                if (
                    data == conta.DataFechamento
                )
                {
                    faturamento += conta.TotalConta;
                }
            }
            Console.WriteLine($"Faturamento de {data.ToString("dd/MM/yyyy")}: R${Math.Round(faturamento, 2)}");
        }

        public override Conta RegistrarEntidade()
        {
            Conta conta = new Conta();
            PreencherAtributos(conta);
            return conta;
        }

        public override void PreencherAtributos(Conta conta)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Garcom garcom = telaGarcom.ValidarId();
                conta.ContaGarcom = garcom;
                Mesa mesa = telaMesa.ValidarId();
                conta.ContaMesa = mesa;
                conta.Tipo = ValidarTipoConta("Digite o tipo da conta |ESPECIAL-COMUM|: ");
                conta.PedidosLista = new List<Pedido>();
                entidadeValida = ValidarEntidade(conta);
            }
        }

        private Conta.TipoConta ValidarTipoConta(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string tipo = Console.ReadLine().ToUpper();
                string[] opcoes = { "ESPECIAL", "COMUM" };
                if (opcoes.Contains(tipo))
                {
                    return (Conta.TipoConta)Enum.Parse(typeof(Conta.TipoConta), tipo);
                }
                Console.WriteLine("Digite ESPECIAL ou COMUM!");
                Console.ReadLine();
            }
        }

        public Pedido PreencherAtributosPedido()
        {
            bool entidadeValida = false;
            Pedido pedido = new Pedido();
            while (!entidadeValida)
            {
                Produto produto = telaProduto.ValidarId();
                pedido.Nome = produto.Nome;
                int quantidade = ValidarInt("Digite a quantidade do produto: ");
                pedido.Quantidade = quantidade;
                pedido.ValorUnidade = produto.ValorUnidade;
                pedido.ValorTotal = pedido.ValorUnidade * pedido.Quantidade;
                entidadeValida = ValidarPedido(pedido);
            }
            return pedido;
        }

        protected bool ValidarPedido(Pedido pedido)
        {
            if (pedido.ObterErros().Count > 0)
            {
                foreach (string erro in pedido.ObterErros())
                {
                    Console.WriteLine(erro);
                }
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public virtual Pedido ValidarIdPedido(List<Pedido> lista)
        {
            while (true)
            {
                MostrarPedidos(lista);
                int indice = ValidarInt("Digite o id: ");
                Pedido pedido = repositorio.EncontrarRegistro(indice, lista);
                if (pedido == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return pedido;
            }
        }

        public void MostrarPedidos(List<Pedido> lista)
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
            foreach (Pedido pedido  in lista)
            {
                foreach (string atributo in pedido.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        protected override string[] ObterOpcoes()
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