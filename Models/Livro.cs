namespace Chapter_TURMA14.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public int QuntidadePaginas { get; set; }

        public bool Disponivel { get; set; }
    }
}
