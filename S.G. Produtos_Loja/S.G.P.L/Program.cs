using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Produto
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; } // Adicionamos a propriedade de preço

    public Produto(int numero, string nome, decimal preco)
    {
        Numero = numero;
        Nome = nome;
        Preco = preco;
    }
        public void AlterarPreco(decimal novoPreco)
    {
        Preco = novoPreco;
    }
}


class Categoria
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public List<Produto> Produtos { get; set; }

    public Categoria(int numero, string nome)
    {
        Numero = numero;
        Nome = nome;
        Produtos = new List<Produto>();
    }
}

class Program
{
    static List<Categoria> categorias = new List<Categoria>();
    static string jsonFileName = "dados.json";

    static void Main(string[] args)
    {
        CarregarDados();

        while (true)
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("1. Adicionar categoria");
            Console.WriteLine("2. Remover categoria");
            Console.WriteLine("3. Adicionar produto");
            Console.WriteLine("4. Remover produto");
            Console.WriteLine("5. Modificar preço de um produto"); // Nova opção para modificar preço
            Console.WriteLine("6. Visualizar categorias e produtos");
            Console.WriteLine("7. Sair do programa");
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AdicionarCategoria();
                    break;
                case "2":
                    RemoverCategoria();
                    break;
                case "3":
                    AdicionarProduto();
                    break;
                case "4":
                    RemoverProduto();
                    break;
                case "5":
                    ModificarPrecoProduto();
                    break;
                case "6":
                    VisualizarCategoriasEProdutos();
                    break;                    
                case "7":
                    SalvarDados();
                    Console.WriteLine("Saindo do programa.");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                    break;
            }
        }
    }

    static void AdicionarCategoria()
    {
        Console.Write("Nome da categoria: ");
        string nome = Console.ReadLine();
        Categoria categoria = new Categoria(categorias.Count + 1, nome);
        categorias.Add(categoria);
        Console.WriteLine($"Categoria '{nome}' adicionada com sucesso!");
    }

    static void RemoverCategoria()
    {
        Console.Write("Digite o número da categoria a ser removida: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            Categoria categoriaRemovida = categorias.Find(c => c.Numero == numero);
            if (categoriaRemovida != null)
            {
                categorias.Remove(categoriaRemovida);
                Console.WriteLine($"Categoria '{categoriaRemovida.Nome}' removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Categoria não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }
    }

static void AdicionarProduto()
{
    Console.Write("Digite o número da categoria para adicionar o produto: ");
    if (int.TryParse(Console.ReadLine(), out int numeroCategoria))
    {
        Categoria categoriaSelecionada = categorias.Find(c => c.Numero == numeroCategoria);
        if (categoriaSelecionada != null)
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            // Solicita ao usuário que insira o preço do produto
            Console.Write("Preço do produto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Produto produto = new Produto(categoriaSelecionada.Produtos.Count + 1, nome, preco);
                categoriaSelecionada.Produtos.Add(produto);
                Console.WriteLine($"Produto '{nome}' adicionado à categoria '{categoriaSelecionada.Nome}' com sucesso!");
            }
            else
            {
                Console.WriteLine("Preço inválido. Produto não adicionado.");
            }
        }
        else
        {
            Console.WriteLine("Categoria não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}

    static void RemoverProduto()
    {
        Console.Write("Digite o número da categoria da qual deseja remover o produto: ");
        if (int.TryParse(Console.ReadLine(), out int numeroCategoria))
        {
            Categoria categoriaSelecionada = categorias.Find(c => c.Numero == numeroCategoria);
            if (categoriaSelecionada != null)
            {
                Console.Write("Digite o número do produto a ser removido: ");
                if (int.TryParse(Console.ReadLine(), out int numeroProduto))
                {
                    Produto produtoRemovido = categoriaSelecionada.Produtos.Find(p => p.Numero == numeroProduto);
                    if (produtoRemovido != null)
                    {
                        categoriaSelecionada.Produtos.Remove(produtoRemovido);
                        Console.WriteLine($"Produto '{produtoRemovido.Nome}' removido da categoria '{categoriaSelecionada.Nome}' com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado na categoria.");
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido para o produto.");
                }
            }
            else
            {
                Console.WriteLine("Categoria não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Número inválido para a categoria.");
        }
    }
static void ModificarPrecoProduto()
{
    Console.Write("Digite o número da categoria do produto: ");
    if (int.TryParse(Console.ReadLine(), out int numeroCategoria))
    {
        Categoria categoriaSelecionada = categorias.Find(c => c.Numero == numeroCategoria);
        if (categoriaSelecionada != null)
        {
            Console.Write("Digite o número do produto a ser modificado: ");
            if (int.TryParse(Console.ReadLine(), out int numeroProduto))
            {
                Produto produtoSelecionado = categoriaSelecionada.Produtos.Find(p => p.Numero == numeroProduto);
                if (produtoSelecionado != null)
                {
                    Console.Write("Novo preço do produto: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal novoPreco))
                    {
                        produtoSelecionado.AlterarPreco(novoPreco);
                        Console.WriteLine($"Preço do produto '{produtoSelecionado.Nome}' modificado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido. Nenhum preço foi modificado.");
                    }
                }
                else
                {
                    Console.WriteLine("Produto não encontrado na categoria.");
                }
            }
            else
            {
                Console.WriteLine("Número inválido para o produto.");
            }
        }
        else
        {
            Console.WriteLine("Categoria não encontrada.");
        }
    }
    else
    {
        Console.WriteLine("Número inválido para a categoria.");
    }
}

static void VisualizarCategoriasEProdutos()
{
    Console.WriteLine("Categorias e Produtos:");
    foreach (var categoria in categorias)
    {
        Console.WriteLine($"Categoria {categoria.Numero}: {categoria.Nome}");
        foreach (var produto in categoria.Produtos)
        {
            Console.WriteLine($"   Produto {produto.Numero}: {produto.Nome} - Preço: {produto.Preco:C}");
        }
    }
}

    static void CarregarDados()
    {
        if (File.Exists(jsonFileName))
        {
            string json = File.ReadAllText(jsonFileName);
            categorias = JsonSerializer.Deserialize<List<Categoria>>(json);
        }
    }

    static void SalvarDados()
    {
        string json = JsonSerializer.Serialize(categorias, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFileName, json);
    }
}
