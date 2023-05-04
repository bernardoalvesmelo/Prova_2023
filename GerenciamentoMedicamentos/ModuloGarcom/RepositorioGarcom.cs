using Prova.ModuloCompartilhado;

namespace Prova.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom()
        {

        }

        public override Garcom EncontrarRegistro(int id)
        {
            return base.EncontrarRegistro(id);
        }
    }
}
