using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, List<string>> categorias = new Dictionary<string, List<string>>();
    const string arquivoCategorias = "categorias.txt";

    static void Main()
    {
        CarregarCategorias();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("1. Exibir categorias");
            Console.WriteLine("2. Adicionar categoria");
            Console.WriteLine("3. Remover categoria");
            Console.WriteLine("4. Verificar categorias e seus produtos existentes");
            Console.WriteLine("5. Sair");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    ExibirCategorias();
                    break;
                case 2:
                    AdicionarCategoria();
                    break;
                case 3:
                    RemoverCategoria();
                    break;
                case 4:
                    VerificarCategorias();
                    break;
                case 5:
                    continuar = false;
                    SalvarCategorias();
                    break;
                default:
                    Console.WriteLine("Escolha inválida.");
                    break;
            }
        }
    }

    static void CarregarCategorias()
    {
        if (File.Exists(arquivoCategorias))
        {
            using (StreamReader sr = File.OpenText(arquivoCategorias))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] partes = linha.Split(':');
                    string categoria = partes[0];
                    string[] produtos = partes[1].Split(',');
                    categorias[categoria] = new List<string>(produtos);
                }
            }
        }
    }

    static void SalvarCategorias()
    {
        using (StreamWriter sw = File.CreateText(arquivoCategorias))
        {
            foreach (var categoriaProdutoPair in categorias)
            {
                string categoria = categoriaProdutoPair.Key;
                string produtos = string.Join(",", categoriaProdutoPair.Value);

                string linha = categoria + ":" + produtos;
                sw.WriteLine(linha);
            }
        }
    }

    static void ExibirCategorias()
    {
        Console.WriteLine("Categorias Disponíveis:");
        foreach (var categoria in categorias.Keys)
        {
            Console.WriteLine(categoria);
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void AdicionarCategoria()
    {
        Console.WriteLine("Digite o nome da categoria:");
        string novaCategoria = Console.ReadLine();

        if (!categorias.ContainsKey(novaCategoria))
        {
            categorias[novaCategoria] = new List<string>();
            Console.WriteLine($"{novaCategoria} foi adicionada.");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine($"Opções para {novaCategoria}:");
                Console.WriteLine("1. Adicionar produto a essa categoria");
                Console.WriteLine("2. Remover produto dessa categoria");
                Console.WriteLine("3. Voltar");

                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        AdicionarProduto(novaCategoria);
                        break;
                    case 2:
                        RemoverProduto(novaCategoria);
                        break;
                    case 3:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine($"A categoria {novaCategoria} já existe.");
        }
    }

    static void RemoverCategoria()
    {
        Console.WriteLine("Categorias Disponíveis:");
        foreach (var categoriaExistente in categorias.Keys)
        {
            Console.WriteLine(categoriaExistente);
        }

        Console.WriteLine("Digite o nome da categoria a ser removida:");
        string categoriaParaRemover = Console.ReadLine();

        if (categorias.ContainsKey(categoriaParaRemover))
        {
            categorias.Remove(categoriaParaRemover);
            Console.WriteLine($"{categoriaParaRemover} foi removida.");
        }
        else
        {
            Console.WriteLine($"A categoria {categoriaParaRemover} não existe.");
        }
    }

    static void AdicionarProduto(string categoria)
    {
        Console.WriteLine("Digite o nome do produto:");
        string produto = Console.ReadLine();

        if (!categorias[categoria].Contains(produto))
        {
            categorias[categoria].Add(produto);
            Console.WriteLine($"{produto} foi adicionado à categoria {categoria}.");
        }
        else
        {
            Console.WriteLine($"{produto} já existe na categoria {categoria}.");
        }
    }

    static void RemoverProduto(string categoria)
    {
        Console.WriteLine($"Produtos na categoria {categoria}:");
        foreach (var produtoExistente in categorias[categoria])
        {
            Console.WriteLine(produtoExistente);
        }

        Console.WriteLine("Digite o nome do produto a ser removido:");
        string produtoParaRemover = Console.ReadLine();

        if (categorias[categoria].Contains(produtoParaRemover))
        {
            categorias[categoria].Remove(produtoParaRemover);
            Console.WriteLine($"{produtoParaRemover} foi removido da categoria {categoria}.");
        }
        else
        {
            Console.WriteLine($"{produtoParaRemover} não foi encontrado na categoria {categoria}.");
        }
    }

    static void VerificarCategorias()
    {
        Console.WriteLine("Categorias Disponíveis:");
        foreach (var categoriaExistente in categorias.Keys)
        {
            Console.WriteLine(categoriaExistente);
        }

        Console.WriteLine("Escolha uma categoria para verificar:");
        string categoriaParaVerificar = Console.ReadLine();

        if (categorias.ContainsKey(categoriaParaVerificar))
        {
            Console.WriteLine($"Produtos disponíveis na categoria {categoriaParaVerificar}:");
            foreach (var produtoExistente in categorias[categoriaParaVerificar])
            {
                Console.WriteLine(produtoExistente);
            }
        }
        else
        {
            Console.WriteLine($"Categoria {categoriaParaVerificar} não encontrada.");
        }

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
