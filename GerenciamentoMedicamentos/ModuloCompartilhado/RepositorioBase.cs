namespace Prova.ModuloCompartilhado
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        public List<T> Lista { get; protected set; }
        private int contadorRegistros;

        public RepositorioBase()
        {
            this.Lista = new List<T>();
            contadorRegistros = 0;
        }

        public virtual void InserirRegistro(T entidade)
        {
            contadorRegistros++;
            entidade.Id = contadorRegistros;
            Lista.Add(entidade);
        }

        public virtual void EditarRegistro (
            T entidadeAtualizada, int id
        )
        {
            EncontrarRegistro(id).Atualizar(entidadeAtualizada);
        }

        public virtual TRegistro EncontrarRegistro<TRegistro>(int id, List<TRegistro> lista)
            where TRegistro : EntidadeBase<TRegistro>
        {
            return lista.Find(r => r.Id == id);
        }

        public virtual T EncontrarRegistro(int id)
        {
            return Lista.Find(r => r.Id == id);
        }

        public virtual void RemoverRegistro(T entidade)
        {
            Lista.Remove(entidade);
        }
    }
}
