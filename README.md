# GamificacaoApp

Aplicativo de desktop para Windows desenvolvido em C# com Windows Forms, projetado para monitorar e gamificar o desempenho de funcionários em diferentes projetos.

## Descrição

O GamificacaoApp é uma ferramenta para gerentes ou equipes que desejam aplicar conceitos de gamificação para incentivar e medir a produtividade. O aplicativo lê dados de um arquivo CSV, calcula a pontuação dos funcionários com base em suas entregas e exibe um relatório e um ranking de desempenho.

## Funcionalidades Principais

### Importação de Dados
- Importa dados do arquivo `relatorio_gamificacao.xlsx`
- Processa informações sobre entregas dos funcionários, incluindo:
  - Nome do funcionário
  - Projeto
  - Data da entrega
  - Tipo de entrega

### Sistema de Pontuação
O sistema atribui pontos a cada tipo de entrega:
- Feature: 10 pontos
- Melhoria: 5 pontos
- Bug: 3 pontos
- Legado: 1 ponto

### Interface Gráfica
A aplicação possui uma interface de usuário intuitiva com:
- Botão para carregar o arquivo de relatório
- ListBox para exibir o relatório de pontuação
- ListBox para exibir o ranking dos funcionários (ordenado por pontuação)

## Estrutura do Projeto

### Models
- `Funcionario`: Representa um funcionário e seus dados
- `Projeto`: Representa um projeto
- `Gameficacao`: Contém a lógica para leitura do arquivo e cálculo de pontuação
- `Pontuacao`: Armazena a pontuação de um funcionário

### Forms
- Formulários para interação com o usuário
- Interface para visualização de relatórios e rankings

### Services
- Serviços para gerenciamento de dados
- Lógica de negócio da aplicação

## Requisitos

- Windows OS
- .NET Framework
- Visual Studio (recomendado)

## Como Executar

1. Clone o repositório
2. Abra a solução no Visual Studio
3. Compile e execute o projeto
4. Use o botão de importação para carregar o arquivo de relatório
5. Visualize os rankings e relatórios gerados

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests. 