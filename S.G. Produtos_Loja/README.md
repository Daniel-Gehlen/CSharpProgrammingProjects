# Sistema de Gerenciamento de Produtos em uma Loja Virtual

## Descrição da Missão:

A empresa "TechMart" deseja criar um sistema de gerenciamento de produtos para sua loja virtual. Eles querem categorizar produtos com base em suas características e permitir que os usuários visualizem produtos dentro de categorias específicas.

# Tarefas:

**Desenvolver um programa** que permita aos funcionários da TechMart criar categorias de produtos e associar características a essas categorias. Isso envolverá a criação de afirmações particulares do tipo "Alguns S são P". Por exemplo, criar uma afirmação como "Algumas roupas são casacos."

**Implementar uma funcionalidade** que permita aos usuários visualizar produtos dentro de uma categoria específica. Isso envolverá a consulta das afirmações criadas para determinar quais produtos estão associados a cada categoria.

**Garantir que o programa seja amigável ao usuário**, com opções claras para criar afirmações, visualizar produtos e sair do programa.

**Testar o programa** com exemplos e garantir que funcione corretamente.

**Documentar o código** e fornecer instruções claras de uso para os funcionários da TechMart.

Essa missão desafia a aplicar a estrutura lógica de afirmações particulares para criar um sistema de categorização de produtos. Isso ajuda a empresa a organizar seu inventário de forma eficiente e permite aos clientes encontrar produtos relevantes com facilidade.

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
## Atualizações do Programa em Ordem Cronológica:

- Criamos uma **classe Produto** e uma **classe Categoria** para representar produtos e categorias, **incluindo um método AdicionarProduto()** para adicionar produtos às categorias.

- Implementamos uma **funcionalidade para remover categorias e produtos** com base nos números atribuídos a cada um.
  
- Adicionamos a **capacidade de listar categorias e produtos em ordem**, com números associados.
  
- Introduzimos a **capacidade de salvar e carregar dados** em um arquivo JSON para persistência.
  
- **Atualizamos a classe Produto** para incluir uma propriedade de preço.
  
- **Permitimos que o usuário insira preços** ao adicionar produtos à categoria.
  
- Adicionamos uma **opção "Modificar preço de um produto"** para permitir que o usuário altere o preço de um produto existente.
  
- **Modificamos o método VisualizarCategoriasEProdutos()** para exibir os preços dos produtos na lista.
  
- Garantimos que o **programa valide a entrada do usuário** para garantir que os dados inseridos sejam válidos, incluindo preços e números de categoria/produto.
  
- Atualizamos a **opção "Visualizar categorias e produtos"** para exibir preços formatados como moeda (R$).
  
- Finalmente, garantimos que o programa seja **organizado e eficiente em relação à lógica e à interface do usuário**, proporcionando uma experiência de gerenciamento de produtos mais completa para a TechMart.

- Com essas atualizações, o programa permite que a TechMart gerencie suas categorias e produtos, incluindo preços, de forma eficaz, com persistência de dados em um arquivo JSON e funcionalidades de adição, remoção e modificação.