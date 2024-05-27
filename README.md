# Controle de Estoque

## Visão Geral do Projeto

Este projeto é um sistema de controle de estoque desenvolvido para uma loja de roupas. O objetivo é gerenciar o cadastro de clientes, fornecedores, produtos e o registro de entrada e saída de produtos. O sistema permite manter um registro atualizado das informações, facilitar buscas e atualizações, garantir a integridade dos dados e gerar relatórios de movimentação de estoque. Note que este projeto se concentra na lógica de negócios e testes, sem a implementação de uma interface de usuário.

## Estrutura do Projeto

A estrutura do projeto está organizada em duas principais categorias: Domínio e Teste.

### Domínio

Contém as classes principais que representam os diferentes elementos do sistema:

- **Cliente.cs**: Define a entidade Cliente, incluindo atributos como nome, endereço, telefone, e-mail e histórico de compras.
- **Fornecedor.cs**: Define a entidade Fornecedor, incluindo atributos como nome da empresa, endereço, telefone, e-mail e termos de pagamento.
- **Produto.cs**: Define a entidade Produto, incluindo atributos como descrição, código de barras, preço de compra, preço de venda, quantidade em estoque e fornecedor.
- **Registro.cs**: Define a entidade Registro de movimentações, incluindo entradas e saídas de produtos, quantidade, valor, data e motivo da transação.

### Teste

Contém classes para testar as funcionalidades das classes do domínio, garantindo que os requisitos e critérios de aceitação sejam atendidos:

- **ClienteTeste.cs**: Testes unitários para a entidade Cliente.
- **FornecedorTeste.cs**: Testes unitários para a entidade Fornecedor.
- **ProdutoTeste.cs**: Testes unitários para a entidade Produto.
- **RegistroTeste.cs**: Testes unitários para a entidade Registro.
- **ClienteBuilder.cs**: Classe auxiliar para construir objetos Cliente para os testes.
- **FornecedorBuilder.cs**: Classe auxiliar para construir objetos Fornecedor para os testes.
- **ProdutoBuilder.cs**: Classe auxiliar para construir objetos Produto para os testes.
- **RegistroBuilder.cs**: Classe auxiliar para construir objetos Registro para os testes.
- **ExtensãoArgument.cs**: Extensões para facilitar a validação de argumentos nos testes.

## O que Eu Aprendi

Durante o desenvolvimento deste projeto, adquiri conhecimentos e habilidades importantes, tais como:

- **Modelagem de Dados**: Aprendi a estruturar dados para representar adequadamente entidades do mundo real em um sistema de software.
- **Validação de Dados**: Desenvolvi técnicas para garantir a integridade e a validade dos dados inseridos no sistema, como verificação de duplicidade e campos obrigatórios.
- **Testes Unitários**: Aprendi a escrever testes unitários para validar o comportamento esperado das funções e métodos do sistema, garantindo que os critérios de aceitação fossem atendidos.
- **Design Patterns**: Utilizei padrões de design como Builders para facilitar a criação de objetos complexos durante os testes.
- **Rastreabilidade de Transações**: Implementei funcionalidades para rastrear cada transação, fornecendo transparência e facilitando a auditoria e resolução de problemas.

## Imagem do Teste Executado

![Teste Executado](https://github.com/GabrielBandoch/GestaoEstoque/blob/master/Imagens/testesExecutados.png)

## Requisitos e Critérios de Aceitação

[Critérios de Aceitação](https://github.com/GabrielBandoch/GestaoEstoque/blob/master/Imagens/Controle%20de%20Estoque.pdf)


### Cadastro de Clientes
- **História do usuário**: Como dono de uma loja de roupas, quero cadastrar novos clientes para manter um registro atualizado das informações.
- **Critérios de aceitação**:
  - Inserção de informações obrigatórias (nome, endereço, telefone).
  - Validação do campo de e-mail (opcional, mas deve ser válido).
  - Geração de número de identificação único.
  - Atualização e busca de informações.
  - Visualização organizada dos detalhes do cliente.
  - Validação de campos obrigatórios.
  - Restrições de duplicidade.

### Cadastro de Fornecedores
- **História do usuário**: Como gerente de compras, quero cadastrar novos fornecedores para manter um registro organizado.
- **Critérios de aceitação**:
  - Inserção de informações obrigatórias (nome da empresa, endereço, telefone).
  - Possibilidade de fornecer detalhes adicionais (e-mail, termos de pagamento).
  - Atualização e busca de informações.
  - Visualização organizada dos detalhes do fornecedor.
  - Validação de campos obrigatórios.
  - Restrições de duplicidade.

### Cadastro de Produtos
- **História do usuário**: Como gerente de estoque, quero cadastrar novos produtos para manter um inventário preciso.
- **Critérios de aceitação**:
  - Inserção de informações obrigatórias (descrição, código de barras, preços).
  - Quantidade em estoque e custo inicial com valor 0.
  - Atualização e busca de informações.
  - Visualização organizada dos detalhes do produto.
  - Validação de campos obrigatórios.
  - Restrições de duplicidade.

### Registro de Entrada/Saída
- **História do usuário**: Como operador de caixa, quero registrar movimentações de produtos para manter um registro preciso do estoque.
- **Critérios de aceitação**:
  - Registro de entradas (quantidade, valor, data, fornecedor).
  - Registro de saídas (quantidade, valor, data, cliente).
  - Atualização automática da quantidade em estoque.
  - Visualização do histórico de transações.
  - Geração de relatórios de movimentação.
  - Validação de transações (não exceder estoque disponível).
  - Rastreabilidade de transações.
