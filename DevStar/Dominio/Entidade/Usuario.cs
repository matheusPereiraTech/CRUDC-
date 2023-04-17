namespace DevStar.Dominio.Entidade
{
    internal class Usuario
    {
        private static int id = 0;
        public int idUsuario { get; }
        public string nome { get; set; }

        public int idade { get; set; }

        public string telefone { get; set; }

        public Usuario() {
            id++;
            this.idUsuario = id;
        }

        public Usuario(string nome, int idade, string telefone) : this() 
        {
            this.nome = nome;
            this.idade = idade;
            this.telefone = telefone;
           
        }

        public override string ToString()
        {
            return $"ID:{idUsuario}\n" +
                   $"Nome:{nome}\n" +
                   $"Idade:{idade}\n" +
                   $"Telefone:{telefone}\n";
        }
    }
}
