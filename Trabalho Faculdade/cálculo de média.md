``` mermaid
graph TD
  subgraph Início
    A[Variáveis: <br>var notaProva1,<br>var notaProva2,<br>var media,<br>var status]
  end

  subgraph Entrada
    B[Digite a nota da Prova 1]
    C[Leia a nota da Prova 1]
    D[Digite a nota da Prova 2]
    E[Leia a nota da Prova 2]
  end

  subgraph Processamento
    F[Calcular a média: media = notaProva1 + notaProva2]
    F.a[ Divide a soma por 2 ]
    G[Exibir: A média final é: ]
  end

  subgraph Decisão
    H[Se media >= 6, então status = Aprovado]
    I[Se media < 6, então status = Reprovado]
  end

  subgraph Saída
    J[Exibir: O aluno está + status]
  end

  A --> B
  B --> C
  C --> D
  D --> E
  E --> F
  F --> F.a --> G
  G --> H
  G --> I
  H --> J
  I --> J
```