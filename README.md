# Validator CPF API - Azure Functions
HTML5 | C# | .NET | Azure Functions

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
