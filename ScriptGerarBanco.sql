use DB_FLUXOCAIXA

CREATE TABLE TB_EMPRESA (
	id_empresa INT IDENTITY(1,1) PRIMARY KEY,
	nome varchar(255) NOT NULL UNIQUE,
	cnpj INT NOT NULL UNIQUE,
	grupo_empresarial varchar(255) NOT NULL,
	create_at datetime NOT NULL,
	update_at datetime NOT NULL,
)
GO
CREATE TABLE TB_TIPO_PAGAMENTO (
	id_tipo_pagamento INT IDENTITY(1,1) PRIMARY KEY,
	descricao varchar(255) NOT NULL UNIQUE,
	create_at datetime NOT NULL,
	update_at datetime NOT NULL,
)
GO
CREATE TABLE TB_LANCAMENTO (
	id_lancamento INT IDENTITY(1,1) PRIMARY KEY,
	id_empresa INT NOT NULL,
	id_tipo_pagamento INT NOT NULL,
	descricao varchar(255) NOT NULL,
	valor decimal(18,2) NOT NULL,
	create_at datetime NOT NULL,
	update_at datetime NOT NULL,

)
GO
CREATE TABLE TB_RELATORIO_DIARIO (
	id_relatorio_diario INT IDENTITY(1,1) PRIMARY KEY,
	id_empresa INT NOT NULL,
	id_tipo_pagamento INT NOT NULL,
	valor_total decimal(18,2) NOT NULL,
	data_fechamento datetime NOT NULL,
	create_at datetime NOT NULL,
	update_at datetime NOT NULL,
)

ALTER TABLE TB_LANCAMENTO  ADD CONSTRAINT FK_TB_LANCAMENTO_TB_EMPRESA FOREIGN KEY (id_empresa) REFERENCES  TB_EMPRESA (id_empresa)

ALTER TABLE TB_LANCAMENTO ADD CONSTRAINT FK_TB_LANCAMENTO_TB_TIPO_PAGAMENTO FOREIGN KEY (id_tipo_pagamento) REFERENCES TB_TIPO_PAGAMENTO (id_tipo_pagamento)

ALTER TABLE TB_RELATORIO_DIARIO ADD CONSTRAINT FK_TB_RELATORIO_DIARIO_TB_EMPRESA FOREIGN KEY (id_empresa) REFERENCES TB_EMPRESA (id_empresa)

ALTER TABLE TB_RELATORIO_DIARIO ADD CONSTRAINT FK_TB_RELATORIO_DIARIO_TB_TIPO_PAGAMENTO FOREIGN KEY (id_tipo_pagamento) REFERENCES TB_TIPO_PAGAMENTO (id_tipo_pagamento)


-- inserir dados
insert into TB_EMPRESA (nome, cnpj , grupo_empresarial , create_at , update_at)
values ('Mercado','123','CSF',GETDATE(),GETDATE())

insert into TB_EMPRESA (nome, cnpj , grupo_empresarial , create_at , update_at)
values ('Atacado','456','CSF',GETDATE(),GETDATE())

insert into TB_EMPRESA (nome, cnpj , grupo_empresarial , create_at , update_at)
values ('Varejo','789','CSF',GETDATE(),GETDATE())

insert into TB_TIPO_PAGAMENTO (descricao , create_at, update_at)
values ('Débito',GETDATE(),GETDATE())

insert into TB_TIPO_PAGAMENTO ( descricao , create_at, update_at)
values (  'Crédito',GETDATE(),GETDATE())


insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (1,1,1000.00, DATEADD(day, -1, GETDATE())  , DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (1,2,1000.00,DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (2,1,2000.00,DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (2,2,2000.00,DATEADD(day, -1, GETDATE())  , DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE())  )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (3,1,2000.00,DATEADD(day, -1, GETDATE())  , DATEADD(day, -1, GETDATE()) ,DATEADD(day, -1, GETDATE())  )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (3,2,2000.00,DATEADD(day, -1, GETDATE())  , DATEADD(day, -1, GETDATE()) , DATEADD(day, -1, GETDATE())  )


insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (1,1,1000.00, DATEADD(day, -2, GETDATE())  , DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (1,2,1000.00,DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (2,1,2000.00,DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE()) )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (2,2,2000.00,DATEADD(day, -2, GETDATE())  , DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE())  )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (3,1,2000.00,DATEADD(day, -2, GETDATE())  , DATEADD(day, -2, GETDATE()) ,DATEADD(day, -2, GETDATE())  )

insert into TB_RELATORIO_DIARIO (id_empresa , id_tipo_pagamento , valor_total , data_fechamento , create_at , update_at)
Values (3,2,2000.00,DATEADD(day, -2, GETDATE())  , DATEADD(day, -2, GETDATE()) , DATEADD(day, -2, GETDATE())  )