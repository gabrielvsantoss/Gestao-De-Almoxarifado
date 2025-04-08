using GestaoDeAlmoxarifado.ConsoleApp.ModuloEquipamento;

namespace GestaoDeAlmoxarifado.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;
        public Fabricante[] fabricantesCadastrados = new Fabricante[200];

        public TelaFabricante()
        {
            repositorioFabricante = new RepositorioFabricante();
        }
        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Cadastro de Fabricantes");
            Console.WriteLine("2 - Edição de Fabricantes");
            Console.WriteLine("3 - Exclusão de Fabricantes");
            Console.WriteLine("4 - Visualização de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite um opção válida: ");
            char opcaoEscolhida = Console.ReadLine()![0];

            return opcaoEscolhida;
        }
        public void CadastrarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Cadastrando Fabricantes...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o nome do Fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o Telefone do fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            repositorioFabricante.CadastrarFabricante(novoFabricante);
        }


        public void EditarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Editando fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            bool conseguiuEditar = repositorioFabricante.EditarFabricante(idSelecionado, novoFabricante);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição de um registro...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi editado com sucesso!");
        }

        public void ExcluirFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Excluindo fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão de um registro...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi excluído com sucesso!");
        }

        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de fabricantes");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Visualizando fabricantes...");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -25} |",
                 "Id", "Nome", "Email", "Telefone"
            );

             fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantesCadastrados.Length; i++)
            {
                Fabricante e = fabricantesCadastrados[i];

                if (e == null) continue;

                Console.WriteLine(
                   "{0, -10} | {1, -25} | {2, -25} | {3, -25} |",
                    e.Id, e.Nome, e.Email, e.Telefone
                );
            }

            Console.WriteLine();
        }



    }
}