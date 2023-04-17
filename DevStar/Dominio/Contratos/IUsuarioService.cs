using DevStar.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Dominio.Contratos
{
    internal interface IUsuarioService
    {
        public void AdicionarUsuario(Usuario usuario);
        public void RemoverUsuario(int id);
        public void AtualizarUsuario(int id, Usuario usuario);
        public Usuario BuscarUsuario(int id);
        public List<Usuario> MostrarTodosUsuarios();
        public void verificarUsuarioEstaNulo(Usuario usuario, string mensagemErro, string mensagemSucesso);
        public void verificarListaVazia(List<Usuario> listaUsuario);
    }
}
