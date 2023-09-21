using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        GerenciadorDeEstoque gerenciador = new GerenciadorDeEstoque();

        Console.WriteLine("Bem-vindo ao Sistema de Verificação de Estoque!");

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Verificar produtos disponíveis");
            Console.WriteLine("2. Adicionar produto ao estoque");
            Console.WriteLine("3. Acrescentar quantidade a um produto");
            Console.WriteLine("4. Diminuir quantidade de um produto");
            Console.WriteLine("5. Aumentar porcentagem do valor de um produto");
            Console.WriteLine("6. Diminuir porcentagem do valor de um produto");
            Console.WriteLine("7. Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    gerenciador.VerificarProdutosDisponiveis();
                    break;
                case "2":
                    gerenciador.AdicionarProduto();
                    break;
                case "3":
                    gerenciador.AumentarQuantidadeProduto();
                    break;
                case "4":
                    gerenciador.DiminuirQuantidadeProduto();
                    break;
                case "5":
                    gerenciador.AumentarPorcentagemDoValor();
                    break;
                case "6":
                    gerenciador.DiminuirPorcentagemDoValor();
                    break;
                case "7":
                    gerenciador.SalvarEstoqueEmArquivo();
                    Console.WriteLine("Programa encerrado.");
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}

class Produto
{
    public string Categoria { get; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }

    public Produto(string categoria, int quantidade, double preco)
    {
        Categoria = categoria;
        Quantidade = quantidade;
        Preco = preco;
    }

    public string PrecoFormatado => Preco.ToString("C", CultureInfo.CurrentCulture);
}

class GerenciadorDeEstoque
{
    private Dictionary<string, Produto> estoque = new Dictionary<string, Produto>();
    private const string arquivoEstoque = "estoque.json";

    public GerenciadorDeEstoque()
    {
        CarregarEstoqueDoArquivo();
        
        // Preencha o estoque com alguns produtos de exemplo se o arquivo estiver vazio
        if (estoque.Count == 0)
        {
            estoque["smartphone"] = new Produto("smartphone", 10, 499.99);
            estoque["laptop"] = new Produto("laptop", 5, 899.99);
            estoque["acessório"] = new Produto("acessório", 50, 19.99);
        }
    }

    public void VerificarProdutosDisponiveis()
    {
        Console.WriteLine("Produtos disponíveis no estoque:");

        foreach (var produto in estoque.Values)
        {
            if (produto.Quantidade > 0)
            {
                Console.WriteLine($"Produto: {produto.Categoria}");
                Console.WriteLine($"Quantidade em Estoque: {produto.Quantidade}");
                Console.WriteLine($"Preço: {produto.PrecoFormatado}\n");
            }
        }
    }

    public void AdicionarProduto()
    {
        Console.WriteLine("Digite o nome do produto a ser adicionado:");
        string nomeProduto = Console.ReadLine().ToLower();

        Console.WriteLine("Digite a quantidade do produto:");
        int quantidadeProduto = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o preço do produto:");
        double precoProduto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Produto novoProduto = new Produto(nomeProduto, quantidadeProduto, precoProduto);

        estoque[nomeProduto] = novoProduto;

        Console.WriteLine($"Produto '{nomeProduto}' adicionado ao estoque.");
    }

    public void AumentarQuantidadeProduto()
    {
        Console.WriteLine("Digite o nome do produto para aumentar a quantidade:");
        string nomeProduto = Console.ReadLine().ToLower();

        if (estoque.ContainsKey(nomeProduto))
        {
            Console.WriteLine($"Digite a quantidade adicional para '{nomeProduto}':");
            int quantidadeAdicional = int.Parse(Console.ReadLine());

            Produto produto = estoque[nomeProduto];
            produto.Quantidade += quantidadeAdicional;

            Console.WriteLine($"Quantidade de '{nomeProduto}' atualizada para {produto.Quantidade}.");
        }
        else
        {
            Console.WriteLine($"Produto '{nomeProduto}' não encontrado no estoque.");
        }
    }

    public void DiminuirQuantidadeProduto()
    {
        Console.WriteLine("Digite o nome do produto para diminuir a quantidade:");
        string nomeProduto = Console.ReadLine().ToLower();

        if (estoque.ContainsKey(nomeProduto))
        {
            Console.WriteLine($"Digite a quantidade a ser removida de '{nomeProduto}':");
            int quantidadeRemovida = int.Parse(Console.ReadLine());

            Produto produto = estoque[nomeProduto];
            if (quantidadeRemovida <= produto.Quantidade)
            {
                produto.Quantidade -= quantidadeRemovida;
                Console.WriteLine($"Quantidade de '{nomeProduto}' atualizada para {produto.Quantidade}.");
            }
            else
            {
                Console.WriteLine($"Quantidade a ser removida excede a quantidade disponível em estoque.");
            }
        }
        else
        {
            Console.WriteLine($"Produto '{nomeProduto}' não encontrado no estoque.");
        }
    }

    public void AumentarPorcentagemDoValor()
    {
        Console.WriteLine("Digite o nome do produto para aumentar a porcentagem do valor:");
        string nomeProduto = Console.ReadLine().ToLower();

        if (estoque.ContainsKey(nomeProduto))
        {
            Console.WriteLine($"Digite a porcentagem de aumento para '{nomeProduto}':");
            double porcentagemAumento = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Produto produto = estoque[nomeProduto];
            double aumento = produto.Preco * (porcentagemAumento / 100.0);
            produto.Preco += aumento;

            Console.WriteLine($"Preço de '{nomeProduto}' aumentado para {produto.PrecoFormatado}.");
        }
        else
        {
            Console.WriteLine($"Produto '{nomeProduto}' não encontrado no estoque.");
        }
    }

    public void DiminuirPorcentagemDoValor()
    {
        Console.WriteLine("Digite o nome do produto para diminuir a porcentagem do valor:");
        string nomeProduto = Console.ReadLine().ToLower();

        if (estoque.ContainsKey(nomeProduto))
        {
            Console.WriteLine($"Digite a porcentagem de diminuição para '{nomeProduto}':");
            double porcentagemDiminuicao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Produto produto = estoque[nomeProduto];
            double diminuicao = produto.Preco * (porcentagemDiminuicao / 100.0);
            produto.Preco -= diminuicao;

            Console.WriteLine($"Preço de '{nomeProduto}' diminuído para {produto.PrecoFormatado}.");
        }
        else
        {
            Console.WriteLine($"Produto '{nomeProduto}' não encontrado no estoque.");
        }
    }

    public void SalvarEstoqueEmArquivo()
    {
        FazerBackupDoEstoque(arquivoEstoque); // Faz backup antes de salvar
        string json = JsonSerializer.Serialize(estoque);
        File.WriteAllText(arquivoEstoque, json);
    }

    private void CarregarEstoqueDoArquivo()
    {
        if (File.Exists(arquivoEstoque))
        {
            try
            {
                string json = File.ReadAllText(arquivoEstoque);
                estoque = JsonSerializer.Deserialize<Dictionary<string, Produto>>(json);
            }
            catch (JsonException)
            {
                Console.WriteLine("Erro ao carregar o arquivo de estoque. O arquivo não contém um JSON válido.");
            }
        }
    }

    private void FazerBackupDoEstoque(string arquivoEstoque)
    {
        string diretorioBackups = "backups_estoque";
    
        // Crie o diretório de backups se ele não existir
        if (!Directory.Exists(diretorioBackups))
        {
            Directory.CreateDirectory(diretorioBackups);
        }
    
        // Gere um nome de arquivo de backup único com base na data e hora
        string nomeBackup = $"estoque_backup_{DateTime.Now:yyyyMMddHHmmss}.json";
    
        // Copie o arquivo de estoque atual para o diretório de backups
        File.Copy(arquivoEstoque, Path.Combine(diretorioBackups, nomeBackup));
    }
}
