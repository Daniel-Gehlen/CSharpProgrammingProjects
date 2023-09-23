using System;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Escolha uma categoria:");
            Console.WriteLine("1. Clima");
            Console.WriteLine("2. Trânsito");
            Console.WriteLine("3. Esportes");
            Console.WriteLine("4. Sair do programa");

            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Se chover (A), a rua ficará molhada (B).");
                    Console.WriteLine("Está chovendo (A).");
                    Console.WriteLine("Portanto, a rua está molhada (B).");
                    break;

                case 2:
                    Console.WriteLine("Se houver tráfego intenso (A), você se atrasará (B).");
                    Console.WriteLine("Há tráfego intenso (A).");
                    Console.WriteLine("Portanto, você se atrasará (B).");
                    break;

                case 3:
                    Console.WriteLine("Se você treinar duro (A), terá um bom desempenho (B).");
                    Console.WriteLine("Você treinou duro (A).");
                    Console.WriteLine("Portanto, terá um bom desempenho (B).");
                    break;

                case 4:
                    continuar = false;
                    Console.WriteLine("Programa encerrado.");
                    break;

                default:
                    Console.WriteLine("Escolha inválida. Por favor, escolha uma categoria válida.");
                    break;
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
