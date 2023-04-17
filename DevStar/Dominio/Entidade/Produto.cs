using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStar.Dominio.Entidade
{
    internal class Produto
    {

        public static int idroduto = 0;


        public string nome { get; set; }

        public string descricao { get; set; }

        public int valorProduto { get; set; }

        public int id { get; set; }

        public Produto()
        {
            idroduto++;
            this.id = idroduto;
        }

        public Produto(string nome, string descricao, int valorProduto):this()
        {
            this.nome = nome;
            this.descricao = descricao;
            this.valorProduto = valorProduto;
        }

        public override string ToString()
        {
            return $"ID:{id}\n" +
                   $"Nome:{nome}\n" +
                   $"Descrição:{descricao}\n" +
                   $"Valor:{valorProduto}\n";
        }
    }
}
