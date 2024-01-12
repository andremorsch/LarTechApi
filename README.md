# LarTechApi
 Desafio Técnico

# Desafio Técnico Lar Tech

Desafio de criação de uma WEB Api itilizando linguagem C# com .Net 7. Utilizando SQL Server como banco de dados padrão.

Pacotes Utilizados:
- AutoMapper
- EntityFramework Core
- Swager Open Api

 
## Instalação

Sugiro utilizar o SQL Server através do doecker, para facilitar instalação:

```bash
  docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server

```
    
Após instalação e inicialização, deverá rodar as migrações atráves do Gerenciado de Pacotes Nuget

```
 Update-Database
```


## Documentação da API


### Pessoas:
#### Retorna todos as Pessoas

```http
  GET /api/Person
```

#### Retorna uma Pessoa pelo Id

```http
  GET /api/Person/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da pessoa que você quer |

#### Retorna uma Pessoa pelo CPF

```http
  GET /api/Person/cpf/{cpf}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cpf`      | `string` | **Obrigatório**. O cpf da pessoa que você quer |

#### Cria um cadastro de Pessoa

```http
  POST /api/Person
```
##### Body para requisição:

```
{
  "name": "string",
  "cpf": "stringstrin",
  "birthday": "1989-01-12T01:13:54.647Z",
  "isActive": true
}
```

#### Atualiza um cadastro de Pessoa
```http
  PUT /api/Person
```
##### Body para requisição:

```
{
  id: 1,
  "name": "string",
  "cpf": "stringstrin",
  "birthday": "1989-01-12T01:13:54.647Z",
  "isActive": true
}
```

#### Deleta um cadastro de Pessoa
```http
  DELETE /api/Person/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID da pessoa que você quer  deletar|

### Telefones

#### Retorna todos os Telefones

```http
  GET /api/Phone
```

#### Retorna um Telefone pelo Id

```http
  GET /api/Phone/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do telefone que você quer |

#### Cria um cadastro de Telefone

```http
  POST /api/Phone
```
##### Body para requisição:

```
{
  "phoneType": "string",
  "phoneNumber": "stringstri",
  "personId": 0
}
```

#### Atualiza um cadastro de Telefone
```http
  PUT /api/Phone
```
##### Body para requisição:

```
{
  "id": 1,
  "phoneType": "residencial",
  "phoneNumber": "479999727369",
  "personId": 1
}
```

#### Deleta um cadastro de Telefone
```http
  DELETE /api/Phone/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` | **Obrigatório**. O ID do telefone que você quer  deletar|