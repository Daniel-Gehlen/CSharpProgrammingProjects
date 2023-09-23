# Fluxograma do App

``` mermaid
graph TD
    subgraph Início
    A[Carregar Dados]
    end

    subgraph LoopPrincipal
    B{Continuar?}
    C[Exibir Opções]
    D[Adicionar Categoria]
    E[Remover Categoria]
    F[Adicionar Produto]
    G[Remover Produto]
    H[Modificar Preço]
    I[Visualizar Categorias e Produtos]
    J[Sair e Salvar Dados]
    B --> |Sempre| C
    C --> |1| D
    C --> |2| E
    C --> |3| F
    C --> |4| G
    C --> |5| H
    C --> |6| I
    C --> |7| J
    D --> Categoria
    E --> Categoria
    F --> Categoria
    G --> Categoria
    H --> Produto
    I --> LoopPrincipall
    J --> Fim
    end

    subgraph Categoria
    K{Continuar?}
    L[Adicionar Produto]
    M[Remover Produto]
    Categoria --> |Categoria Selecionada| K
    K --> |1| L
    K --> |2| M
    L --> K
    M --> K
    end

    subgraph Produto
    N{Continuar?}
    O[Modificar Preço]
    Produto --> |Produto Selecionado| N
    N --> |5| O
    O --> N
    end

    subgraph Fim
    end

    A --> B
```