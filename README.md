# 📚 Backend - Plataforma de Apoio a Estudos para Concursos Públicos

Este repositório contém o **back-end** da solução **WEB** desenvolvida como parte da disciplina **Projeto Integrador: Machine Learning**, do curso de **Engenharia de Software**.  

O objetivo do sistema é fornecer uma infraestrutura sólida para apoiar estudantes de **concursos públicos**, resolvendo dificuldades específicas apontadas em **editais**, organizando conteúdo de estudo e possibilitando integração futura com modelos de **IA/LLM** (Large Language Models).

---

## 🎯 Objetivo da Solução
A plataforma tem como missão **reduzir barreiras no aprendizado de matérias exigidas em concursos públicos**, através de:
- Estruturação de conteúdos por edital.
- Geração de questões e avaliações para validação do aprendizado.
- Organização de questões por disciplina e nível.
- Preparação de endpoints para recomendação personalizada via **Machine Learning** e **LLM**.

---

## 🛠️ Tecnologias Utilizadas
- **.NET 9 (ASP.NET Core Web API)** – Estrutura do back-end.  
- **PostgreSQL** – Banco de dados relacional para armazenar usuários, conteúdos, editais e estatísticas.  
- **Entity Framework Core** – ORM para persistência de dados.  
- **Swagger / OpenAPI** – Documentação e testes dos endpoints.  
- **Docker** – Containerização do ambiente.  

---

## 📂 Estrutura do Projeto
/Domain -> Entidades de negócio e regras de domínio
/Repository -> Persistência de dados (EF Core + PostgreSQL)
/Service -> Regras de negócio e integrações
/Application -> Orquestração e escopos de transação de dados
/Api -> APIs REST

## 🖥️ Executando o projeto
### Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 16+](https://www.postgresql.org/)
- [Docker](https://www.docker.com/) (opcional, para rodar o banco em container)

### Passos
```
// Clonar o repositório
git clone https://github.com/angelum23/SistemaConcursoPublico.git
cd SistemaConcursoPublico

// Restaurar pacotes
dotnet restore

// Rodar migrações do banco (caso ouverem)
dotnet ef database update

// Executar a API
dotnet run --project src/SistemaConcursoPublico.Api
```
