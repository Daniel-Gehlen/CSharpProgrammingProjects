using System;

class Program
{
    static void Main()
    {  
       //Você declarou as variáveis totalAprovacoes e totalReprovacoes no início 
       //do programa porque essas variáveis são usadas para rastrear o número total 
       //de aprovações e reprovações em todas as combinações possíveis. Esses contadores
       //são necessários para fornecer um resultado global no final da execução do 
       //programa para rastrear totais globais.
        int totalAprovacoes = 0;
        int totalReprovacoes = 0;

        //Por outro lado, você não precisa declarar as variáveis 
        //a, b e c no início do programa porque essas variáveis são usadas localmente 
        //dentro dos loops aninhados. Elas são redefinidas a cada iteração dos loops 
        //e não precisam ser declaradas antecipadamente.
        //Loop para gerar todas as combinações possíveis de votos (0 ou 1) 
        //para A, B e C. 
        for (int a = 0; a <= 1; a++)
        {
            for (int b = 0; b <= 1; b++)
            {
                for (int c = 0; c <= 1; c++)
                {
                    // Verifica se o executivo (E) votou a favor (1)
                    if (a == 1)
                    {
                        // Verifica se pelo menos um dos outros membros (F ou RI) votou a favor (1)
                        if (b == 1 || c == 1)
                        {
                            Console.WriteLine($"Aprovado: A={a}, B={b}, C={c}");
                            totalAprovacoes++;
                        }
                        else
                        {
                            Console.WriteLine($"Reprovado: A={a}, B={b}, C={c}");
                            totalReprovacoes++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Reprovado: A={a}, B={b}, C={c}");
                        totalReprovacoes++;
                    }
                }
            }
        }
    Console.WriteLine("Total de Aprovações: " + totalAprovacoes);
    Console.WriteLine("Total de Reprovações: " + totalReprovacoes);
    }
}

