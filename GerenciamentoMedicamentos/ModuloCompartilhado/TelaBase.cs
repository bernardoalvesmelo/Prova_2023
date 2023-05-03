using System.Globalization;

namespace Prova.ModuloCompartilhado
{
    public abstract class TelaBase
    {
        protected RepositorioBase repositorio;
        protected string titulo;
        protected string nomeEntidade;

        public int Quantidade
        {
            get { return repositorio.Lista.Count; }
        }
        public string[] Cabecalho { get; protected set; }

        public TelaBase(RepositorioBase repositorio)
        {
            this.repositorio = repositorio;
            titulo = "Entidades";
            nomeEntidade = "Entidade";
            string[] cabecalho = { "Id:" };
            Cabecalho = cabecalho;
        }
        public abstract EntidadeBase RegistrarEntidade();

        public virtual void MostrarEntidades()
        {
            Console.Clear();
            Console.WriteLine(titulo);
            string cabecalho = "";
            foreach (string atributo in Cabecalho)
            {
                cabecalho += (atributo.PadRight(20) + "|");
            }
            Console.Write(cabecalho);
            Console.WriteLine();
            Console.WriteLine("".PadRight(cabecalho.Length, '-'));
            foreach (EntidadeBase entidade in repositorio.Lista)
            {
                foreach (string atributo in entidade.ObterAtributos())
                {
                    Console.Write(atributo.PadRight(20) + "|");
                }
                Console.WriteLine();
            }
        }

        public virtual void AtualizarEntidade()
        {
            EntidadeBase entidadeAtualizada = ValidarId();
            int id = entidadeAtualizada.Id;
            entidadeAtualizada = entidadeAtualizada.ObterNovaInstancia();
            PreencherAtributos(entidadeAtualizada);
            repositorio.EditarRegistro(entidadeAtualizada, id);
        }

        public abstract void PreencherAtributos(EntidadeBase entidade);

        public virtual void RemoverEntidade()
        {
            EntidadeBase entidade = ValidarId();
            repositorio.RemoverRegistro(entidade);
        }

        public virtual EntidadeBase ValidarId()
        {
            EntidadeBase entidade;
            while (true)
            {
                MostrarEntidades();
                int indice = ValidarInt("Digite o id: ");
                entidade = repositorio.EncontrarRegistro(indice);
                if (entidade == null)
                {
                    Console.WriteLine("O id escolhido não existe!");
                    Console.ReadLine();
                    continue;
                }
                return entidade;
            }
        }
        public virtual void MostrarMenu()
        {
            Console.Clear();
            foreach (string opcao in ObterOpcoes())
            {
                Console.WriteLine(opcao);
            }
            Console.Write("Digite a opção desejada: ");
        }

        protected virtual int ValidarInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();
                int numero;
                if (Int32.TryParse(valor, out numero))
                {
                    return numero;
                }
                Console.WriteLine("Digite apenas um número inteiro!");
                Console.ReadLine();
            }
        }

        protected virtual double ValidarDouble(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();
                double numero;
                if (Double.TryParse(valor, out numero))
                {
                    return numero;
                }
                Console.WriteLine("Digite um número!");
                Console.ReadLine();
            }
        }

        protected virtual DateTime ValidarData(string mensagem)
        {
            DateTime data;
            while (true)
            {
                Console.Write(mensagem);
                string dataInput = Console.ReadLine();
                if (
                    DateTime.TryParseExact(
                        dataInput,
                        "dd/MM/yyyy",
                        new CultureInfo("pt-BR"),
                        DateTimeStyles.None,
                        out data
                    )
                )
                {
                    return data;
                }
                else
                {
                    Console.WriteLine("Digite a data no formato dd/mm/yyyy!");
                    Console.ReadLine();
                }
            }
        }
        protected bool ValidarEntidade(EntidadeBase entidade)
        {
            if (entidade.ObterErros().Count > 0)
            {
                foreach (string erro in entidade.ObterErros())
                {
                    Console.WriteLine(erro);
                }
                Console.ReadLine();
                return false;
            }
            return true;
        }

protected virtual string[] ObterOpcoes()
        {
            string[] opcoes =
            {
            "Tela Aquisição",
            "0-Sair",
            $"1-Registrar {this.nomeEntidade}",
            $"2-Mostrar {this.titulo}",
            $"3-Editar {this.nomeEntidade}",
            $"4-Remover {this.nomeEntidade}",
            };
            return opcoes;
        }
    }
}