using System.Collections;

namespace Prova.ModuloCompartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Id { get; protected set; }

        protected virtual void ObterId(ref int id)
        {
            id++;
            Id = id;
        }

        public abstract void Atualizar(T entidade);

        public abstract string[] ObterAtributos();

        public abstract ArrayList ObterErros();

        public abstract T ObterNovaInstancia();
    }
}