using DevStar.Dominio.Contratos;
using DevStar.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Repositorio
{
    internal class ProdutoRepository : IProdutoRepository
    {
        List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public void AtualizarProduto(int id, Produto produto)
        {
            var produtoBuscado = BuscarProduto(id);

            produtoBuscado = produto;
        }

        public Produto BuscarProduto(int id)
        {
            return produtos.Find(x => x.id == id);
        }

        public List<Produto> MostrarProdutos()
        {
            return produtos;
        }

        public void RemoverProduto(int id)
        {
            var produtoBuscado = BuscarProduto(id);

            produtos.Remove(produtoBuscado);
        }

    }
}
