namespace GestaoDeAlmoxarifado.ConsoleApp.ModuloFabricante
{
    public class Fabricante
    {
        public string Nome;
        public string Email;
        public string Telefone;
        public int Id;

        public Fabricante(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}