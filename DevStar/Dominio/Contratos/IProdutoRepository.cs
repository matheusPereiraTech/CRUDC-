using DevStar.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Dominio.Contratos
{
    internal interface IProdutoRepository
    {
        public void AdicionarProduto(Produto produto);

        public void RemoverProduto(int id);

        public void AtualizarProduto(int id, Produto produto);

        public Produto BuscarProduto(int id);

        public List<Produto> MostrarProdutos();
    }
}
