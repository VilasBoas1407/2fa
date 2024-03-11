
# Two-Factor-Authenticator - (2fa)
Criar um aplicativo de 2FA(two-factor-authentication) tendo um app aonde irá guardar as chaves de autenticação e uma API que retorne um QR-Code para que possa ser vínculado. A ideia surgiu com base em uma curiosidade de entender com um app desse funcionaria. 


## Stack utilizada

**Front-end:** React Native, Redux

**Back-end:** .Net Core, MongoDB, Redis



## Instalação
Clonar o projeto e rodar a aplicação mobile

```bash
  cd app
  npm install my-project
  cd my-project
```

#### Docker

  - Mongo - Instalar mongo
  ```bash
  docker pull mongo

  ```
  - Mongo - Criar instância do mongo

  ```bash
  docker run --name 2fa-application -d -p 27017:27017 mongo

  ```

## Documentação

#### Infraestrutura
![image](https://github.com/VilasBoas1407/2fa/assets/29546480/59e8d23a-4b63-4456-b0a4-087b87f653be)

#### Fluxo obtenção de token
![image](https://github.com/VilasBoas1407/Two-Factor-Authenticator/assets/29546480/585fe69c-ccbd-483a-a823-d22fd291d7d5)

#### Fluxo atualização de tokens
![image](https://github.com/VilasBoas1407/Two-Factor-Authenticator/assets/29546480/891d2c49-9b99-4dcc-8a22-b02c14467004)

## Screenshots

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)


## Aprendizados

O que você aprendeu construindo esse projeto? Quais desafios você enfrentou e como você superou-os?

- Utilização de docker 
- Conceitos de múltiplos
