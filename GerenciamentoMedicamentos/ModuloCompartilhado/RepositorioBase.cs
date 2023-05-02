namespace Prova.ModuloCompartilhado
{
    using System.Collections;

    public abstract class RepositorioBase
    {
        public ArrayList Lista { get; protected set; }

        public RepositorioBase()
        {
            this.Lista = new ArrayList();
        }

        public virtual void InserirRegistro(EntidadeBase entidade)
        {
            Lista.Add(entidade);
        }

        public virtual void EditarRegistro (
            EntidadeBase entidadeAtualizada, int id
        )
        {
            EncontrarRegistro(id).Atualizar(entidadeAtualizada);
        }

        public virtual EntidadeBase EncontrarRegistro(int id, ArrayList lista)
        {
            foreach (EntidadeBase entidade in lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public virtual EntidadeBase EncontrarRegistro(int id)
        {
            foreach (EntidadeBase entidade in Lista)
            {
                if (entidade.Id == id)
                {
                    return entidade;
                }
            }

            return null;
        }

        public virtual void RemoverRegistro(EntidadeBase entidade)
        {
            Lista.Remove(entidade);
        }
    }
}
