# AeC Endereços - Teste Técnico

**Objetivo do Teste:**
Desenvolver uma aplicação web em C# que permita ao usuário:
- Realizar login;
- Gerenciar um CRUD de endereços;
- Inserir endereço manualmente;
- Informar um CEP para buscar os dados automaticamente através da API ViaCEP;
- Exportar os endereços para CSV.

*As seções abaixo explicam como a solução foi implementada e como testá-la.*

---

Bem-vindo ao **AeC Endereços**! 

Este é um sistema web desenvolvido para facilitar e centralizar o gerenciamento de endereços. Através de uma interface amigável, você pode manter todos os seus endereços organizados e seguros num só lugar. 

O sistema foi pensado para ser prático e intuitivo, garantindo que qualquer pessoa consiga utilizá-lo sem complicações.

## O que o sistema entrega para você?

- **Acesso Seguro:** Você possui uma tela de login para garantir que apenas pessoas autorizadas (com usuário e senha) tenham acesso aos dados.
- **Busca de CEP Automática:** Chega de digitar a rua, bairro e cidade manualmente! Ao inserir um CEP, o sistema consulta a base do ViaCEP e preenche tudo para você em um piscar de olhos.
- **Gestão Completa (Tudo em Tela Única):** Você pode criar novos endereços, visualizar os detalhes de cada um, editar informações, e excluir endereços obsoletos. Tudo isso é feito em uma única tela, usando janelas que se abrem por cima da página (modais), tornando a navegação muito mais rápida e sem recarregar o site a todo momento!
- **Transparência (Auditoria):** No modal de detalhes do endereço, você consegue ver de forma clara **quem** criou aquele endereço e **quem** foi a última pessoa a atualizá-lo. *(Atenção: todos os usuários cadastrados podem ver a mesma lista de endereços do sistema).*
- **Exportação de Dados:** Precisa dos dados para um relatório ou planilha? Com apenas um clique no botão "Exportar CSV", você baixa todos os endereços cadastrados diretamente para o seu computador.
- **Aparência Moderna:** Um design claro, limpo e responsivo (funciona muito bem tanto no computador quanto no celular), com alertas amigáveis que confirmam quando um endereço é salvo ou deletado.

---

## Como rodar o sistema no seu computador

Nós preparamos duas formas simples de iniciar e usar o sistema. Escolha a que for mais conveniente para você!

### 💡 Opção 1: Usando o Docker (Recomendado - Mais rápido e fácil)
Se você tem o Docker instalado, esta é a opção ideal. O Docker baixa as ferramentas, liga o banco de dados e inicia o sistema, tudo com apenas um comando.

**Passo a passo:**
1. Abra o terminal (prompt de comando ou PowerShell) na pasta raiz do projeto.
2. Digite o seguinte comando e aperte Enter:
   ```bash
   docker-compose up --build -d
   ```
3. Aguarde alguns segundos. O Docker fará todo o trabalho pesado de criar o Banco de Dados, tabelas e rodar o Sistema Web.
4. Abra o seu navegador de internet e acesse: 👉 **http://localhost:5000**
5. **Faça o login** utilizando as credenciais padrão do sistema:
   - **Usuário:** `admin`
   - **Senha:** `Admin@123`
6. *Para desligar o sistema depois de usar:* Basta rodar `docker-compose down` no mesmo terminal.

### 🛠 Opção 2: Rodando Manualmente (Sem o Docker)
Se você é desenvolvedor, prefere rodar manualmente e já tem o **.NET 8** e o **SQL Server** instalados, siga os passos abaixo:

**Passo a passo:**
1. Se necessário, abra o arquivo `appsettings.json` (localizado em `src/AeC.Web`) e certifique-se de que a configuração `DefaultConnection` está apontando para o seu banco SQL Server local.
2. Abra o terminal na pasta raiz do projeto.
3. Para iniciar a aplicação, digite:
   ```bash
   dotnet run --project src/AeC.Web
   ```
4. A própria aplicação será inteligente o suficiente para criar o banco de dados, as tabelas e o usuário administrador caso ainda não existam.
5. Abra o seu navegador de internet e acesse a URL que aparecerá no console (normalmente 👉 **http://localhost:5002** ou **http://localhost:5000**).
6. **Faça o login** utilizando as credenciais padrão:
   - **Usuário:** `admin`
   - **Senha:** `Admin@123`

---

*Aproveite a facilidade e a agilidade na gestão dos seus endereços com o AeC Endereços!*
