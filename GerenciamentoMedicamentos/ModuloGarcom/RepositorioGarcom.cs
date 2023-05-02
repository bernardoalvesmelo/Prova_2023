using Prova.ModuloCompartilhado;

namespace Prova.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase
    {
        public RepositorioGarcom()
        {

        }

        public override Garcom EncontrarRegistro(int id)
        {
            return (Garcom)base.EncontrarRegistro(id);
        }
    }
}
