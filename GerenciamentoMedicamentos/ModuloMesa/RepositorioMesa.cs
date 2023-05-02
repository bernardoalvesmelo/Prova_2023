using Prova.ModuloCompartilhado;

namespace Prova.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa()
        {

        }

        public override Mesa EncontrarRegistro(int id)
        {
            return (Mesa)base.EncontrarRegistro(id);
        }
    }
}
