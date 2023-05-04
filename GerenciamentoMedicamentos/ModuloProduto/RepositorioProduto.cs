using Prova.ModuloCompartilhado;

namespace Prova.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public RepositorioProduto()
        {

        }

        public override Produto EncontrarRegistro(int id)
        {
            return base.EncontrarRegistro(id);
        }
    }
}
