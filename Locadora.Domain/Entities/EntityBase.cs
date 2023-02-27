namespace Locadora.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public bool Deletado { get; set; }
        public DateTime CriadoEm { get; set; }

        public void InserirDadosPadrao()
        {
            CriadoEm = DateTime.Now;
            Deletado = false;
        }

    }
}
