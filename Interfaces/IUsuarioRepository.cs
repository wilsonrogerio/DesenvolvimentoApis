using Chapter_TURMA14.Models;
using System.ComponentModel.DataAnnotations;

namespace Chapter_TURMA14.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id,Usuario novoUsuario);

        void Deletar(int id);

        Usuario Login(string email, string senha);


    }
}
