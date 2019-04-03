# NetCore-InfraData
Aplicação que utiliza uma aplicação acessando um backend uma api configurada com acesso a dados usando Dapper, entityFramework além de usar o pattern UnitOfWork.

Versão inicial
Camadas do projeto
- Service.API
   Swagger: para documentar a API
   
- Application
   AutoMapper: para mapeamento de entidades de Dominio para Aplicação e de aplicação para Dominio

- Domain
   FluentValidation: para implementação de Notification pattern 

- Infra
  Data - implementação do Repository pattern 
   EntityFramewokCore: para persistencia nos repositorios
   Dapper: para consultas no repositorio
   Mapeamento de entidades e repositorios
   Implementação do UnitOfWork pattern

  CrossCutting
   Implementação de injeção de dependencia nativa do NetCore
