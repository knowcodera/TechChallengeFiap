
# Documentação

Documentação do sistema (DDD) com Event Storming.

1. Acesse a Documentação em [Link para o Miro](https://miro.com/welcomeonboard/NmJ4ajV3NW56V0V6OTF5dmlBVVdMOUpORDN1YlhNZEJ6M29SNERQN29ldmNUZDNrSjN5YUhnTFQxR2txWGxFZXwzNDU4NzY0NTg1MTI4OTQ1Njk3fDI=?share_link_id=8135649431).

# Sistema de Pedidos FastFood

Este é um sistema de pedidos de comida rápida desenvolvido em .NET8 utilizando arquitetura hexagonal. O sistema permite aos usuários realizar pedidos de produtos de diferentes categorias (Lanche, Acompanhamento, Bebida, Sobremesa), acompanhar o status dos pedidos e realizar pagamentos.

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

1. Execute o Docker Compose para construir as imagens e iniciar os contêineres:
   docker-compose up 

2. Acesse a aplicação em `http://localhost:8080/swagger/index.html`.

## Fluxo

1. Criar Cliente (cpf: apenas numeros)
2. Criar Categoria
3. Criar Produto
4. Criar Pedido
5. Mudar Status Pagamento
6. Mudar Status do Pedido

## Licença
Este projeto está licenciado sob a licença MIT. Consulte o arquivo LICENSE para obter mais detalhes.
