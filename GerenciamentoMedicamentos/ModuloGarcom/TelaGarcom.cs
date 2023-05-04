using Prova.ModuloCompartilhado;

namespace Prova.ModuloGarcom
{

    public class TelaGarcom : TelaBase<Garcom>
    {


        public TelaGarcom(RepositorioGarcom repositorio) : base(repositorio)
        {
            titulo = "Garçons";
            nomeEntidade = "Garçom";
            string[] cabecalho = { "Id:", "Nome:", "Idade:" };
            Cabecalho = cabecalho;
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
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Garçom registrado!");
                        Console.ReadLine();
                        break;
                    case "2":
                        MostrarEntidades();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (repositorio.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe garçons registrados no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        AtualizarEntidade();
                        Console.WriteLine("Garçom atualizado!");
                        Console.ReadLine();
                        break;
                    case "4":
                        if (repositorio.Lista.Count <= 0)
                        {
                            Console.WriteLine("Não existe garçons registrados no sistema!");
                            Console.ReadLine();
                            return;
                        }
                        RemoverEntidade();
                        Console.WriteLine("Garçom removido!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção não encontrada!");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public override Garcom RegistrarEntidade()
        {
            Garcom garcom = new Garcom();
            PreencherAtributos(garcom);
            return garcom;
        }

        public override void PreencherAtributos(Garcom garcom)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                Console.Write("Digite o nome do garçom: ");
                string nome = Console.ReadLine();
                garcom.Nome = nome;
                int idade = ValidarInt("Digite a idade do garçom: ");
                garcom.Idade = idade;
                entidadeValida = ValidarEntidade(garcom);
            } 
        }
    }
}
