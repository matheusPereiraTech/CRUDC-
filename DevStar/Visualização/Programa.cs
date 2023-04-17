using DevStar.Dominio.Contratos;
using DevStar.Dominio.Entidade;
using DevStar.Repositorio;
using DevStar.Servico;
using DevStar.Utilidade;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

namespace DevStar.Visualização
{
    internal class Programa
    {
        static void Main(string[] args)
        {

            var provider = BuildServiceProvider();
            var usuarioService = provider.GetService<IUsuarioService>();
            var produtoService = provider.GetService<IProdutoService>();

            while (true)
            {

                switch (MenuPrincipal())
                {
                    case 1:
                        SelecionaUsuario(usuarioService);
                        break;

                    case 2:
                        SelecionaProduto(produtoService);
                        break;
                    case 3:
                        Console.WriteLine("Programa Finzalizado !!!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\n");
            }
        }

        #region Seleciona produto
        private static void SelecionaProduto(IProdutoService produtoService)
        {
            while (true)
            {
                switch (MenuProduto())
                {
                    case 1:
                        AdicionarProduto(produtoService);
                        break;
                    case 2:
                        RemoverProduto(produtoService);
                        break;
                    case 3:
                        AtualizarProduto(produtoService);
                        break;
                    case 4:
                        MostrarApenasUmProduto(produtoService);
                        break;
                    case 5:
                        MostrarTodosProdutos(produtoService);
                        break;
                    case 6:
                        Console.WriteLine("Processo Encerrado!");
                        Console.WriteLine("\n");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida!!!");
                        break;
                }
            }
        }
        #endregion

        #region Mostrar todos os produtos
        private static void MostrarTodosProdutos(IProdutoService produtoService)
        {
            List<Produto> produtos = produtoService.MostrarTodosProdutos();

            produtoService.verificarListaVazia(produtos);

            foreach (var produto in produtos)
            {
                Console.WriteLine(
                    produto.ToString()
                  ); ;
            }
        }
        #endregion

        #region Mostrar produto único
        private static void MostrarApenasUmProduto(IProdutoService produtoService)
        {
            Console.Write("Digite o ID do produto a mostrar: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("\n");

            Produto produtoMostrarTela = produtoService.BuscarProduto(id);

            produtoService.verificarProdutoEstaNulo(produtoMostrarTela, "Produto não encontrado!", "Produto Encontrado com Sucesso!");

            Console.WriteLine(produtoMostrarTela);
        }
        #endregion

        #region Atualizar produto
        private static void AtualizarProduto(IProdutoService produtoService)
        {
            Console.Write("Digite o ID do Produto a ser atualizado: ");
            int.TryParse(Console.ReadLine(), out int id);
            Produto produtoAtualizado = produtoService.BuscarProduto(id);

            if (produtoAtualizado == null)
            {
                Console.WriteLine("Produto não encontrado!");

                return;
            }

            Console.Write("Digite o novo nome do produto: ");
            string novoNomeProduto = Console.ReadLine();

            Console.Write("Digite a nova descrição do produto: ");
            string novaDescricaoProduto = Console.ReadLine();

            Console.Write("Digite o novo valor do produto: ");
            int novoValorProduto = int.Parse(Console.ReadLine());

            produtoService.AtualizarProduto(id, new Produto(novoNomeProduto, novaDescricaoProduto, novoValorProduto));
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        #endregion

        #region Remover produto
        private static void RemoverProduto(IProdutoService produtoService)
        {
            Console.Write("Digite o ID do produto a ser removido: ");
            int.TryParse(Console.ReadLine(), out int id);

            Produto produtoRemovido = produtoService.BuscarProduto(id);

            produtoService.verificarProdutoEstaNulo(produtoRemovido, "Produto não encontrado!","Produto Removido com Sucesso!");

            produtoService.RemoverProduto(id);


        }
        #endregion

        #region Adicionar produto
        private static void AdicionarProduto(IProdutoService produtoService)
        {
            Console.Write("Digite o nome do produto: ");
            string nomeProduto = Console.ReadLine();

            Console.Write("Digite a descrição do produto:");
            string descricaoProduto = Console.ReadLine();

            Console.Write("Digite o valor do produto:");
            int valorProduto = int.Parse(Console.ReadLine());

            produtoService.AdicionarProduto(new Produto(nomeProduto, descricaoProduto, valorProduto));
            Console.WriteLine("Produto adicionado com sucesso!");
        }
        #endregion

        #region Selecionar usuário
        private static void SelecionaUsuario(IUsuarioService usuarioService)
        {
            while(true) {

                switch (MenuUsuario())
                {
                    case 1:
                        AdicionarUsuario(usuarioService);
                        break;
                    case 2:
                        RemoverUsuario(usuarioService);
                        break;
                    case 3:
                        AtualizarUsuario(usuarioService);
                        break;
                    case 4:
                        MostrarApenasUmUsuario(usuarioService);
                        break;
                    case 5:
                        MostrarTodosUsuarios(usuarioService);
                        break;
                    case 6:
                        Console.WriteLine("Processo Encerrado!");
                        Console.WriteLine("\n");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida!!!");
                        break;
                }
            }
           
        }
        #endregion

        #region Mostrar todos os usuários
        private static void MostrarTodosUsuarios(IUsuarioService usuarioService)
        {
            List<Usuario> usuarios = usuarioService.MostrarTodosUsuarios();

            usuarioService.verificarListaVazia(usuarios);
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(
                    usuario.ToString()
                  ); ;
            }
        }
        #endregion

        #region Mostrar usuário uníco
        private static void MostrarApenasUmUsuario(IUsuarioService usuarioService)
        {
            Console.Write("Digite o ID do usuário a mostrar: ");
            int.TryParse(Console.ReadLine(), out int id);

            Usuario usuarioMostrado = usuarioService.BuscarUsuario(id);

            usuarioService.verificarUsuarioEstaNulo(usuarioMostrado, "Usuário não encontrado!", "Usuário Encontrado com Sucesso!");

            Console.WriteLine("\n");

            Usuario usuarioMostrarTela = usuarioService.BuscarUsuario(id);

            Console.WriteLine(
                usuarioMostrarTela
                ); ;

        }
        #endregion

        #region Atualizar usuario
        private static void AtualizarUsuario(IUsuarioService usuarioService)
        {
            Console.Write("Digite o ID do usuário a ser atualizado: ");
            int.TryParse(Console.ReadLine(), out int id);

            Usuario usuarioAtualizado = usuarioService.BuscarUsuario(id);

            usuarioService.verificarUsuarioEstaNulo(usuarioAtualizado, "Usuário não encontrado!", "Usuário Atualizado com Sucesso!");

            Console.Write("Digite o novo nome do usuário: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite a nova idade do usuário: ");
            int novoIdade = int.Parse(Console.ReadLine());

            Console.Write("Digite o novo telefone do usuário: ");
            string novoTelefone = Mascaras.mascaraTelefone(Console.ReadLine());

            usuarioService.AtualizarUsuario(id, new Usuario(novoNome, novoIdade, novoTelefone));

        }
        #endregion

        #region Remover usuario
        private static void RemoverUsuario(IUsuarioService usuarioService)
        {
            Console.Write("Digite o ID do usuário a ser removido: ");
            int.TryParse(Console.ReadLine(), out int id);

            Usuario usuarioRemovido = usuarioService.BuscarUsuario(id);

            usuarioService.verificarUsuarioEstaNulo(usuarioRemovido, "Usuário não encontrado!", "Usuário Removido com Sucesso!");
            usuarioService.RemoverUsuario(id);

        }
        #endregion


        #region Adicionar usuário
        private static void AdicionarUsuario(IUsuarioService usuarioService)
        {
            Console.Write("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade do usuário:");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("Digite o telefone do usuário:");
            string telefone = Mascaras.mascaraTelefone(Console.ReadLine());

            Usuario usuario = new Usuario(nome, idade, telefone);

            usuarioService.AdicionarUsuario(usuario);
            Console.WriteLine("Usuário adicionado com sucesso!");
        }
        #endregion


        #region Menu usuario
        private static int MenuUsuario()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Adicionar usuário");
            Console.WriteLine("2. Remover usuário");
            Console.WriteLine("3. Atualizar usuário");
            Console.WriteLine("4. Mostrar somente o usuário selecionado");
            Console.WriteLine("5. Mostrar todos os usuários");
            Console.WriteLine("6. Voltar ao menu principal");

            Console.Write("Digite uma opção: ");
            int.TryParse(Console.ReadLine(), out int opcao);
            Console.WriteLine("\n");

            return opcao;
        }

        #endregion


        #region Menu produto
        private static int MenuProduto()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Adicionar produto");
            Console.WriteLine("2. Remover produto");
            Console.WriteLine("3. Atualizar produto");
            Console.WriteLine("4. Mostrar somente o produto selecionado");
            Console.WriteLine("5. Mostrar todos os produtos");
            Console.WriteLine("6. Voltar ao menu principal");

            Console.Write("Digite uma opção: ");
            int.TryParse(Console.ReadLine(), out int opcao);
            Console.WriteLine("\n");

            return opcao;
        }
        #endregion

        #region Menu principal
        private static int MenuPrincipal()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Usuário");
            Console.WriteLine("2. Produto");
            Console.WriteLine("3. Finalizar Progama");

            Console.Write("Digite uma opção: ");
            int.TryParse(Console.ReadLine(), out int opcao);
            Console.WriteLine("\n");

            return opcao;
        }
        #endregion

        #region Service provider
        private static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            return services.BuildServiceProvider();
        }
        #endregion

       
    }

}

