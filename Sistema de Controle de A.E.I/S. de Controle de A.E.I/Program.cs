using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    private static List<string> restricoes = new List<string>();
    private static Dictionary<string, List<string>> pessoas = new Dictionary<string, List<string>>();
    private static Dictionary<string, double> servicos = new Dictionary<string, double>();
    private const string dataFilePath = "data.json";

    static void Main(string[] args)
    {
        CarregarDados();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar Restrição");
            Console.WriteLine("2. Remover Restrição");
            Console.WriteLine("3. Adicionar Pessoa (Cliente)");
            Console.WriteLine("4. Excluir Pessoa (Cliente)");
            Console.WriteLine("5. Adicionar Área do Edifício");
            Console.WriteLine("6. Remover Área do Edifício");
            Console.WriteLine("7. Adicionar Serviço");
            Console.WriteLine("8. Diminuir Preço de Serviço");
            Console.WriteLine("9. Aumentar Preço de Serviço");
            Console.WriteLine("10. Exibir Dados");
            Console.WriteLine("11. Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case 1:
                        AdicionarRestricao();
                        break;
                    case 2:
                        RemoverRestricao();
                        break;
                    case 3:
                        AdicionarPessoa();
                        break;
                    case 4:
                        ExcluirPessoa();
                        break;
                    case 5:
                        AdicionarAreaEdificio();
                        break;
                    case 6:
                        RemoverAreaEdificio();
                        break;
                    case 7:
                        AdicionarServico();
                        break;
                    case 8:
                        DiminuirPrecoServico();
                        break;
                    case 9:
                        AumentarPrecoServico();
                        break;
                    case 10:
                        ExibirDados();
                        break;
                    case 11:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    private static void AdicionarRestricao()
    {
        Console.WriteLine("\nEscolha uma categoria:");
        Console.Write("Categoria S, digite categoria a ser restringida: ");
        string categoriaS = Console.ReadLine();
        Console.Write("Categoria P, digite o tipo de restrição: ");
        string categoriaP = Console.ReadLine();

        string restricao = $"Algumas {categoriaS} não são {categoriaP}.";
        restricoes.Add(restricao);

        Console.WriteLine($"Restrição adicionada: {restricao}");
        SalvarDados();
    }

    private static void RemoverRestricao()
    {
        Console.WriteLine("\nRestrições atuais:");
        for (int i = 0; i < restricoes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {restricoes[i]}");
        }

        Console.Write("Escolha o número da restrição a ser removida: ");
        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= restricoes.Count)
        {
            restricoes.RemoveAt(escolha - 1);
            Console.WriteLine("Restrição removida com sucesso.");
            SalvarDados();
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    private static void AdicionarPessoa()
    {
        Console.Write("\nNome da Pessoa (Cliente): ");
        string nome = Console.ReadLine();
        
        List<string> servicosCliente = new List<string>();
        pessoas[nome] = servicosCliente;

        Console.WriteLine($"Pessoa (Cliente) '{nome}' adicionada.");
        SalvarDados();
    }

    private static void ExcluirPessoa()
    {
        Console.WriteLine("\nPessoas (Clientes) atuais:");
        foreach (string pessoa in pessoas.Keys)
        {
            Console.WriteLine(pessoa);
        }

        Console.Write("Nome da Pessoa (Cliente) a ser excluída: ");
        string nome = Console.ReadLine();

        if (pessoas.ContainsKey(nome))
        {
            pessoas.Remove(nome);
            Console.WriteLine($"Pessoa (Cliente) '{nome}' excluída com sucesso.");
            SalvarDados();
        }
        else
        {
            Console.WriteLine("Pessoa (Cliente) não encontrada.");
        }
    }

    private static void AdicionarAreaEdificio()
    {
        Console.Write("\nNome da Área do Edifício: ");
        string area = Console.ReadLine();

        // Aqui, você pode adicionar a lógica para adicionar a área ao edifício.
        Console.WriteLine($"Área do Edifício '{area}' adicionada.");
        SalvarDados();
    }

    private static void RemoverAreaEdificio()
    {
        Console.Write("\nNome da Área do Edifício a ser removida: ");
        string area = Console.ReadLine();

        // Aqui, você pode adicionar a lógica para remover a área do edifício.
        Console.WriteLine($"Área do Edifício '{area}' removida.");
        SalvarDados();
    }

    private static void AdicionarServico()
    {
        Console.Write("\nNome do Serviço: ");
        string servico = Console.ReadLine();
        Console.Write("Preço do Serviço: ");
        if (double.TryParse(Console.ReadLine(), out double preco))
        {
            servicos[servico] = preco;
            Console.WriteLine($"Serviço '{servico}' adicionado com preço {preco:C}.");
            SalvarDados();
        }
        else
        {
            Console.WriteLine("Preço inválido. Tente novamente.");
        }
    }

    private static void DiminuirPrecoServico()
    {
        Console.Write("\nNome do Serviço para diminuir o preço: ");
        string servico = Console.ReadLine();
        if (servicos.ContainsKey(servico))
        {
            Console.Write("Porcentagem de desconto: ");
            if (double.TryParse(Console.ReadLine(), out double desconto))
            {
                servicos[servico] -= servicos[servico] * (desconto / 100);
                Console.WriteLine($"Preço do Serviço '{servico}' diminuído para {servicos[servico]:C}.");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("Porcentagem inválida. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("Serviço não encontrado.");
        }
    }
        private static void AumentarPrecoServico()
    {
        Console.Write("\nNome do Serviço para aumentar o preço: ");
        string servico = Console.ReadLine();
        if (servicos.ContainsKey(servico))
        {
            Console.Write("Porcentagem de aumento: ");
            if (double.TryParse(Console.ReadLine(), out double aumento))
            {
                servicos[servico] += servicos[servico] * (aumento / 100);
                Console.WriteLine($"Preço do Serviço '{servico}' aumentado para {servicos[servico]:C}.");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("Porcentagem inválida. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("Serviço não encontrado.");
        }
    }

    private static void ExibirDados()
    {
        Console.WriteLine("\nRestrições atuais:");
        foreach (string restricao in restricoes)
        {
            Console.WriteLine(restricao);
        }

        Console.WriteLine("\nPessoas (Clientes) atuais:");
        foreach (string pessoa in pessoas.Keys)
        {
            Console.WriteLine(pessoa);
        }

        Console.WriteLine("\nServiços atuais:");
        foreach (var servico in servicos)
        {
            Console.WriteLine($"{servico.Key}: {servico.Value:C}");
        }
    }

    private static void SalvarDados()
    {
        var data = new
        {
            Restricoes = restricoes,
            Pessoas = pessoas,
            Servicos = servicos
        };

        string jsonData = JsonConvert.SerializeObject(data);

        File.WriteAllText(dataFilePath, jsonData);
    }

    private static void CarregarDados()
    {
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

            restricoes = data.Restricoes.ToObject<List<string>>();
            pessoas = data.Pessoas.ToObject<Dictionary<string, List<string>>>();
            servicos = data.Servicos.ToObject<Dictionary<string, double>>();
        }
    }
}
