# Banking Project

## Descrição

O projeto **Banking** é uma aplicação de microsserviços desenvolvida para gerenciar operações bancárias, incluindo a gestão de contas, clientes, empréstimos e transações financeiras. Este sistema foi projetado para atender às demandas de um cliente do setor bancário, utilizando uma arquitetura de microsserviços para escalabilidade e flexibilidade.

## Arquitetura

A aplicação é composta por múltiplos microsserviços, cada um responsável por uma função específica. Os principais serviços incluídos neste projeto são:

- **AccountService**: Gerencia as contas bancárias dos clientes, incluindo criação de contas, atualizações e consultas de saldo.
- **CustomerService**: Responsável por armazenar e gerenciar as informações dos clientes.
- **LoanService**: Lida com a criação e o gerenciamento de empréstimos para os clientes, incluindo termos e status dos empréstimos.
- **TransactionService**: Gerencia as transações financeiras, como depósitos, retiradas e transferências entre contas.

Cada serviço é implementado de forma independente e comunica-se com os outros serviços por meio de APIs REST, garantindo uma integração eficiente e modularidade.

## Tecnologias Utilizadas

O projeto foi construído usando tecnologias modernas para garantir robustez, escalabilidade e facilidade de manutenção:

- **.NET Core**: Framework para o desenvolvimento dos serviços.
- **Docker**: Utilizado para a criação de containers, facilitando a orquestração e o deploy.
- **Kubernetes (k3s)**: Para orquestrar e gerenciar os microsserviços em containers.
- **Rancher**: Interface de gerenciamento para o Kubernetes.
- **AWS e Azure**: Plataformas de nuvem para hospedar e escalar a aplicação.
- **Service Mesh (Istio)**: Utilizado para facilitar a comunicação entre os serviços, garantindo segurança e observabilidade.
- **Message Brokers**: RabbitMQ e Kafka para mensageria entre os serviços, garantindo comunicação assíncrona eficiente.
- **SQL Server e MongoDB**: Banco de dados relacional e NoSQL para armazenamento de dados.

## Funcionalidades

- **Criação e Gerenciamento de Contas**: Criação de contas bancárias, consulta de saldo e atualização de informações.
- **Gerenciamento de Clientes**: Registro e atualização dos dados dos clientes.
- **Empréstimos**: Solicitação, aprovação e acompanhamento de empréstimos bancários.
- **Transações Bancárias**: Depósitos, retiradas e transferências entre contas.
- **Orquestração e Observabilidade**: Utilização de Rancher e Istio para gestão centralizada e monitoramento das operações dos serviços.

## Estrutura do Repositório

```plaintext
.
├── AccountService/      # Código e configurações do serviço de contas
├── CustomerService/     # Código e configurações do serviço de clientes
├── LoanService/         # Código e configurações do serviço de empréstimos
├── TransactionService/  # Código e configurações do serviço de transações
├── docker-compose.yml   # Configuração do Docker Compose (se aplicável)
├── k8s/                 # Manifests do Kubernetes para orquestração
└── README.md            # Este arquivo
