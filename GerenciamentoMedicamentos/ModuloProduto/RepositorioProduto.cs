using Prova.ModuloCompartilhado;

namespace Prova.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase
    {
        public RepositorioProduto()
        {

        }

        public override Produto EncontrarRegistro(int id)
        {
            return (Produto)base.EncontrarRegistro(id);
        }
    }
}
