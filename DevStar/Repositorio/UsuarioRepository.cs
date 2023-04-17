using DevStar.Dominio.Contratos;
using DevStar.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Repositorio
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        List<Usuario> usuarios = new List<Usuario>();

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);

        }

        public void RemoverUsuario(int id)
        {
            var usuarioBuscado = BuscarUsuario(id);
            usuarios.Remove(usuarioBuscado);
        }

        public void AtualizarUsuario(int id, Usuario usuario)
        { 
            var usuarioBuscado = BuscarUsuario(id);

            usuarioBuscado = usuario;

        }

        public Usuario BuscarUsuario(int id)
        {
            return usuarios.Find(x => x.idUsuario == id);
        }

        public List<Usuario> MostrarTodosUsuarios()
        {
            return usuarios;
        }
    }
}
