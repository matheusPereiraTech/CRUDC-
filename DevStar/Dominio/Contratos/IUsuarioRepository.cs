using DevStar.Dominio.Entidade;

namespace DevStar.Dominio.Contratos
{
    internal interface IUsuarioRepository
    {
        public void AdicionarUsuario(Usuario usuario);

        public void RemoverUsuario(int id);

        public void AtualizarUsuario(int id, Usuario usuario);

        public Usuario BuscarUsuario(int id);

        public List<Usuario> MostrarTodosUsuarios();
    }
}
