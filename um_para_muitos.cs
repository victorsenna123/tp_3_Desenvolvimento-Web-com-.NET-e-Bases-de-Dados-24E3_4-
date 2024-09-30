public class Autor
{
    public int AutorId { get; set; }
    public string Nome { get; set; }

    // Relacionamento Um-para-Muitos: Um autor pode ter vários livros.
    public ICollection<Livro> Livros { get; set; }
}

public class Livro
{
    public int LivroId { get; set; }
    public string Titulo { get; set; }
    public int AutorId { get; set; }

    // Chave estrangeira para representar o relacionamento com Autor.
    public Autor Autor { get; set; }
}
