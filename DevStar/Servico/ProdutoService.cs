using DevStar.Dominio.Contratos;
using DevStar.Dominio.Entidade;
using DevStar.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Servico
{
    internal class ProdutoService : IProdutoService
    {
        IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtoRepository.AdicionarProduto(produto);
        }

        public void AtualizarProduto(int id, Produto produto)
        {
            
            _produtoRepository.AtualizarProduto(id, produto);
        }

        public Produto BuscarProduto(int id)
        {
            return _produtoRepository.BuscarProduto(id);
        }

        public List<Produto> MostrarTodosProdutos()
        {
            return _produtoRepository.MostrarProdutos();
        }

        public void RemoverProduto(int id)
        {
            
            _produtoRepository.RemoverProduto(id);
        }

        public void verificarProdutoEstaNulo(Produto produto, string mensagemErro, string mensagemSucesso)
        { 
            if (produto == null)
            {
                Console.WriteLine(mensagemErro);
                Console.WriteLine("\n");
                return;
            }

            Console.WriteLine(mensagemSucesso);
            Console.WriteLine("\n");
        }

        public void verificarListaVazia(List<Produto> listaProduto)
        {

            if (listaProduto.Count == 0)
            {
                Console.WriteLine("Lista Vazia");
                Console.WriteLine("\n");
                return;
            }
        }
    }
}
