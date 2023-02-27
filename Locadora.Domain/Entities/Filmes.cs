namespace Locadora.Domain.Entities
{
    public class Filmes : EntityBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        public Categorias Categoria { get; set; }
    }
}
