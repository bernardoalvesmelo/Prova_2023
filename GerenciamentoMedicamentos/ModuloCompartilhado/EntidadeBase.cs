namespace Prova.ModuloCompartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Id { get; set; }

        public abstract void Atualizar(T entidade);

        public abstract string[] ObterAtributos();

        public abstract ArrayList ObterErros();
    }
}