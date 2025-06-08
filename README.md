# GEF - Global Emergency Framework API 🚨

## 📋 Sobre o Projeto

O **GEF (Global Emergency Framework)** é uma API REST inovadora desenvolvida para gerenciar situações de emergência, conectando usuários, abrigos e dispositivos de monitoramento em tempo real. A solução foi criada como resposta a problemas críticos em períodos de extrema urgência, oferecendo uma plataforma integrada para coordenação de recursos e monitoramento de pessoas em situações de risco.

### 🎯 Propósito
- **Gerenciamento eficiente de abrigos** em situações de emergência
- **Monitoramento em tempo real** através de pulseiras inteligentes
- **Coordenação de recursos** entre diferentes tipos de usuários
- **Rastreamento de sinais vitais** para identificação precoce de problemas de saúde

## 🏗️ Arquitetura do Sistema

### Diagrama de Entidades
```mermaid
erDiagram
    SHELTER ||--o{ USER : "hospeda"
    USER ||--|| BRACELET : "possui"
    
    SHELTER {
        long ShelterID PK
        string Name
        string Address
        int Quantity
        int Capacity
    }
    
    USER {
        long UserID PK
        string Name
        int Age
        Gender Gender
        BloodType BloodType
        double Weight
        string ResponsableName
        string CPF
        string CardNumber
        UserType UserType
        long ShelterID FK
    }
    
    BRACELET {
        long BraceletID PK
        long UserId FK
        int LastBPM
        DateTime LastUpdate
    }
```

### Relacionamentos
- **Shelter (1:N) User**: Um abrigo pode hospedar múltiplos usuários
- **User (1:1) Bracelet**: Cada usuário possui uma pulseira de monitoramento

## 🛠️ Tecnologias Utilizadas

- **.NET Core** - Framework principal
- **Entity Framework Core** - ORM para persistência
- **SQL Server** - Banco de dados relacional
- **Swagger/OpenAPI** - Documentação da API
- **ASP.NET Core MVC** - Arquitetura web
- **C#** - Linguagem de programação

## 📦 Estrutura do Projeto
```
GEF-DOTNET/
├── Controllers/
│   ├── BraceletsController.cs
│   ├── SheltersController.cs
│   └── UsersController.cs
├── Domain/
│   ├── Entity/
│   │   ├── Bracelet.cs
│   │   ├── Shelter.cs
│   │   └── User.cs
│   └── Enum/
│       ├── BloodType.cs
│       ├── Gender.cs
│       └── UserType.cs
├── Dto/
│   ├── BraceletDto.cs
│   ├── ShelterDto.cs
│   └── UserDto.cs
├── Infrastructure/
│   ├── Context/
│   │   └── GefContext.cs
│   ├── Mappings/
│   │   ├── BraceletMapping.cs
│   │   ├── ShelterMapping.cs
│   │   └── UserMapping.cs
│   └── Persistence/
│       └── Repositories/
│           ├── IRepository.cs
│           └── Repository.cs
├── Migrations/
│   ├── 20250604025842_gef.cs
│   ├── 20250604025842_gef.Designer.cs
│   └── GefContextModelSnapshot.cs
└── README.md
```

## ☁️ Como Executar o Container

### 1. Execute 
```bash
sudo docker pull edunagado/biotag:latest
```
### 2. Execute
```bash
sudo docker run -d --name biotag-api -p 8080:8080 edunagado/biotag:latest
``` 

## 🚀 Como Executar o Projeto

### Pré-requisitos
- .NET 6.0 ou superior
- SQL Server (LocalDB ou instância completa)
- Visual Studio 2022 ou VS Code

### 1. Clone o Repositório
```bash
git clone https://github.com/guLazzuri/GEF-DOTNET.git
cd GEF-DOTNET
```

### 2. Configurar Connection String
Edite o arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=GefDB;Trusted_Connection=true;"
  }
}
```

### 3. Executar Migrations
```bash
dotnet ef database update
```

### 4. Executar o Projeto
```bash
dotnet run
```

### 5. Acessar a Documentação
- Swagger UI: `https://localhost:7000/swagger`
- API Base URL: `https://localhost:7000/api`

## 📊 Endpoints da API

### 👥 Users (Usuários)
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/users` | Lista todos os usuários |
| GET | `/api/users/{id}` | Busca usuário por ID |
| POST | `/api/users` | Cria novo usuário |
| PUT | `/api/users/{id}` | Atualiza usuário |
| DELETE | `/api/users/{id}` | Remove usuário |

### 🏠 Shelters (Abrigos)
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/shelters` | Lista todos os abrigos |
| GET | `/api/shelters/{id}` | Busca abrigo por ID |
| POST | `/api/shelters` | Cria novo abrigo |
| PUT | `/api/shelters/{id}` | Atualiza abrigo |
| DELETE | `/api/shelters/{id}` | Remove abrigo |

### ⌚ Bracelets (Pulseiras)
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/bracelets` | Lista todas as pulseiras |
| GET | `/api/bracelets/{id}` | Busca pulseira por ID |
| POST | `/api/bracelets` | Cria nova pulseira |
| PUT | `/api/bracelets/{id}` | Atualiza dados da pulseira |
| DELETE | `/api/bracelets/{id}` | Remove pulseira |

# 🧪 Testes da API

## 📸 Screenshots dos Testes

### Abrigos (Shelters)

#### POST /api/Shelters - Criação de Abrigo - 201 ✅
![Criação de abrigo](https://github.com/user-attachments/assets/d5aaec34-ba1c-4f52-b0a5-092e16c3f6b3)
*Criação de abrigo*

#### GET /api/Shelters - Listagem de Abrigos - 200 ✅
![Listagem de abrigos](https://github.com/user-attachments/assets/821f8048-13ab-4231-a5db-67092a1f25d4)
*Listagem de todos os abrigos cadastrados*

#### PUT /api/Shelters - Alteração de Abrigo - 204 ✅
![Alteração de abrigo](https://github.com/user-attachments/assets/ae1d9f45-b9d6-4857-bec5-d778ed5140c3)
*Alteração de abrigo*

#### GET /api/Shelters/7 - Busca Abrigo por ID - 200 ✅
![Busca abrigo por ID](https://github.com/user-attachments/assets/c920a021-43e6-48be-acc1-937b31c311df)
*Busca específica de abrigo por ID com dados do usuário associado*

#### DELETE /api/Shelters/7 - Remoção de Abrigo - 204 ✅
![Remoção de abrigo](https://github.com/user-attachments/assets/ddf86f2e-8fa7-4475-9735-1c64d2bc302d)
*Remoção de abrigo*

### Usuários (Users)

#### POST /api/Users - Criação de Usuário - 201 ✅
![Criação de usuário MEDICO](https://github.com/user-attachments/assets/fa0794d4-f447-47aa-9ea8-38a5a9267954)
*Criação de usuário MEDICO*

![Criação de usuário PACIENTE](https://github.com/user-attachments/assets/c1f6032f-f6c7-4a94-a8e2-843c85f93cee)
*Criação de usuário PACIENTE*

#### GET /api/Users - Listagem de Usuários - 200 ✅
![Listagem de usuários](https://github.com/user-attachments/assets/5b29d94d-a5bb-4541-a205-cf095082b17a)
*Listagem de todos os usuários cadastrados*

#### PUT /api/Users - Alteração de Usuário - 204 ✅
![Alteração de usuários](https://github.com/user-attachments/assets/44c0bc95-00fb-4bda-aa31-418a9d2fe1f0)
*Alteração de usuários*

#### GET /api/Users/16 - Busca Usuário por ID - 200 ✅
![Busca usuário por ID](https://github.com/user-attachments/assets/deb6fe70-daf2-4aa3-be11-868abea0367a)
*Busca específica de usuário por ID*

#### DELETE /api/Users/16 - Remoção de Usuário - 204 ✅
![Remoção de usuário](https://github.com/user-attachments/assets/367c8f2f-a523-424b-84ce-682602b02644)
*Remoção de usuário*

### Pulseiras (Bracelets)

#### POST /api/Bracelets - Criação de Pulseira - 201 ✅
![Criação de pulseira](https://github.com/user-attachments/assets/29756283-256c-4ec7-9177-2f551463b505)
*Criação de pulseira*

#### GET /api/Bracelets - Listagem de Pulseiras - 200 ✅
![Listagem de pulseiras](https://github.com/user-attachments/assets/07929b27-ee1e-4dd8-8e64-cee77e1a1a2f)
*Listagem de todas as pulseiras cadastradas*

#### PUT /api/Bracelets - Alteração de Pulseira - 204 ✅
![Alteração de pulseira](https://github.com/user-attachments/assets/6f2f0549-d6c4-423f-962b-73c7ffcfb44f)
*Alteração de pulseira*

#### GET /api/Bracelets/14 - Busca Pulseira por ID - 200 ✅
![Busca pulseira por ID](https://github.com/user-attachments/assets/ed499b06-e92d-4caa-afaf-5e4d08ed4b32)
*Busca específica de pulseira por ID*

#### DELETE /api/Bracelets/14 - Remoção de Pulseira - 204 ✅
![Remoção de pulseira](https://github.com/user-attachments/assets/9eed0037-a0f6-48e1-96ef-8f4feaf9c5f7)
*Remoção de pulseira*

## 📈 Resumo dos Resultados

| Endpoint | Método | Status | Descrição |
|----------|--------|--------|-----------|
| `/api/shelters` | GET | ✅ 200 | Lista todos os abrigos |
| `/api/shelters` | POST | ✅ 201 | Cria novo abrigo |
| `/api/shelters/{id}` | GET | ✅ 200 | Busca abrigo específico |
| `/api/shelters/{id}` | PUT | ✅ 204 | Atualiza abrigo específico |
| `/api/shelters/{id}` | DELETE | ✅ 204 | Remove abrigo específico |
| `/api/users` | GET | ✅ 200 | Lista todos os usuários |
| `/api/users` | POST | ✅ 201 | Cria novo usuário |
| `/api/users/{id}` | GET | ✅ 200 | Busca usuário específico |
| `/api/users/{id}` | PUT | ✅ 204 | Atualiza usuário específico |
| `/api/users/{id}` | DELETE | ✅ 204 | Remove usuário específico |
| `/api/bracelets` | GET | ✅ 200 | Lista todas as pulseiras |
| `/api/bracelets` | POST | ✅ 201 | Cria nova pulseira |
| `/api/bracelets/{id}` | GET | ✅ 200 | Busca pulseira específica |
| `/api/bracelets/{id}` | PUT | ✅ 204 | Atualiza pulseira específica |
| `/api/bracelets/{id}` | DELETE | ✅ 204 | Remove pulseira específica |

### ✅ Status dos Testes
- **Total de endpoints testados:** 15
- **Testes bem-sucedidos:** 15 (100%)
- **Testes falharam:** 0 (0%)

> **Nota:** Todos os endpoints da API foram testados com sucesso, demonstrando que as operações CRUD funcionam corretamente para todos os recursos (Abrigos, Usuários e Pulseiras).

### 🔍 Análise dos Testes

#### ✅ **Funcionalidades Confirmadas:**
- **Criação (POST)**: Funcionando para Shelters e Bracelets
- **Leitura (GET)**: Todos os endpoints GET funcionando perfeitamente
- **Listagem**: Retorno completo de dados com relacionamentos


#### 📊 **Dados de Teste Utilizados:**
```json
{
  "shelters": [
    {
      "shelterID": 28, <- APENAS INFORMANDO O NUMERO DO ID, NÃO NESCESSARIO!
      "name": "Teste Video",
      "address": "Rua Teste Video, 1",
      "quantity": 10,
      "capacity": 100
    }
  ],
  "users": [
    {
      "userID": 26, <- APENAS INFORMANDO O NUMERO DO ID, NÃO NESCESSARIO!
      "name": "Gustavo Lazzuri",
      "age": 20,
      "gender": "Masculine",
      "bloodType": "APositive",
      "weight": 70,
      "responsableName": "Andrea",
      "cpf": "123456789",
      "cardNumber": "12345",
      "userType": "ADMIN",
      "shelterID": 28
    }
  ],
  "bracelets": [
    {
      "braceletID": 25, <- APENAS INFORMANDO O NUMERO DO ID, NÃO NESCESSARIO
      "userId": 26,
      "lastBPM": 80,
      "lastUpdate": "2025-06-04T13:55:54.532Z"
    }
  ]
}
```

### 🚨 **Cenários de Emergência Testados:**
- **BPM Crítico**: Pulseira registrando 120 BPM (situação de alerta)
- **Relacionamentos**: Usuário associado corretamente ao abrigo
- **Capacidade**: Controle de lotação dos abrigos funcionando

## 🧪 Exemplos de Teste

### Criar um Abrigo
```bash
curl -X POST "https://localhost:7000/api/shelters" \
-H "Content-Type: application/json" \
-d '{
  "name": "Abrigo Central",
  "address": "Rua das Flores, 123 - São Paulo/SP",
  "quantity": 50,
  "capacity": 100
}'
```

### Criar um Usuário
```bash
curl -X POST "https://localhost:7000/api/users" \
-H "Content-Type: application/json" \
-d '{
  "name": "João Silva",
  "age": 35,
  "gender": "Masculine",
  "bloodType": "OPositive",
  "weight": 75.5,
  "responsableName": "Maria Silva",
  "cpf": "12345678901",
  "cardNumber": "CARD001",
  "userType": "PATIENT",
  "shelterID": 1
}'
```

### Criar uma Pulseira
```bash
curl -X POST "https://localhost:7000/api/bracelets" \
-H "Content-Type: application/json" \
-d '{
  "userId": 1,
  "lastBPM": 72,
  "lastUpdate": "2024-06-04T10:30:00"
}'
```

### Atualizar BPM da Pulseira
```bash
curl -X PUT "https://localhost:7000/api/bracelets/1" \
-H "Content-Type: application/json" \
-d '{
  "userId": 1,
  "lastBPM": 85,
  "lastUpdate": "2024-06-04T11:00:00"
}'
```

## 🔒 Validações e Regras de Negócio

### User (Usuário)
- **Nome**: 2-100 caracteres
- **Idade**: 0-130 anos
- **Peso**: 0-500 kg
- **CPF**: 11 dígitos numéricos
- **Tipo de Usuário**: ADMIN, DOCTOR, PATIENT

### Shelter (Abrigo)
- **Nome**: 2-100 caracteres
- **Endereço**: 5-200 caracteres
- **Capacidade**: Maior que 0
- **Quantidade**: Maior ou igual a 0

### Bracelet (Pulseira)
- **UserID**: Obrigatório
- **LastBPM**: Opcional (para casos de falha do sensor)
- **LastUpdate**: Obrigatório

## 🎯 Casos de Uso

### 1. Monitoramento de Emergência
```mermaid
sequenceDiagram
    participant B as Bracelet
    participant A as API
    participant D as Doctor
    
    B->>A: Envia BPM crítico (>120)
    A->>A: Atualiza dados da pulseira
    A->>D: Notifica médico sobre alerta
    D->>A: Consulta dados do paciente
    A->>D: Retorna informações completas
```

### 2. Gestão de Abrigos
```mermaid
sequenceDiagram
    participant U as User
    participant A as API
    participant S as Shelter
    
    U->>A: Solicita abrigo
    A->>S: Verifica capacidade
    S->>A: Confirma vaga disponível
    A->>A: Registra usuário no abrigo
    A->>U: Confirma alocação
```

## 📋 Testes Recomendados

### Testes Funcionais
1. **CRUD Completo** para todas as entidades
2. **Validação de dados** nos endpoints POST/PUT
3. **Relacionamentos** entre User-Shelter e User-Bracelet
4. **Códigos de resposta HTTP** apropriados

### Testes de Cenário
1. **Abrigo lotado**: Tentar adicionar usuário além da capacidade
2. **BPM crítico**: Simular valores de emergência (>120 bpm)
3. **Usuário sem pulseira**: Verificar integridade dos dados
4. **Múltiplos usuários**: Testar performance com muitos registros

### Script de Teste Automatizado
```bash
# Teste de fluxo completo
echo "=== Teste GEF API ==="

# 1. Criar abrigo
SHELTER_ID=$(curl -s -X POST "localhost:7000/api/shelters" \
  -H "Content-Type: application/json" \
  -d '{"name":"Teste Abrigo","address":"Rua Teste","quantity":0,"capacity":10}' | jq '.shelterID')

# 2. Criar usuário
USER_ID=$(curl -s -X POST "localhost:7000/api/users" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Teste User\",\"age\":30,\"gender\":\"Masculine\",\"bloodType\":\"OPositive\",\"weight\":70,\"userType\":\"PATIENT\",\"shelterID\":$SHELTER_ID}" | jq '.userID')

# 3. Criar pulseira
BRACELET_ID=$(curl -s -X POST "localhost:7000/api/bracelets" \
  -H "Content-Type: application/json" \
  -d "{\"userId\":$USER_ID,\"lastBPM\":75,\"lastUpdate\":\"2024-06-04T12:00:00\"}" | jq '.braceletID')

echo "Criados: Shelter=$SHELTER_ID, User=$USER_ID, Bracelet=$BRACELET_ID"
```

## 📚 Documentação Adicional

### Swagger/OpenAPI
A documentação completa da API está disponível em `/swagger` quando o projeto está em execução. Inclui:
- Descrição detalhada de todos os endpoints
- Modelos de dados (DTOs)
- Códigos de resposta HTTP
- Exemplos de requisições

### Postman Collection
Importe a collection para testes rápidos:
```json
{
  "info": { "name": "GEF API Tests" },
  "item": [
    {
      "name": "Get All Users",
      "request": {
        "method": "GET",
        "url": "{{baseUrl}}/api/users"
      }
    }
  ],
  "variable": [
    {
      "key": "baseUrl",
      "value": "https://localhost:7000"
    }
  ]
}
```

## 🔄 Migrations

O projeto utiliza Entity Framework Migrations para versionamento do banco:

```bash
# Criar nova migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations
dotnet ef database update

# Reverter migration
dotnet ef database update PreviousMigrationName
```

## 🌟 Funcionalidades Inovadoras

### 1. **Monitoramento Proativo**
- Coleta automática de dados vitais via pulseiras
- Alertas em tempo real para situações críticas
- Histórico de monitoramento para análise médica

### 2. **Gestão Inteligente de Recursos**
- Controle de capacidade dos abrigos
- Alocação otimizada de usuários
- Rastreamento de ocupação em tempo real

### 3. **Diferentes Perfis de Usuário**
- **ADMIN**: Gestão completa do sistema
- **DOCTOR**: Monitoramento médico e alertas
- **PATIENT**: Usuários monitorados

### 4. **Flexibilidade de Dados**
- Suporte a diferentes tipos sanguíneos
- Informações de responsáveis para menores
- Dados médicos essenciais para emergências

## 🚀 Roadmap Futuro

- [ ] **Notificações Push** para alertas críticos
- [ ] **Dashboard em tempo real** com métricas
- [ ] **Integração IoT** com mais dispositivos
- [ ] **Geolocalização** dos abrigos e usuários
- [ ] **Machine Learning** para predição de emergências
- [ ] **API de terceiros** para dados meteorológicos

## 👥 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para detalhes.

## 📞 Contato

**Desenvolvedor**: Gustavo Lazzuri  
**GitHub**: [guLazzuri](https://github.com/guLazzuri)  
**Projeto**: [GEF-DOTNET](https://github.com/guLazzuri/GEF-DOTNET)

---

⚡ **GEF - Conectando tecnologia e humanidade em momentos críticos** ⚡
