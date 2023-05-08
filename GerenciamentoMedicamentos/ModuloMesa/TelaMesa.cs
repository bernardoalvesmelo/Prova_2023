namespace Prova.ModuloMesa
{

    public class TelaMesa : TelaBase<Mesa>
    {

        public TelaMesa(RepositorioMesa repositorio) : base(repositorio)
        {
            titulo = "Mesas";
            nomeEntidade = "Mesa";
            string[] cabecalho = { "Id:", "Número:", "Tipo:" };
            Cabecalho = cabecalho;
        }

        public override Mesa RegistrarEntidade()
        {
            Mesa mesa = new Mesa();
            PreencherAtributos(mesa);
            return mesa;
        }

        public override void PreencherAtributos(Mesa mesa)
        {
            bool entidadeValida = false;
            while (!entidadeValida)
            {
                int numero = ValidarInt("Digite o número da mesa: ");
                mesa.Numero = numero;
                Console.Write("Digite o tipo da mesa: ");
                string tipo = Console.ReadLine();
                mesa.Tipo = tipo;
                entidadeValida = ValidarEntidade(mesa);
            } 
        }
    }
}
