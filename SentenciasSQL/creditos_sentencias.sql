
select * from creditos
drop table creditos

CREATE TABLE [dbo].[creditos](
	[codcredito] [int] IDENTITY(1,1) NOT NULL,
	[codalumno] [varchar](50) NOT NULL,
	[codcurso] [varchar](50) NOT NULL,
	[coddescripcion] [varchar](50) NOT NULL,
	[tipo] [char](1) NULL,
	[fechaing] [date] NULL,
PRIMARY KEY CLUSTERED (	[codcredito] ASC )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

drop table contador
CREATE TABLE [dbo].[contador](
	[idcontador] [int] IDENTITY(1,1) NOT NULL,
	[codalumno] [varchar](50) NOT NULL,
	[contador] [int] NOT NULL,
PRIMARY KEY CLUSTERED (	[idcontador] ASC )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]



select * from creditos
select * from contador


