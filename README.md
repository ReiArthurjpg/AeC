# AeC Endereços





Aplicação Web ASP.NET Core MVC para gerenciamento seguro de endereços por usuário, com autenticação por cookie, CRUD completo, integração ViaCEP e exportação CSV.

## Tecnologias

- ASP.NET Core MVC 8
- C# / .NET 8
- Entity Framework Core
- SQL Server
- Cookie Authentication
- BCrypt.Net-Next
- Bootstrap 5
- Bootstrap Icons
- SweetAlert2
- xUnit e Moq

## Arquitetura

A solução segue arquitetura em camadas inspirada em Clean Architecture:

```text
src/
├── AeC.Web            # MVC, Controllers, Views, ViewModels, filtros e arquivos estáticos
├── AeC.Application    # DTOs, contratos e serviços de aplicação
├── AeC.Domain         # Entidades, interfaces de repositório e exceções de domínio
├── AeC.Infrastructure # EF Core, DbContext, configurations, repositories, ViaCEP, BCrypt e scripts SQL
└── AeC.Shared         # Tipos e extensões compartilhadas
tests/
└── AeC.Tests          # Testes unitários
```

## Funcionalidades

- Login real com ASP.NET Cookie Authentication.
- Senhas armazenadas com BCrypt.
- CRUD de endereços.
- Usuário visualiza apenas seus próprios endereços.
- Busca automática de CEP com ViaCEP.
- Exportação CSV por usuário logado.
- Paginação, pesquisa por CEP/cidade e ordenação por cidade.
- Interface responsiva com Bootstrap 5.
- Confirmação de exclusão com SweetAlert2.
- Exception filter global para evitar exposição de erros internos.

## Banco de Dados

Banco alvo: SQL Server.

Tabelas solicitadas:

### Usuarios

- Id
- Nome
- Usuario
- Senha

### Enderecos

- Id
- CEP
- Logradouro
- Complemento
- Bairro
- Cidade
- UF
- Numero
- UsuarioId

Scripts disponíveis em:

```text
src/AeC.Infrastructure/Scripts/001_create_tables.sql
src/AeC.Infrastructure/Scripts/002_seed_admin_user.sql
```

## Como executar

1. Configure a connection string em `src/AeC.Web/appsettings.json`.
2. Garanta que o SQL Server esteja acessível.
3. Restaure pacotes, aplique migrations e execute:

```bash
dotnet restore
dotnet ef database update --project src/AeC.Infrastructure --startup-project src/AeC.Web
dotnet run --project src/AeC.Web
```

> O `Program.cs` também chama `MigrateAsync` e executa o seed inicial quando a aplicação inicia.

## Usuário padrão

```text
Usuário: admin
Senha: Admin@123
```

Em produção, altere a senha padrão e prefira secrets/variáveis de ambiente.

## Fluxo do sistema

1. Usuário acessa a aplicação.
2. Caso não autenticado, é redirecionado para login.
3. Após autenticação, é direcionado ao dashboard de endereços.
4. Pode cadastrar, editar, detalhar, excluir, pesquisar e exportar endereços.
5. Ao informar CEP, a aplicação consulta ViaCEP e preenche os campos de endereço.

## Segurança

- Cookie authentication real.
- BCrypt para senha.
- AntiForgeryToken nos formulários.
- Validação server-side com DataAnnotations e ModelState.
- Sanitização básica em campos textuais.
- Filtro global de exceções.
- Restrições por `UsuarioId` nos serviços e repositórios.
- Não exposição de stack trace para usuário final.

## Testes

Execute:

```bash
dotnet test
```

Coberturas iniciais:

- `AuthService`
- `EnderecoService`
- `CsvExportService`

## Melhorias futuras

- Refresh tokens se houver API pública.
- Auditoria de alterações em endereços.
- Rate limit na consulta ViaCEP.
- Health checks.
- Docker Compose com SQL Server.
- Pipeline CI/CD.
- Observabilidade com OpenTelemetry.
- Políticas avançadas de senha.
