namespace Prova.ModuloCompartilhado
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        public List<T> Lista { get; protected set; }

        public RepositorioBase()
        {
            this.Lista = new List<T>();
        }

        public virtual void InserirRegistro(T entidade)
        {
            Lista.Add(entidade);
        }

        public virtual void EditarRegistro (
            T entidadeAtualizada, int id
        )
        {
            EncontrarRegistro(id).Atualizar(entidadeAtualizada);
        }

        public virtual TRegistro EncontrarRegistro<TRegistro>(int id, List<TRegistro> lista)
            where TRegistro : EntidadeBase
        {
            foreach (TRegistro entidade in lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public virtual T EncontrarRegistro(int id)
        {
            foreach (T entidade in Lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public virtual void RemoverRegistro(T entidade)
        {
            Lista.Remove(entidade);
        }
    }
}
