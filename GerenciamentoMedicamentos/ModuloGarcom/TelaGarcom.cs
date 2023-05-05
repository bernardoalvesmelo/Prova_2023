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
