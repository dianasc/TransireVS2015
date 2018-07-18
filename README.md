# TransireVS2015
Código-fonte desenvolvido com VS2015. Fazendo uso da tecnologia .NET Framework 4.5
Foi iniciado o desenvolvimento de duas soluções independentes:

Solução 1 - Service: Desenvolvida uma webapi com tecnologia REST para que pudesse ser consumida pela Solução 2 (Web), ou qualquer aplicação.
Esta solução será a responsável pela persistência dos dados.

Solução 2 - WebApp: Desenvolvida uma aplicação MVC. Esta aplicação conterá as principais validações e interações com o usuário.

________________________________________________________________________________________________________________________________

Tecnologias:
  Para o desenvolvimento destas soluções foi utilizado o Visual Studio Community 2015, banco de dados SqlServer2014 e SGBD SqlServer Management Studio 2014.
  
Instalação:
  1. Baixar as soluções(Service e WebApp) do repositório
  2. Abrir o SGBD e criar o banco de dados chamado "LojaVirtual"
  3. Abrir a aplicação Service
  4. Abrir o console do Nuget
  5. Executar o comando add-migration RestoreDatabase
  6. Atualizar o banco de dados através do comando Update-Database
  7. Executar aplicação Service
  8. Abrir aplicação WebApp
  9. Atualizar a propridade "hostService" no arquivo web.config - O valor deve ser o endereço que a aplicação Service esta executando
  10. Executar a aplicação WebApp
