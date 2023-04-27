using Chapter_TURMA14.Contexts;
using Chapter_TURMA14.Models;

namespace Chapter_TURMA14.Repositories
{
    public class LivroRepository
    {
        private readonly Sqlcontext _context;
        public LivroRepository(Sqlcontext context) 
        {
            _context = context;
        }
     
        public List<Livro> Listar() 
        {
            return _context.Livros.ToList();
        }
    }
}
