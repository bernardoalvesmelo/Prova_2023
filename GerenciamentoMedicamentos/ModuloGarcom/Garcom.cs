using System.Collections;

using Prova.ModuloCompartilhado;

namespace Prova.ModuloGarcom
{
    public class Garcom : EntidadeBase<Garcom>
    {
        static private int id = 0;

        public string Nome { get; set; }

        public int Idade { get; set; }

        public Garcom()
        {
            ObterId(ref id);
        }

        public Garcom(int id)
        {
            Id = id;
        }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), Nome, (Idade + "") };
            return atributos;
        }

        public override void Atualizar(Garcom garcom)
        {
            Nome = garcom.Nome;
            Idade = garcom.Idade;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                erros.Add("O campo nome é obrigatório");
            }

            if (Idade < 0)
            {
                erros.Add("O campo idade não pode ser menor que 0");
            }

            return erros;
        }

        public override Garcom ObterNovaInstancia()
        {
            return new Garcom(Id);
        }

    }
}