using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

class Dados
{
    public List<string> PadroesQualidade { get; set; } = new List<string>();
    public List<string> ComponentesEletronicos { get; set; } = new List<string>();
    public Dictionary<string, string> ComponentesQualidade { get; set; } = new Dictionary<string, string>();
}

class Program
{
    static Dados dados = new Dados();

    static void Main()
    {
        bool continuar = true;

        if (File.Exists("dados.json"))
        {
            string json = File.ReadAllText("dados.json");
            Dados? dadosDeserializados = JsonSerializer.Deserialize<Dados>(json);
            if (dadosDeserializados != null)
            {
                dados = dadosDeserializados;
            }
        }

        while (continuar)
        {
            Console.WriteLine("Escolha uma ação:");
            Console.WriteLine("1. Verificar Qualidade de Componente Eletrônico");
            Console.WriteLine("2. Acrescentar Padrão de Qualidade");
            Console.WriteLine("3. Excluir Padrão de Qualidade");
            Console.WriteLine("4. Acrescentar Componente Eletrônico");
            Console.WriteLine("5. Excluir Componente Eletrônico");
            Console.WriteLine("6. Visualizar Dados Ativos");
            Console.WriteLine("7. Sair do programa");

            int escolhaAcao = Convert.ToInt32(Console.ReadLine());

            switch (escolhaAcao)
            {
                case 1:
                    VerificarQualidadeComponente();
                    break;

                case 2:
                    AcrescentarPadraoQualidade();
                    break;

                case 3:
                    ExcluirPadraoQualidade();
                    break;

                case 4:
                    AcrescentarComponenteEletronico();
                    break;

                case 5:
                    ExcluirComponenteEletronico();
                    break;

                case 6:
                    VisualizarDadosAtivos();
                    break;

                case 7:
                    continuar = false;
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Escolha inválida. Por favor, escolha uma ação válida.");
                    break;
            }
        }

        string jsonDados = JsonSerializer.Serialize(dados);
        File.WriteAllText("dados.json", jsonDados);
    }

    static void VerificarQualidadeComponente()
    {
        Console.WriteLine("Digite o nome do componente eletrônico que deseja verificar:");
        string? componente = Console.ReadLine();
        if (componente != null)
        {
        if (dados.ComponentesEletronicos.Contains(componente))
        {
            Console.WriteLine("Escolha o padrão de qualidade a ser aplicado:");
            for (int i = 0; i < dados.PadroesQualidade.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {dados.PadroesQualidade[i]}");
            }

            int escolhaPadrao = Convert.ToInt32(Console.ReadLine()) - 1;

            if (escolhaPadrao >= 0 && escolhaPadrao < dados.PadroesQualidade.Count)
            {
                string padrao = dados.PadroesQualidade[escolhaPadrao];
                Console.WriteLine($"O componente '{componente}' atende ao padrão de qualidade '{padrao}' (A) ou não atende (B)?");
                Console.WriteLine("Digite 'A' para atende ou 'B' para não atende:");
                
                string? resposta = Console.ReadLine();

                if (resposta != null)
                {
                    resposta = resposta.ToUpper();

                if (resposta == "A")
                {
                    Console.WriteLine($"Componente '{componente}' validado como '{padrao}' (A).");
                    dados.ComponentesQualidade[componente] = "A";
                }
                else if (resposta == "B")
                {
                    Console.WriteLine($"Componente '{componente}' invalidado como '{padrao}' (B).");
                    dados.ComponentesQualidade[componente] = "B";
                }
                else
                {
                    Console.WriteLine("Resposta inválida. Verificação cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Resposta inválida. Verificação cancelada.");
            }
            }
            else
            {
                Console.WriteLine("Escolha de padrão inválida. Verificação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Componente eletrônico não encontrado. Verificação cancelada.");
        }
    }
    else
    {
        Console.WriteLine("Entrada inválida. Verificação cancelada.");
    }
    }

    static void AcrescentarPadraoQualidade()
    {
        Console.WriteLine("Digite um novo padrão de qualidade:");
        string? novoPadrao = Console.ReadLine();

        if (!string.IsNullOrEmpty(novoPadrao))
        {
            dados.PadroesQualidade.Add(novoPadrao);
            Console.WriteLine($"Padrão de qualidade '{novoPadrao}' acrescentado com sucesso.");
        }
        else
        {
            Console.WriteLine("Padrão de qualidade inválido. Por favor, insira um padrão válido.");
        }
    }

    static void ExcluirPadraoQualidade()
    {
        Console.WriteLine("Padrões de Qualidade Disponíveis:");
        for (int i = 0; i < dados.PadroesQualidade.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {dados.PadroesQualidade[i]}");
        }

        Console.WriteLine("Digite o número do padrão de qualidade que deseja excluir:");
        int indiceExcluir = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indiceExcluir >= 0 && indiceExcluir < dados.PadroesQualidade.Count)
        {
            string padrãoExcluído = dados.PadroesQualidade[indiceExcluir];
            dados.PadroesQualidade.RemoveAt(indiceExcluir);
            Console.WriteLine($"Padrão de qualidade '{padrãoExcluído}' excluído com sucesso.");
        }
        else
        {
            Console.WriteLine("Índice de padrão de qualidade inválido. Por favor, escolha um índice válido.");
        }
    }

    static void AcrescentarComponenteEletronico()
    {
        Console.WriteLine("Digite um novo componente eletrônico:");
        string? novoComponente = Console.ReadLine();

        if (!string.IsNullOrEmpty(novoComponente))
        {
            dados.ComponentesEletronicos.Add(novoComponente);
            Console.WriteLine($"Componente eletrônico '{novoComponente}' acrescentado com sucesso.");
        }
        else
        {
            Console.WriteLine("Componente eletrônico inválido. Por favor, insira um componente válido.");
        }
    }

    static void ExcluirComponenteEletronico()
    {
        Console.WriteLine("Componentes Eletrônicos Disponíveis:");
        for (int i = 0; i < dados.ComponentesEletronicos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {dados.ComponentesEletronicos[i]}");
        }

        Console.WriteLine("Digite o número do componente eletrônico que deseja excluir:");
        int indiceExcluir = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indiceExcluir >= 0 && indiceExcluir < dados.ComponentesEletronicos.Count)
        {
            string componenteExcluído = dados.ComponentesEletronicos[indiceExcluir];
            dados.ComponentesEletronicos.RemoveAt(indiceExcluir);
            Console.WriteLine($"Componente eletrônico '{componenteExcluído}' excluído com sucesso.");
        }
        else
        {
            Console.WriteLine("Índice de componente eletrônico inválido. Por favor, escolha um índice válido.");
        }
    }

    static void VisualizarDadosAtivos()
    {
        Console.WriteLine("Padrões de Qualidade Ativos:");
        foreach (var padrao in dados.PadroesQualidade)
        {
            Console.WriteLine(padrao);
        }

        Console.WriteLine("Componentes Eletrônicos Ativos:");
        foreach (var componente in dados.ComponentesEletronicos)
        {
            string status = dados.ComponentesQualidade.ContainsKey(componente) ? dados.ComponentesQualidade[componente] : "Não verificado";
            Console.WriteLine($"{componente} ({status})");
        }
    }
}
