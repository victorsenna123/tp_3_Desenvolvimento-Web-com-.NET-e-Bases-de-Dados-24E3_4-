public class Estudante
{
    public int EstudanteId { get; set; }
    public string Nome { get; set; }

    // Relacionamento Muitos-para-Muitos: Um estudante pode se inscrever em vários cursos.
    public ICollection<CursoEstudante> CursoEstudantes { get; set; }
}

public class Curso
{
    public int CursoId { get; set; }
    public string Titulo { get; set; }

    // Relacionamento Muitos-para-Muitos: Um curso pode ter vários estudantes.
    public ICollection<CursoEstudante> CursoEstudantes { get; set; }
}

public class CursoEstudante
{
    public int EstudanteId { get; set; }
    public Estudante Estudante { get; set; }

    public int CursoId { get; set; }
    public Curso Curso { get; set; }
}
