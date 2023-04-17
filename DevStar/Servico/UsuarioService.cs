using DevStar.Dominio.Contratos;
using DevStar.Dominio.Entidade;

namespace DevStar.Servico
{
    internal class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario BuscarUsuario(int id)
        {
            return _usuarioRepository.BuscarUsuario(id);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
            Console.WriteLine("Usuário adicionado com sucesso!");
        }

        public void RemoverUsuario(int id)
        {
                _usuarioRepository.RemoverUsuario(id);
                Console.WriteLine("Usuário removido com sucesso!");
                         
        }

        public void AtualizarUsuario(int id, Usuario usuario)
        {

            Usuario usuarioBuscado = BuscarUsuario(id);

            usuarioBuscado.nome = usuario.nome;
            usuarioBuscado.idade = usuario.idade;
            usuarioBuscado.telefone = usuario.telefone;

            _usuarioRepository.AtualizarUsuario(id, usuarioBuscado);
            Console.WriteLine("Usuário atualizado com sucesso!");
        }

        public List<Usuario> MostrarTodosUsuarios()
        {
            return _usuarioRepository.MostrarTodosUsuarios();
        }

        public void verificarUsuarioEstaNulo(Usuario usuario, string mensagemErro, string mensagemSucesso)
        {
            if (usuario == null)
            {
                Console.WriteLine(mensagemErro);
                Console.WriteLine("\n");
                return;
            }
            Console.WriteLine(mensagemSucesso);
            Console.WriteLine("\n");
        }

        public void verificarListaVazia(List<Usuario>listaUsuario)
        {

            if (listaUsuario.Count == 0)
            {
                Console.WriteLine("Lista Vazia");
                Console.WriteLine("\n");
                return;
            }
        }
    }

}
