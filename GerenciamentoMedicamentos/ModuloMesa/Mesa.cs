namespace Prova.ModuloMesa
{
    public class Mesa : EntidadeBase<Mesa>
    {

        public int Numero { get; set; }

        public string Tipo { get; set; }

        public override string[] ObterAtributos()
        {
            string[] atributos = { (Id + ""), (Numero + ""), Tipo};
            return atributos;
        }

        public override void Atualizar(Mesa mesa)
        {
            Numero = mesa.Numero;
            Tipo = mesa.Tipo;
        }

        public override ArrayList ObterErros()
        {
            ArrayList erros = new ArrayList();

            if (Numero < 0)
            {
                erros.Add("O campo número não pode ser menor que 0");
            }

            if (string.IsNullOrEmpty(Tipo.Trim()))
            {
                erros.Add("O campo tipo é obrigatório");
            }

            return erros;
        }

    }
}