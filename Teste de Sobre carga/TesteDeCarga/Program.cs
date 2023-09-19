using System;

namespace ProbabilidadeSobrecarga
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalComputadores = 13;
            int computadoresEscritorioC = 5;
            int escritorios = 3;
            int pontosAcessoPorEscritorio = 5;

            int cenarioI = 0;
            int cenarioII = 0;

            // Cenário I: Dois escritórios com todos os pontos de acesso e um com 3 pontos.
            for (int i = 0; i <= escritorios; i++)
            {
                for (int j = 0; j <= escritorios; j++)
                {
                    for (int k = 0; k <= escritorios; k++)
                    {
                        if (i * pontosAcessoPorEscritorio + j * pontosAcessoPorEscritorio + k * 3 == totalComputadores)
                        {
                            if (k == 1) // Se o escritório C tem 3 computadores
                            {
                                cenarioI++;
                            }
                        }
                    }
                }
            }

            // Cenário II: Um escritório com todos os pontos de acesso e dois com 4 pontos.
            for (int i = 0; i <= escritorios; i++)
            {
                for (int j = 0; j <= escritorios; j++)
                {
                    for (int k = 0; k <= escritorios; k++)
                    {
                        if (i * pontosAcessoPorEscritorio + j * 4 + k * 4 == totalComputadores)
                        {
                            if (i == 1) // Se o escritório A tem todos os pontos de acesso
                            {
                                cenarioII++;
                            }
                        }
                    }
                }
            }

            // Calcular a probabilidade de a sobrecarga ter vindo do escritório C.
            int totalCenarios = cenarioI + cenarioII;
            double probabilidadeC = (double)cenarioI / totalCenarios * 100;

            Console.WriteLine($"Probabilidade de sobrecarga do escritório C: {probabilidadeC}%");
        }
    }
}

