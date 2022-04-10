# ProjetoFinalAWS
Trabalho final da disciplina: APIs e Web Services (AWS)

Alunos:
Caique Assis Silva - 138912
Lucas Vasconcelos - 1359738

API desenvolvida para o gerenciamento de um torneio de futebol.
Neste desenvolvimento foi utilizado a linguagem C# com a plataforma .Net Core, este projeto é uma API REST, sendo assim requisitada via HTTP, também é padronizada com o nivel 2 no modelo de naturidade de Richardson. Utilizamos o desenvolvimento em camada e aplicamos o metodo de banco de dados relacionado, utilizamos o Entity Framework para a manipulação de dados e utlizamos o Repository pattern para o padronização da lógica e serviços. Nesta api é utlizada RabbitMQ para o serviço de mensageria, onde serão eventos das partidas e implentamos o cahce em memória para que algumas consultas só fossem realizadas varias vezes.

