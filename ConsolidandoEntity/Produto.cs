namespace ConsolidandoEntity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }

        public Produto()
        {

        }
        public Produto(int id, string nome, string categoria, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Categoria = categoria;
            this.Preco = preco;
        }
        public Produto(string nome, string categoria, double preco)
        {
            this.Nome = nome;
            this.Categoria = categoria;
            this.Preco = preco;
        }
    }
}