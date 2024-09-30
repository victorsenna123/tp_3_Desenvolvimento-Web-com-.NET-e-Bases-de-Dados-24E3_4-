namespace RelacionamentoApi.Models
{
public class Passaporte
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public int PessoaId { get; set; } // Essa linha já deve existir
    public Pessoa Pessoa { get; set; } // Essa linha já deve existir
}

}
