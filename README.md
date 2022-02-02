# Clima-Tempo-Simples
Projeto de avaliação para vaga de emprego. Contém uma página de previsão de clima que utiliza principalmente .NET Framework com MVC.

Instruções para uso:
- Baixe o projeto
- Abra com o visual studio
- Utilize o script (pasta: /SQL) create database (ou crie um por si mesmo) em um servidor sql server local.
- Utilize o script (pasta: /SQL) create tables para criar a estrutura do banco
- Utilize o script (pasta: /SQL) PopularBancoPT1 para popular a tabela de Cidade e Estado
- Utilize o script (pasta: /SQL) PopularBancoPT2 para gerar previsões aleatórias para os próximos 10 dias (se precisar gerar novamente, basta limpar a tabela e chamar a PROCEDURE POPULARBANCO @CidadeId int = null

- Por fim mude a string de conexão no Web.config para apontar para o seu banco local recem criado.

Também adicionei .:
- Arquitetura DDD e padrão Repository
- Select2
- Stored Procedures pra gerar o dados para teste
- JQuery e Ajax
- Unity para DI
