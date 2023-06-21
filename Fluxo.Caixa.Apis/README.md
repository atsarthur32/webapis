APIs

#Fluxo.Lancamentos.Caixa.Api
#Fluxo.RelatorioDiario.Api

Ambas as APIS estão no mesmo SLN, pois compartilham a estrutura de dados. No entanto, elas podem ser publicadas como microsserviços separados.


Para a execução desta aplicação, é necessário ter os seguintes softwares instalados:

- Visual Studio com .NET Core 6 
- SQL Management Studio ou outro software equivalente
- Docker Desktop 

Seguir os passos abaixo:

Caso já tenha o SQL server instalado na maquina, não será nessária a execução dos Passos 1 e 2.

1 - Baixar a imagem padrão do Docker utilizando o comando abaixo:

docker pull mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

----------=-----------------------------------------------------------------------------------------

2 - Iniciar sua Imagem utilizando o comando abaixo que definirá a senha do SA como Cacique2@.

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Cacique2@"  -p 1433:1433 --name DB_FLUXOCAIXA -d mcr.microsoft.com/mssql/server:2019-CU3-ubuntu-18.04

----------=-----------------------------------------------------------------------------------------

3 - Criar o DataBase de forma manual chamado DB_FLUXOCAIXA. 

----------=-----------------------------------------------------------------------------------------

4 - Executar o script anexo na pasta de pré requisitos do projeto (Fluxo.Caixa.Apis\ScriptBanco)

Obs: É recomendado utilizar o script em vez da migração (Migration) porem todo mapeamento do entity estão nas classes (classeMap) com relacionamentos, pois o script já popula as tabelas de domínio da aplicação.

---------------------------------------------------------------------------------------------------

#Fluxo.Lancamentos.Caixa.Api

Será necessário iniciar a utilização da API cadastrando novos registros para entender os valores possíveis em cada campo.


Obs: Campo data deve ser enviado o padrao yyyy-MM-dd
     Passar o TipoPagamento como zero retorna todos os tipos de pagamento.
     Caso seja utilizado o script, será cadastrado dois tipos de pagamentos ( 1 -Débito,  2 -Credito )
     Foram Cadastradas 3 empresas como exemplo ( 1 , 2 , 3)

#Fluxo.RelatorioDiario.Api

Foi criada uma estrutura priorizando a performance, onde se espera a execução diária de um JOB ou DTS para alimentar a tabela com resultados consolidados. 
No entanto, caso não haja resultado consolidado nesta tabela, será realizada a consulta de lançamentos, pois pode ocorrer a situação em que o cliente precise antecipar o relatório do dia.