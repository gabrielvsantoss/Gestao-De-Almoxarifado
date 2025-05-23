﻿using GestaoDeAlmoxarifado.ConsoleApp.ModuloFabricante;

namespace GestaoDeAlmoxarifado.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;
    public TelaFabricante Tela = new TelaFabricante();

    public TelaEquipamento(RepositorioFabricante RepositorioFabricante)
    {
        repositorioEquipamento = new RepositorioEquipamento();
        repositorioFabricante = RepositorioFabricante;
    }
    public char ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Edição de Equipamento");
        Console.WriteLine("3 - Exclusão de Equipamento");
        Console.WriteLine("4 - Visualização de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;
    }

    public void CadastrarEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Cadastrando Equipamento...");
        Console.WriteLine("--------------------------------------------");


        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

     


        Console.WriteLine(
            "{0, -10} | {1, -25} | {2, -25} | {3, -25} |",
        "Id", "Nome", "Email", "Telefone"
        );


        Fabricante[] fabricantesCadastrados = repositorioFabricante.fabricantes;


        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
             Fabricante e = fabricantesCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
               "{0, -10} | {1, -25} | {2, -25} | {3, -25} |",
                e.Id, e.Nome, e.Email, e.Telefone
            );
        }

        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("Digite o id do Fabricante que deseja colocar nesse Equipamento");
        int idFabricante = Convert.ToInt32(Console.ReadLine());
        bool idAchado = false;
        string fabricante = "";

        while (idAchado == false)
        {

            for (int i = 0; i <= fabricantesCadastrados.Length; i++)
            {
                if (idFabricante == fabricantesCadastrados[i].Id)
                {
                    fabricante = fabricantesCadastrados[i].Nome;
                    idAchado = true;
                }
            }

            if (idAchado == false)
                Console.WriteLine("id digitado é invalido| Clique ENTER para tentar novamente |");
                Console.ReadLine();
                continue;
        }
        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

        repositorioEquipamento.CadastrarEquipamento(novoEquipamento);
    }

    public void EditarEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Editando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o nome do fabricante equipamento: ");
        string fabricante = Console.ReadLine()!;

        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O equipamento foi editado com sucesso!");
    }

    public void ExcluirEquipamento()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Excluindo Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O equipamento foi excluído com sucesso!");
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Visualizando Equipamentos...");
            Console.WriteLine("--------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento e = equipamentosCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();
    }
}