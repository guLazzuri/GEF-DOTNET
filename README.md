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
