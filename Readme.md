# Descrição das tomadas de decisões e abordagens do problema

  Modelo do banco de dados: 

  ![DB](imagens/banco_de_dados.png)




## Rotas e descrição das funcionalidades

### * Importante:

  - Todas as requisições na Base Controller necessitam de um token, gerado através do método Authorization.

  - Com exceção da rota de criação de um novo usuario.

  - Essa Chave deve ir no campo de autorização da requisição como Berear Token

    

### 1 - POST Authenticate

- A rota recebe uma requisição POST para a validação de um usuário. Retornando um Token

- É esperado da requisição as informações de email e senha do usuário da requisição no seguinte formato:

  ```json
  {
    "email": "user@example.com",
    "password": "string"
  }
  ```

---

### 2 - GET user/{id}

- Essa rota recebe o id do usuário como parametro na url e caso o usuario exista, retorna o usuario encontrado

---

### 3 - GET user

- Essa rota retorna os usuários cadastrados no banco.

---

### 4 - POST user

- Essa rota recebe um novo usuário para cadastro.

- O Body esperado na requisição é do seguinte formato

- Essa requisição valida se CEP cadastrato existe e é valido.

  ```json
  {
    "name": "string",
    "email": "user@example.com",
    "cep": 0,
    "password": "string"
  }
  ```

---

### 5 -DELETE user

- Essa rota exclui um usuario existente logado.
- Através do id do usuário que se encontra no token da requisição, é en

---

### 6 - GET pet/{id}

- Retorna um pet referente ao Id colocado na Url com a condição desse Pet pertencer ao usuário que está logado.
- Validação do Id do usuário através do token

---

### 7 - GET pet

- Retorna os Pets pertencentes ao usuário logado, onde o ID do usuário e retirado do Token

---

### 8 - POST pet

- Essa adiciona um novo pet ao usuário logado.

- O body esperado narequisição:

  ```json
  {
    "name": "string",
    "breed": 1,
    "size": 3,
    "age": 0
  }
  ```

---

### 9 - DELETE pet

- Essa rota recebe um id do Pet para deletar ele do cadastro.

- Só é possível exlcuir o Pet caso o mesmo for do usuário logado.

  

### 10 - POST pet/localization/{petId}

- Essa rota recebe a latitude e uma longitute, atualizando uma tabela de histórico de localização do Pet.
- Ela valida sua localização, e salvo nobanco de dados.

---

### 11 - GET GenerateQrCodeImage/{petId}

- Essa rota retornar um endereço mais atual do pet, através de um link que gera um QR code  com todas as informações da pessoa

   cuidadora do pet e da localização.
