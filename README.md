# Documentação

Documentação do sistema (DDD) com Event Storming.

1. Acesse a Documentação em [Link para o Miro](https://miro.com/welcomeonboard/NmJ4ajV3NW56V0V6OTF5dmlBVVdMOUpORDN1YlhNZEJ6M29SNERQN29ldmNUZDNrSjN5YUhnTFQxR2txWGxFZXwzNDU4NzY0NTg1MTI4OTQ1Njk3fDI=?share_link_id=8135649431).

# Sistema de Pedidos FastFood

Este é um sistema de pedidos de comida rápida desenvolvido em .NET8 utilizando arquitetura hexagonal. O sistema permite aos usuários realizar pedidos de produtos de diferentes categorias (Lanche, Acompanhamento, Bebida, Sobremesa), acompanhar o status dos pedidos e realizar pagamentos.


## Diagrama

Esboço
![Diagrama](https://github.com/user-attachments/assets/ae1f91fa-a3f2-42ea-a0db-ac90d75fb60f)

## Video


## Funcionalidades

- **Clientes:**
  - Cadastro do Cliente.
  - Identificação do Cliente via CPF.

- **Gerenciamento de Produtos e Categorias:**
  - CRUD completo para produtos e categorias.
  - Busca de produtos por categoria.
  
- **Pedidos:**
  - Criação de novos pedidos.
  - Atualização do status do pedido (Recebido, Em preparação, Pronto, Finalizado).
  - Adição de pagamento ao pedido.
  - Acompanhamento do status do pedido.
  
- **Pagamentos:**
  - Registro de pagamentos associados aos pedidos..

## Tecnologias Utilizadas

- **NET 8:**
- **Entity Framework Core:** Mapeamento objeto-relacional para o banco de dados SQL Server.
- **Docker:** Containerização da aplicação e do banco de dados para facilitar o deployment.
- **Swagger:** Documentação da API para facilitar o desenvolvimento e o teste.

## Configuração e Uso

1. Execute os scripts do k8s
- kubectl apply -f deployment-store-db.yaml
- kubectl apply -f svc-store-db.yaml
- kubectl apply -f deployment-store-api.yaml
- kubectl apply -f svc-store-api.yaml
- kubectl apply -f deployment-store-apipayment.yaml
- kubectl apply -f svc-store-apipayment.yaml

2. Acesse a aplicação Store em `http://localhost:8080/swagger/index.html`.
3. Acesse a aplicação Payment em `http://localhost:8480/swagger/index.html`.


## Fluxo

O sistema inicia com uma base de dados inicialmente preenchida.

1. Criar Cliente (cpf: apenas numeros **ClientController**
```/v1/Client/client``` 
 ```json
   {
      "name": "Halro",
      "cpf": "56954409049",
      "email": "Halro@email.com"
   }
```
2. Criar Categoria **CategoryController**
```/v1/category``` 
 ```json
    {
      "name": "Lanche"
    }
```
3. Criar Produto **ProductController**
```/v1/product``` 
 ```json
    {
      "name": "Hambúrguer",
      "price": 10,
      "categoryId": 1
    }
```
4. Listar produtos por categoria **CategoryController**
```/v1/Category/1``` 
 ```
   1    
 ```
5. Criar Pedido **OrderController**
```/v1/Order``` 
 ```json
    {
      "items": [
        {
          "productId": 1,
          "quantity": 2
        }
      ],
      "clientId": 1
    }
```
6. Mudar Status Pagamento (pago = 2) e Pedido vai para (EmPreparacao) **PaymentController**
```/v1/Payment/1``` 
```json
    2
```

7. Mudar Status do Pedido para Pronto e Finalizado **OrderController**
```/v1/Order/1/status``` 
```json
    4
```
8. Listar Pedidos **OrderController**
```/v1/Order```





## Licença
Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para obter mais detalhes.
