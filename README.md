# StoreApp

Desafio técnico com **integração de API externa**, **criação de endpoints**, **processamento de pedidos**, **persistência em banco de dados relacional** e **desenvolvimento de uma interface web simples**.

---

# Como executar o projeto:

## 1. Clonar o repositório

```bash
git clone https://github.com/paulosmvargas/StoreApp.git
```

## 2. Acessar a pasta do projeto

```bash
cd StoreApp
```

## 3. Acessar a pasta do Docker

```bash
cd docker
```

## 4. Subir os containers

```bash
sudo docker compose up -d
```

## 5. Containers criados

Quando o processo finalizar, o output esperado será semelhante a:

```
✔ Image docker-api             Built
✔ Image docker-ui              Built
✔ Network docker_default       Created
✔ Volume docker_postgres_data  Created
✔ Container storeapp-db        Created
✔ Container storeapp-api       Created
✔ Container storeapp-ui        Created
```

Após alguns segundos, quando a API terminar de inicializar, a interface poderá ser acessada em:

```
http://127.0.0.1:4200
```

---

## Informações úteis

- Todo o histórico do desenvolvimento pode ser acessado através dos [commits](https://github.com/paulosmvargas/StoreApp/commits/main/) no github.
- O acesso a documentação de endpoints está acessível em:
```
http://127.0.0.1:5011/swagger
```

# Tecnologias utilizadas:

## Backend (API)

- .NET Core Web API
- Entity Framework Core
- REST API
- HttpClient (integração com API externa)

## Frontend (UI)

- Angular
- TypeScript
- HTML
- SCSS
- RxJS
- Angular Router
- Angular HttpClient

## Banco de Dados

- PostgreSQL 16

## Infraestrutura

- Docker
- Docker Compose

---

# Principais decisões técnicas:

- **Fonte de produtos via API externa (FakeStore)**: o catálogo é consumido em tempo real com `HttpClient` e normalizado para `ProdutoDTO`, evitando acoplamento direto ao contrato externo e permitindo ajustar o formato usado na UI.

- **Estoque derivado e validação no pedido**: como a FakeStore não oferece controle transacional de estoque, o estoque é estimado na API e validado no momento do pedido para evitar quantidades inválidas.

- **Persistência apenas de pedidos e itens**: o banco armazena `Pedido` e `PedidoItem`, mantendo o histórico de compras sem duplicar o catálogo externo.

- **Criação de pedido com transação**: o fluxo de criação de pedido é protegido por transação para garantir consistência entre pedido e itens.

- **Tratamento de erros com middleware**: exceções de domínio simples são convertidas em respostas HTTP claras (400/500), mantendo padronização no retorno.

- **API com CORS liberado por padrão**: configurado de forma permissiva para ambiente de desenvolvimento, facilitando integração com o frontend.

- **Frontend em Angular com componentes standalone**: estrutura simples com `services` para integração e `AsyncPipe` para update reativo sem dependência de Zone.js.

- **Docker Compose** para subir DB, API e UI com um único comando, permitindo execução local previsível.

O banco de dados foi modelado para representar **pedidos e itens de pedido**, permitindo persistir transações realizadas no sistema e manter histórico consistente das compras.

O relacionamento principal consiste em:

- **Pedido**
- **Itens do Pedido**
- **Produtos**

Os produtos são consumidos a partir de uma **API externa (FakeStore API)** e utilizados para geração de pedidos no sistema.

---

## Diagrama Entidade-Relacionamento (DER)

![DER](https://raw.githubusercontent.com/paulosmvargas/StoreApp/refs/heads/main/db/der_storeapp.png)

A modelagem foi projetada para:

- manter **normalização adequada**
- permitir **expansão futura do domínio**
- garantir **integridade referencial entre pedidos e itens**
- evitar **redundância de dados**

A separação entre **pedido e itens** permite armazenar múltiplos produtos dentro de uma única transação de compra, mantendo consistência e flexibilidade na estrutura.

---

# Pontos de melhoria:

- Retornar DTOs no lugar de entidades EF para evitar acoplamento e vazamento do modelo do banco;

- Configurar mapeamentos via ModelBuilder para padronizar nomes de tabelas/colunas, índices e constraints (ex.: snake_case, tamanhos, uniques);

- Exceções de domínio com middleware de erro com códigos/erros padronizados (por exemplo: `BusinessException`, `NotFoundException`, `ValidationException`);

- Carrinho persistente usando gerenciamento de sessão, Redis/KeyDB para manter estado entre refreshs e múltiplos dispositivos;

- CORS restrito por ambiente, definindo origens permitidas e métodos específicos em produção;

- Implementação de Repository / Unit of Work para isolar persistência e facilitar testes;

- Controle de estoque consistente, mantendo estoque local transacional e sincronizando com a FakeStore (não é possível transacionar diretamente na API externa);

- Implementação de tela para visualização e consulta dos pedidos realizados pelo usuário;

- Normalização e validação de dados de pedidos antes da persistência (por exemplo, endereço do usuário);

- Observabilidade e performance, incluindo logs estruturados, métricas, cache e paginação onde for aplicável;

- Autenticação/Autorização com JWT para endpoints sensíveis (por exemplo, pedidos e carrinho persistido);

- Uso de SSL para deploy em produção (HTTPS).