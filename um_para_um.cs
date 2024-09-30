public class Pessoa
{
    public int PessoaId { get; set; }
    public string Nome { get; set; }

    // Relacionamento Um-para-Um: Uma pessoa tem um passaporte.
    public Passaporte Passaporte { get; set; }
}

public class Passaporte
{
    public int PassaporteId { get; set; }
    public string Numero { get; set; }
    
    // Chave estrangeira para representar o relacionamento com Pessoa.
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
}
