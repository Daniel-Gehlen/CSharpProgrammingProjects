```mermaid
stateDiagram
    [*] --> Iniciar
    Iniciar --> EscolherCategoria: Continuar
    EscolherCategoria --> Clima: Escolha 1
    EscolherCategoria --> Transito: Escolha 2
    EscolherCategoria --> Esportes: Escolha 3
    EscolherCategoria --> Sair: Escolha 4
    Clima --> Iniciar
    Transito --> Iniciar
    Esportes --> Iniciar
    Sair --> [*]
```