
select * from creditos
drop table creditos

CREATE TABLE [dbo].[creditos](
	[codcredito] [int] IDENTITY(1,1) NOT NULL,
	[codalumno] [varchar](50) NOT NULL,
	[codcurso] [varchar](50) NOT NULL,
	[coddescripcion] [varchar](50) NOT NULL,
	[tipo] [char](1) NULL,
	[fechaing] [datetime] NULL,
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

delete from creditos where codcredito='47'

Select getdate()

select coddescripcion from creditos where coddescripcion='P01'


insert into creditos values ('A01','C01','P01','P',getdate());


alter table creditos alter column codalumno varchar(500);

CREATE TABLE [dbo].[descansos](
	[id_descansos] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[estado] [char](1) NULL,
	[fechaing] [datetime] NULL,
	[usuario_ing] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED (	[id_descansos] ASC )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]


select * from descansos

select id_descansos,descripcion,estado,CONVERT(varchar, fechaing,  103) as fechaing,usuario_ing from descansos where id_descansos=1

SELECT   
   GETDATE() AS UnconvertedDateTime,  
   CAST(GETDATE() AS nvarchar(30)) AS UsingCast,  
   CONVERT(nvarchar(30), GETDATE(), 126) AS UsingConvertTo_ISO8601  ;  

insert into descansos values('Descanso1','A',getdate(),'U01');

Server=234b518e-d93b-4e69-bc80-a9dd00675f56.sqlserver.sequelizer.com;Database=db234b518ed93b4e69bc80a9dd00675f56;User ID=qypbnacapqayhgfc;Password=hYzC8vwEpnxeGpnqP7UK446kw7gmGVnmK2udwEwqHfWsKaBvzSqtBJjn3pgbpj6A;








