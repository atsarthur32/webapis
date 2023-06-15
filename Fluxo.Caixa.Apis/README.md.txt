APIs
#Fluxo.Lancamentos.Caixa.Api
#Fluxo.RelatorioDiario.Api

Ambas as APIS estão no mesmo SLN pois compartilha da mesma estrutura de dados, porem podem ser publicadas como microserviços apartados.

Para esta aplicação executar será necessario ter os seguintes softwares:

- Visual Studio com Net Core 6 
- SQL Management Studio ou outro software equivalente
- Docker Desktop 

Seguir os passos abaixo:

Caso ja tenha o SQL server instalado na maquina pode pular o passo 1 e 2:

1 - Baixar a imagem pardrão do docket utilizando o comando abaixo:

 docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

----------=-----------------------------------------------------------------------------------------
2 - Iniciar sua Imagem utilizando o comando abaixo que definira a senha do SA como Cacique2@.

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Cacique2@"  -p 1433:1433 --name dbSchool -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

----------=-----------------------------------------------------------------------------------------
3 - Criar o DataBase de forma manual chamado DB_FLUXOCAIXA. 

----------=-----------------------------------------------------------------------------------------
4 - Executar o script anexo na pasta de pré requisitos do projeto (Fluxo.Caixa.Apis\ScriptBanco)

Obs: Recomendo utitizar o script ao invés do Migration, pois ele ja esta populando as tabelas de dominio da aplicação.

---------------------------------------------------------------------------------------------------

#Fluxo.Lancamentos.Caixa.Api

Será necessario iniciar a utilização da Api Cadastrando novos Registros para entender os valores possiveis em cada campo.

Obs: Campo data deve ser enviado o padrao yyyy-MM-dd
     Passar o TipoPagamento como zero retorna todos os tipos de pagamento.
     Utilizando meu script será cadastrado dois tipos de pagamentos ( 1 -Débito,  2 -Credito )
     Foram Cadastrado 3 empresas como exemplo ( 1 , 2 , 3)

#Fluxo.RelatorioDiario.Api

Foi criado uma estrutura priorizando a performace aonde se entende que haverá um JOB ou DTS diario para alimentar a tabela com resultados consolidados,
porem caso não houver resultado ja consolidado nesta tabela, será realizado a consulta de lançamentos, pois pode ocorrer a situação do cliente ter a necessidade
de antecipar o relatorio do dia.




