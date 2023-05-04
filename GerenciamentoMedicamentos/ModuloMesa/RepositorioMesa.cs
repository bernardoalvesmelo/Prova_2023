using Prova.ModuloCompartilhado;

namespace Prova.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa()
        {

        }

        public override Mesa EncontrarRegistro(int id)
        {
            return base.EncontrarRegistro(id);
        }
    }
}
