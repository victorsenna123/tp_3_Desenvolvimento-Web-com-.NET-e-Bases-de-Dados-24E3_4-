namespace RelacionamentoApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        // Propriedade de navegação para Passaporte
        public Passaporte? Passaporte { get; set; }
    }
}
