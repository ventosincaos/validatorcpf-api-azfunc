# API Validatora de CPF - Azure Functions
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)

## Descrição
Este projeto implementa um validador de CPF utilizando Azure Functions. A função principal permite validar se um CPF informado é válido ou inválido, verificando as regras de formatação e os dígitos verificadores.

## Funcionalidades
- **fnValidateCPF**: Valida o CPF informado, retornando se ele é válido ou inválido, e fornece detalhes sobre a validação.

## Estrutura do Projeto
- **ValidatorCPF.sln**: Solução principal do projeto.
- **validatorcpf-api-azfunc/**: Diretório que contém a implementação das Azure Functions para a validação de CPF.
- **host.json** e **local.settings.json**: Arquivos de configuração para a execução local das Azure Functions.

## Tecnologias Utilizadas
- **Azure Functions**: Utilizado para implementar funções serverless.
- **C#**: Linguagem principal do projeto.
- **HTML**: Utilizado na documentação ou interface da API (se aplicável).

## Como Executar

### Pré-requisitos:
- [Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local)
- [.NET Core SDK](https://dotnet.microsoft.com/download)
